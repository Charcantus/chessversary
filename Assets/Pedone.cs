using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedone : Pezzo
{

    public override bool[,] mossapossibile()
    {
        bool[,] r = new bool[8, 8];
        Pezzo c, c2;
        int[] e = Schacchierante.Instance.enpassant;

        //bianco
        if (isBianco)
        {
            //diagonale sinistra
            if(CurrentX != 0 && CurrentY != 7)
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                    r[CurrentX - 1, CurrentY + 1] = true;

                c = Schacchierante.Instance.Pezzi[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isBianco)
                    r[CurrentX - 1, CurrentY + 1] = true;
            }
            //diagonale destra
            if (CurrentX != 7 && CurrentY != 7)
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                    r[CurrentX + 1, CurrentY + 1] = true;

                c = Schacchierante.Instance.Pezzi[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isBianco)
                    r[CurrentX + 1, CurrentY + 1] = true;
            }
            //dritto
            if(CurrentY != 7)
            {
                c = Schacchierante.Instance.Pezzi[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = true;
            }

            //dritto prima mossa
            if(CurrentY == 1)
            {
                c = Schacchierante.Instance.Pezzi[CurrentX, CurrentY + 1];
                c2 = Schacchierante.Instance.Pezzi[CurrentX, CurrentY + 2];
                if (c == null & c2 == null)
                    r [CurrentX, CurrentY + 2] = true;
            }
        }
        else //nero
        {
            //diagonale sinistra
            if (CurrentX != 0 && CurrentY != 0)
            {

                if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                    r[CurrentX - 1, CurrentY - 1] = true;

                c = Schacchierante.Instance.Pezzi[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isBianco)
                    r[CurrentX - 1, CurrentY - 1] = true;
            }
            //diagonale destra
            if (CurrentX != 7 && CurrentY != 0)
            {

                if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                    r[CurrentX + 1, CurrentY - 1] = true;

                c = Schacchierante.Instance.Pezzi[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isBianco)
                    r[CurrentX + 1, CurrentY - 1] = true;
            }
            //dritto
            if (CurrentY != 0)
            {
                c = Schacchierante.Instance.Pezzi[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = true;
            }

            //dritto prima mossa
            if (CurrentY == 6)
            {
                c = Schacchierante.Instance.Pezzi[CurrentX, CurrentY - 1];
                c2 = Schacchierante.Instance.Pezzi[CurrentX, CurrentY - 2];
                if (c == null & c2 == null)
                    r[CurrentX, CurrentY - 2] = true;
            }

        }
        return r;
    }
}
