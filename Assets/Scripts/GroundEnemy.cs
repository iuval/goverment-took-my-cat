using UnityEngine;
using System.Collections;

public class GroundEnemy : MonoBehaviour
{
    public Weapon weapon;
    private Animator anim;
    public AudioSource audio;
    private Rigidbody2D body;

    public ParticleSystem explosionPS;

    void Awake ()
    {  
        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
    }

    void Update ()
    {
        if (transform.position.x - WorldController.Instance.player.trans.position.x < 12) {
            if (weapon.CanShoot ()) {
                anim.SetTrigger ("fire");
            }
        }
    }

    public void FireWeapon ()
    {
        weapon.Fire ();
        audio.Play ();
    }

    public void Die ()
    {
        anim.SetTrigger ("die");
    }

    public void Kill ()
    {
        explosionPS.Emit (150);
        Destroy (gameObject);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "kill_npc") { 
            Destroy (gameObject);
        }
    }
}
