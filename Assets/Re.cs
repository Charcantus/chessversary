using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re : Pezzo
{

    public override bool[,] mossapossibile()
    {
        bool[,] r = new bool[8, 8];
        Pezzo c, c2, c3;
        int i, j;

        //quadrati su
        i = CurrentX - 1;
        j = CurrentY + 1;
        if (CurrentY != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = Schacchierante.Instance.Pezzi[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (isBianco != c.isBianco)
                        r[i, j] = true;
                }
                i++;
            }

        }
        //quadrati giù
        i = CurrentX - 1;
        j = CurrentY - 1;
        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 && i < 8)
                {
                    c = Schacchierante.Instance.Pezzi[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (isBianco != c.isBianco)
                        r[i, j] = true;
                }
                i++;
            }

        }
        //sinistra
        if (CurrentX != 0)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX - 1, CurrentY];
            if (c == null)
                r[CurrentX - 1, CurrentY] = true;
            else if (isBianco != c.isBianco)
                r[CurrentX - 1, CurrentY] = true;
        }

        //destra
        if (CurrentX != 7)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX + 1, CurrentY];
            if (c == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (isBianco != c.isBianco)
                r[CurrentX + 1, CurrentY] = true;
        }

        //arrocco bianco?
        if (CurrentX == 4 && CurrentY == 0)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX+1, CurrentY];
            c2 = Schacchierante.Instance.Pezzi[CurrentX+2, CurrentY];
            if (c == null & c2 == null)
            {
                if (Schacchierante.Instance.Pezzi[4, 0].hamosso == false && Schacchierante.Instance.Pezzi[7, 0].hamosso == false)
                {
                    r[CurrentX + 2, CurrentY] = true;
                    arroccob = true;
                }
            }
        }

        //arrocco biancolungo?
        if (CurrentX == 4 && CurrentY == 0)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX - 1, CurrentY];
            c2 = Schacchierante.Instance.Pezzi[CurrentX - 2, CurrentY];
            c3 = Schacchierante.Instance.Pezzi[CurrentX - 3, CurrentY];
            if (c == null & c2 == null & c3 == null) {
                if (Schacchierante.Instance.Pezzi[4, 0].hamosso == false && Schacchierante.Instance.Pezzi[0, 0].hamosso == false)
                {
                    r[CurrentX - 2, CurrentY] = true;
                    arroccob = true;
                }
            }
        }

        //arrocco nero corto?
        if (CurrentX == 4 && CurrentY == 7)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX + 1, CurrentY];
            c2 = Schacchierante.Instance.Pezzi[CurrentX + 2, CurrentY];
            if (c == null & c2 == null)
            {
                if (Schacchierante.Instance.Pezzi[4, 7].hamosso == false && Schacchierante.Instance.Pezzi[7, 7].hamosso == false)
                {
                    r[CurrentX + 2, CurrentY] = true;
                    arroccon = true;
                }
            }
        }

        //arrocco nero lungo?
        if (CurrentX == 4 && CurrentY == 7)
        {
            c = Schacchierante.Instance.Pezzi[CurrentX - 1, CurrentY];
            c2 = Schacchierante.Instance.Pezzi[CurrentX - 2, CurrentY];
            c3 = Schacchierante.Instance.Pezzi[CurrentX - 3, CurrentY];
            if (c == null & c2 == null & c3 == null)
            {
                if (Schacchierante.Instance.Pezzi[4, 7].hamosso == false && Schacchierante.Instance.Pezzi[0, 7].hamosso == false)
                {
                    r[CurrentX - 2, CurrentY] = true;
                    arroccon = true;
                }
            }
        }

        //scacco?
        



        return r;
    }
}