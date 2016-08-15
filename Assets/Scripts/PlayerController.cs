using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public WorldController world;

    public Rigidbody2D body;
    public Transform trans;
    private bool grounded;
    private bool doJump;
    private Animator anim;

    public float maxSpeed = 10f;
    public float maxAirSpeed = 2f;

    public float speed = 100f;
    public float jumpForce = 100f;
    private float horizontalInput;
    private float verticalInput;

    public Weapon weapon;

    void Awake ()
    {
        anim = GetComponent<Animator> ();
        trans = GetComponent<Transform> ();
        body = GetComponent<Rigidbody2D> ();
    }

    void Start ()
    {
        grounded = false;
    }

    void Update ()
    {
        if (!WorldController.Instance.playing)
            return;

        if (Input.GetKey (KeyCode.UpArrow))
            verticalInput = 1;
        else if (Input.GetKey (KeyCode.DownArrow))
            verticalInput = -1;
        else
            verticalInput = 0;

        if (verticalInput != 0)
            horizontalInput = 0;
        else {
            if (Input.GetKey (KeyCode.RightArrow))
                horizontalInput = 1;
            else if (Input.GetKey (KeyCode.LeftArrow))
                horizontalInput = -1;
            else
                horizontalInput = 0;

            if (grounded && Input.GetKey (KeyCode.Space)) {
                doJump = true;
                grounded = false;   
            }
        }

        anim.SetBool ("down", verticalInput < -0.5f);
        anim.SetBool ("up", verticalInput > 0.5f);

        if (Input.GetKey (KeyCode.D)) {
            if (weapon.CanShoot ())
                anim.SetTrigger ("fire");
        }
    }

    public void FireWeapon ()
    {
        weapon.Fire ();
        WorldController.Instance.audio.PlayShoot ();
    }

    void FixedUpdate ()
    {
        if (doJump) {
            body.AddForce (transform.up * jumpForce);
            doJump = false;
            anim.SetBool ("air", true);
        }

        if (horizontalInput > 0 && ((grounded && body.velocity.x < maxSpeed) || (!grounded && body.velocity.x < maxAirSpeed))) {
            body.AddForce (transform.right * horizontalInput * speed);
            anim.SetBool ("walk", true);
        } else if (horizontalInput < 0 && ((grounded && body.velocity.x > -maxSpeed) || (!grounded && body.velocity.x > -maxAirSpeed))) {
            body.AddForce (transform.right * horizontalInput * speed);
            anim.SetBool ("walk", true);
        } else if (horizontalInput == 0) {
            anim.SetBool ("walk", false);
            Vector3 vel = body.velocity;
            vel.x = 0;
            body.velocity = vel;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "ground") { 
            if (!grounded) {
                grounded = true;
                anim.SetBool ("air", false);
            }
        } else if (col.gameObject.tag == "enemy") {
            WorldController.Instance.audio.PlayGirlHit ();
            SceneManager.LoadScene (0);
        } else if (col.gameObject.tag == "kill_zone") {
            WorldController.Instance.audio.PlayGirlHit ();
            SceneManager.LoadScene (0);
        }
    }
}
