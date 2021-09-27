using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regina : Pezzo
{
    public override bool[,] mossapossibile()
    {
        bool[,] r = new bool[8, 8];

        Pezzo c;
        int i,j;

        //destra
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = Schacchierante.Instance.Pezzi[i, CurrentY];
            if (c == null)
                r[i, CurrentY] = true;
            else
            {
                if (c.isBianco != isBianco)
                    r[i, CurrentY] = true;
                break;
            }
        }


        //sinistra
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = Schacchierante.Instance.Pezzi[i, CurrentY];
            if (c == null)
                r[i, CurrentY] = true;
            else
            {
                if (c.isBianco != isBianco)
                    r[i, CurrentY] = true;
                break;
            }
        }

        //su
        i = CurrentY;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = Schacchierante.Instance.Pezzi[CurrentX, i];
            if (c == null)
                r[CurrentX, i] = true;
            else
            {
                if (c.isBianco != isBianco)
                    r[CurrentX, i] = true;
                break;
            }
        }



        //giù
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = Schacchierante.Instance.Pezzi[CurrentX, i];
            if (c == null)
                r[CurrentX, i] = true;
            else
            {
                if (c.isBianco != isBianco)
                    r[CurrentX, i] = true;
                break;
            }
        }

        //su sinistra
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;
            c = Schacchierante.Instance.Pezzi[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isBianco != c.isBianco)
                    r[i, j] = true;
                break;
            }
        }

        //su destra
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;
            c = Schacchierante.Instance.Pezzi[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isBianco != c.isBianco)
                    r[i, j] = true;
                break;
            }
        }

        //giù sinistra
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;
            c = Schacchierante.Instance.Pezzi[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isBianco != c.isBianco)
                    r[i, j] = true;
                break;
            }
        }

        //giù destra
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
                break;
            c = Schacchierante.Instance.Pezzi[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isBianco != c.isBianco)
                    r[i, j] = true;
                break;
            }
        }
        return r;
    }
}
