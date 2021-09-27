using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schacchierante : MonoBehaviour
{
    public static Schacchierante Instance { set; get; }
    private bool[,] mossepermesse { set; get; }

    public Pezzo[,] Pezzi { set; get; }
    private Pezzo pezzoselezionato;

    private const float Tilesize = 1.0f;
    private const float Tileoffset = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> pezziPrefabs;
    private List<GameObject> pezziAttivi = new List<GameObject>();

    public int[] enpassant { set; get; }

    private Quaternion orientazione = Quaternion.Euler(0, 180, 0);

    public bool isturnobianco = true;

    private void Start()
    {
        Instance = this;
        Creatuttipezzi();
    }

    private void Update()
    {
        UpdateSelection();
        Disegnaschacchi();

        if (Input.GetMouseButtonDown(0))
        {
            if(selectionX >= 0 && selectionY >= 0)
            {
                if(pezzoselezionato == null)
                {
                    //selezionalo
                    selezionapezzo(selectionX, selectionY);
                }
                else
                {
                    //muovilo
                    muovipezzo(selectionX, selectionY);
                }
            }
        }
    }

    private void selezionapezzo(int x, int y)
    {
        if (Pezzi[x, y] == null)
            return;
        if (Pezzi[x, y].isBianco != isturnobianco)
            return;

        bool halmenounamossa = false;
        mossepermesse = Pezzi[x, y].mossapossibile();
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if (mossepermesse[i, j])
                    halmenounamossa = true;

        if (!halmenounamossa)
            return;

        pezzoselezionato = Pezzi[x, y];
        Evidenzia.Instance.evidenziapermesse(mossepermesse);
    }

    private void muovipezzo(int x, int y)
    {
        if (mossepermesse[x,y])
        {
            Pezzo c = Pezzi[x, y];
            if(c != null && c.isBianco != isturnobianco)
            {
                //cattura
                //se è il re
                if (c.GetType() == typeof(Re))
                {
                    Fine();
                    return;
                }
                pezziAttivi.Remove(c.gameObject);
                Destroy(c.gameObject);
            }

            if(x == enpassant[0] && y == enpassant[1])
            {
                if (isturnobianco)
                    c = Pezzi[x, y - 1];
                else
                    c = Pezzi[x, y + 1];

                pezziAttivi.Remove(c.gameObject);
                Destroy(c.gameObject);
            }

            enpassant[0] = -1;
            enpassant[1] = -1;
            if (pezzoselezionato.GetType() == typeof(Pedone))
            {
                if (y == 7)
                {
                    pezziAttivi.Remove(pezzoselezionato.gameObject);
                    Destroy(pezzoselezionato.gameObject);
                    Creapezzi(1, x, y);
                    pezzoselezionato = Pezzi[x, y];
                }

                else if (y == 0)
                {
                    pezziAttivi.Remove(pezzoselezionato.gameObject);
                    Destroy(pezzoselezionato.gameObject);
                    Creapezzi(7, x, y);
                    pezzoselezionato = Pezzi[x, y];
                }

                if (pezzoselezionato.CurrentY == 1 && y == 3)
                {
                    enpassant[0] = x;
                    enpassant[1] = y - 1;
                }else if(pezzoselezionato.CurrentY == 6 && y == 4)
                {
                    enpassant[0] = x;
                    enpassant[1] = y + 1;
                }
            }

            if (pezzoselezionato.arroccob == true)
            {
                if (x == 6 && y==0)
                {
                    pezziAttivi.Remove(Pezzi[7, 0].gameObject);
                    Destroy(Pezzi[7, 0].gameObject);
                    pezzoselezionato.arroccob = false;
                    Creapezzi(2, 5, 0);
                }
                if (x == 2 && y==0)
                {
                    pezziAttivi.Remove(Pezzi[0, 0].gameObject);
                    Destroy(Pezzi[0, 0].gameObject);
                    pezzoselezionato.arroccob = false;
                    Creapezzi(2, 3, 0);
                }
            }

            if (pezzoselezionato.arroccon == true)
            {
                if (x == 6 && y == 7)
                {
                    pezziAttivi.Remove(Pezzi[7, 7].gameObject);
                    Destroy(Pezzi[7, 7].gameObject);
                    pezzoselezionato.arroccon = false;
                    Creapezzi(8, 5, 7);
                }
                if (x == 2 && y == 7)
                {
                    pezziAttivi.Remove(Pezzi[0, 7].gameObject);
                    Destroy(Pezzi[0, 7].gameObject);
                    pezzoselezionato.arroccon = false;
                    Creapezzi(8, 3, 7);
                }
            }


            Pezzi[pezzoselezionato.CurrentX, pezzoselezionato.CurrentY] = null;
            pezzoselezionato.transform.position = prendicentro(x, y);
            pezzoselezionato.hamosso = true;
            pezzoselezionato.SetPosition(x, y);
            Pezzi[x, y] = pezzoselezionato;
            isturnobianco = !isturnobianco;
        }


        Evidenzia.Instance.nascondievidenziati();
        pezzoselezionato = null;
        selezionapezzo(selectionX, selectionY);
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Baschacchi"))){
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void Creapezzi(int index, int x, int y)
    {
        GameObject go = Instantiate(pezziPrefabs[index], prendicentro(x, y), orientazione) as GameObject;
        go.transform.SetParent(transform);
        Pezzi[x, y] = go.GetComponent<Pezzo>();
        Pezzi[x, y].SetPosition(x, y);
        pezziAttivi.Add (go);
    }

    private void Creatuttipezzi()
    {
        pezziAttivi = new List<GameObject>();
        Pezzi = new Pezzo[8, 8];
        enpassant = new int[2] { -1,-1};

        //prima i bianchi
        //Re
        Creapezzi(0, 4, 0);

        //Regina
        Creapezzi(1, 3, 0);

        //Torri
        Creapezzi(2, 0, 0);
        Creapezzi(2, 7, 0);

        //Alfieri
        Creapezzi(3, 2, 0);
        Creapezzi(3, 5, 0);

        //Cavalli
        Creapezzi(4, 1, 0);
        Creapezzi(4, 6, 0);

        //Pedoni
        Creapezzi(5, 0, 1);
        Creapezzi(5, 1, 1);
        Creapezzi(5, 2, 1);
        Creapezzi(5, 3, 1);
        Creapezzi(5, 4, 1);
        Creapezzi(5, 5, 1);
        Creapezzi(5, 6, 1);
        Creapezzi(5, 7, 1);

        //poi i neri
        //Re
        Creapezzi(6, 4, 7);

        //Regina
        Creapezzi(7, 3, 7);

        //Torri
        Creapezzi(8, 0, 7);
        Creapezzi(8, 7, 7);

        //Alfieri
        Creapezzi(9, 2, 7);
        Creapezzi(9, 5, 7);

        //Cavalli
        Creapezzi(10, 1, 7);
        Creapezzi(10, 6, 7);

        //Pedoni
        Creapezzi(11, 0, 6);
        Creapezzi(11, 1, 6);
        Creapezzi(11, 2, 6);
        Creapezzi(11, 3, 6);
        Creapezzi(11, 4, 6);
        Creapezzi(11, 5, 6);
        Creapezzi(11, 6, 6);
        Creapezzi(11, 7, 6);

    }

    private Vector3 prendicentro(int x, int y)
    {
        Vector3 origine = Vector3.zero;
        origine.x += (Tilesize * x) + Tileoffset;
        origine.z += (Tilesize * y) + Tileoffset;
        origine.y += 0.3f;
        return origine;
    }

    private void Disegnaschacchi()
    {
        Vector3 linearghezza = Vector3.right * 8;
        Vector3 linealtezza = Vector3.forward * 8;

        for(int i = 0; i<=8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + linearghezza);
            for(int j=0; j<=8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + linealtezza);
            }
        }
        /*
        //disegnaselezione
        if(selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }*/
    }

    private void Fine()
    {
        if (isturnobianco)
            Debug.Log("Bianco vince");
        else
            Debug.Log("Nero vince");

        foreach (GameObject go in pezziAttivi)
            Destroy(go);

        isturnobianco = true;
        Evidenzia.Instance.nascondievidenziati();
        Creatuttipezzi();
    }

}
