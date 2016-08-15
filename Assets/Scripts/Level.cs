using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private Vector3 position;

    void Awake ()
    {
        position = Vector2.zero;
    }

    void Update ()
    {
//        trans.position = position;
    }

    public float GetX ()
    {
        return position.x;
    }

    public void SetX (float x)
    {
        position.x = x;
    }

    public void AddX (float x)
    {
        position.x += x;
    }

    public void SetInGame ()
    {
        position.y = 0;
        gameObject.SetActive (true);
    }

    public void SetOutOfGame ()
    {
        position.y = 1000;
        gameObject.SetActive (false);
    }

    public bool InUse ()
    {
        return gameObject.activeSelf;
    }
}
