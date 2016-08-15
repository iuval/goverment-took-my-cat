using UnityEngine;
using System.Collections;

public class RelativeMovement : MonoBehaviour
{
    public float factor;

    private Transform trans;
    private Vector3 pos;
    private float delta;

    public Transform targetTrans;

    void Start ()
    {
        trans = GetComponent<Transform> ();
        pos = trans.position;
    }

    void Update ()
    {
        delta += Time.deltaTime * factor;
        pos.x = Mathf.Lerp (pos.x, targetTrans.position.x + delta, Time.deltaTime);
        trans.position = pos;
    }
}
