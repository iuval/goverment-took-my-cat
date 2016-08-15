using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
    public GameObject blockFloorGO;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player") {
            blockFloorGO.SetActive (false);
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.tag == "Player") {
            blockFloorGO.SetActive (true);
        }
    }
}
