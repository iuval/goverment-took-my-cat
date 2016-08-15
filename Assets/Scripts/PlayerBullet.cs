using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    void Start ()
    {
        GetComponent<Rigidbody2D> ().velocity = transform.right * 15f;
        Destroy (gameObject, 2.0f);   
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "enemy") {
            col.gameObject.SendMessage ("Die");
            Destroy (gameObject);
        } else if (col.tag == "ground") {
            Destroy (gameObject);
        }
    }
}
