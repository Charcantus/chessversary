using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidenzia : MonoBehaviour
{
    public static Evidenzia Instance { set; get; }

    public GameObject evidenziaPrefab;
    private List<GameObject> evidenzias;

    private void Start()
    {
        Instance = this;
        evidenzias = new List<GameObject> ();
    }

    private GameObject prendievidenziato()
    {
        GameObject go = evidenzias.Find(g => !g.activeSelf);
        if(go == null)
        {
            go = Instantiate(evidenziaPrefab);
            evidenzias.Add(go);
        }
        return go;
    }

    public void evidenziapermesse(bool[,] muove)
    {
        for(int i = 0; i < 8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if (muove[i, j])
                {
                    GameObject go = prendievidenziato();
                    go.SetActive (true);
                    go.transform.position = new Vector3(i+0.5f, 0, j+0.5f);
                }
            }
        }
    }

    public void nascondievidenziati()
    {
        foreach (GameObject go in evidenzias)
            go.SetActive(false);
    }
}
