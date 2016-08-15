using UnityEngine;
using System.Collections;

public class EndOfTheGame : MonoBehaviour
{
    public GameObject endOfTheGameGO;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player") { 
            endOfTheGameGO.SetActive (true);
        }
    }
}
