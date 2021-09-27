using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruotacamera : MonoBehaviour
{
    Animator animacamera;

    void Start()
    {
        animacamera = gameObject.GetComponent<Animator>();
    }

    public void ruota()
    {
        if (animacamera.GetBool("muovere"))
        {
            animacamera.SetBool("muovere", false);
            return;
        }

        if(!animacamera.GetBool("muovere"))
        animacamera.SetBool("muovere", true);
        return;
    }
}
