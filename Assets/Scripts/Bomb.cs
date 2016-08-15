using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    void Start ()
    {
        GetComponent<Rigidbody2D> ().velocity = transform.right * -5f;
        Destroy (gameObject, 2.0f);   
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player" || col.tag == "ground") {
            WorldController.Instance.explosionPS.transform.position = transform.position;
            WorldController.Instance.explosionPS.Play ();
            WorldController.Instance.audio.PlayBomb ();
            Debug.Log (Vector3.Distance (WorldController.Instance.player.trans.position, transform.position));
            if (Vector3.Distance (WorldController.Instance.player.trans.position, transform.position) < 5) {
                WorldController.Instance.HitPlayer (2);
//                WorldController.Instance.player.body.AddForce ((WorldController.Instance.player.trans.position - transform.position) * 200f);
            }
            Destroy (gameObject);
        }
    }
}
