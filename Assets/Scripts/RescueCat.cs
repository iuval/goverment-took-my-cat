using UnityEngine;
using System.Collections;

public class RescueCat : MonoBehaviour
{
    private AudioSource audio;
    private Animator anim;
    private bool used;

    void Awake ()
    {
        used = false;
        anim = GetComponent<Animator> ();
        audio = GetComponent<AudioSource> ();
    }

    public void Reset ()
    {
        anim.SetTrigger ("reset");
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player") { 
            anim.SetTrigger ("free");
            if (!used) {
                WorldController.Instance.AddLifePlayer (1);
                used = true;
            }
        }
    }

    public void Miau ()
    {
        audio.Play ();
    }
}
