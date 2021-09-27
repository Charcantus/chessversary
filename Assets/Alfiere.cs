using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfiere : Pezzo
{
    public override bool[,] mossapossibile()
    {
        bool[,] r = new bool[8, 8];

        Pezzo c;
        int i, j;

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
