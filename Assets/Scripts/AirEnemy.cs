using UnityEngine;
using System.Collections;

public class AirEnemy : MonoBehaviour
{
    public Weapon weapon;
    public Weapon bombWeapon;
    private Animator anim;
    public AudioSource gunAudio;
    public AudioSource bombAudio;
    private Rigidbody2D body;

    void Awake ()
    {  
        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
    }

    void Update ()
    {
        if (Mathf.Abs (transform.position.x - WorldController.Instance.player.trans.position.x) < 10) {
            if (transform.position.y > WorldController.Instance.player.trans.position.y) {
                if (bombWeapon.CanShoot ()) {
                    anim.SetTrigger ("bomb");
                }
            } else if (Mathf.Abs (transform.position.y - WorldController.Instance.player.trans.position.y) < 5) {
                if (weapon.CanShoot ()) {
                    anim.SetTrigger ("fire");
                }
            }
        }
    }

    public void FireWeapon ()
    {
        weapon.Fire ();
        gunAudio.Play ();
    }

    public void ThrowBomb ()
    {
        bombWeapon.Fire ();
        bombAudio.Play ();
    }

    public void Die ()
    {
        anim.SetTrigger ("die");
    }

    public void Kill ()
    {
        Destroy (gameObject);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "kill_npc") { 
            Destroy (gameObject);
        }
    }
}
