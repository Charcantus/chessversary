using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pezzo : MonoBehaviour
{
    public int CurrentX{set; get;}
    public int CurrentY{ set; get; }
    public bool isBianco;
    public bool hamosso;
    public bool arroccob;
    public bool arroccon;
    public bool sottoscacco;

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool[,] mossapossibile()
    {
        return new  bool[8,8];
    }
}
