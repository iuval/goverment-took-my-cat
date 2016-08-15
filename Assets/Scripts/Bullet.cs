using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    void Start ()
    {
        GetComponent<Rigidbody2D> ().velocity = transform.right * 10f;
        Destroy (gameObject, 2.0f);   
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player") {
            WorldController.Instance.bloodsPS.transform.position = transform.position;
            WorldController.Instance.bloodsPS.Play ();
            WorldController.Instance.audio.PlayGirlHit ();
            WorldController.Instance.HitPlayer (1);
            Destroy (gameObject);
        }
    }
}
