using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public PlayerController player;

    private Transform trans;
    private Vector3 position;
    private float xLimit;
    private float lastX;
    private float deltaX;

    private Animator anim;

    public float maxX = 360;

    void Awake ()
    {
        anim = GetComponent<Animator> ();
        trans = GetComponent<Transform> ();
        lastX = -666;
        position = trans.position;
    }

    void Start ()
    {
        deltaX = trans.position.x - player.trans.position.x;
    }

    void Update ()
    {
        if (trans.position.x <= maxX && player.trans.position.x > lastX) {
            position.x = player.trans.position.x + deltaX;

            lastX = player.trans.position.x;

            trans.position = position;
        }
    }

    public void Shot ()
    {
        anim.SetTrigger ("shot");
    }

    public void End ()
    {
        anim.SetTrigger ("endgame");
    }
}
