using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavallo : Pezzo
{
    public override bool[,] mossapossibile()
    {
        bool[,] r = new bool[8, 8];
        //suinistra
        mossacavallo(CurrentX - 1, CurrentY + 2, ref r);

        //suestra
        mossacavallo(CurrentX + 1, CurrentY + 2, ref r);

        //destrasu
        mossacavallo(CurrentX + 2, CurrentY + 1, ref r);

        //destragiù
        mossacavallo(CurrentX + 2, CurrentY - 1, ref r);

        //giùnistra
        mossacavallo(CurrentX - 1, CurrentY - 2, ref r);

        //Giuestra
        mossacavallo(CurrentX + 1, CurrentY - 2, ref r);

        //Sinisù
        mossacavallo(CurrentX - 2, CurrentY + 1, ref r);

        //sinigiù
        mossacavallo(CurrentX - 2, CurrentY - 1, ref r);

        return r;
    }

    public void mossacavallo(int x, int y, ref bool[,] r)
    {
        Pezzo c;
        if(x>=0 && x<8 && y>=0 && y < 8)
        {
            c = Schacchierante.Instance.Pezzi[x, y];
            if (c == null)
                r[x, y] = true;
            else if (isBianco != c.isBianco)
                r[x, y] = true;
        } 
    }
}
