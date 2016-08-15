using UnityEngine;
using System.Collections;

public class LifeUI : MonoBehaviour
{
    private Animator anim;

    void Awake ()
    {
        anim = GetComponent<Animator> ();
    }

    public void SetOn ()
    {
        anim.SetBool ("on", true);
    }

    public void SetOff ()
    {
        anim.SetBool ("on", false);
    }
}
