using UnityEngine;
using System.Collections;

public class LoopImages : MonoBehaviour
{
    private float lastPlayerX;
    private float nextPlayerLimitX;
    public float imageW;
    public float imageX;

    public Transform[] images;
    private int leftImageIndex;

    private Vector3 tempVec;

    void Update ()
    {
        if (WorldController.Instance.player.trans.position.x > nextPlayerLimitX) {
            nextPlayerLimitX += imageW;
            tempVec = images [leftImageIndex].position;
            tempVec.x += images.Length * imageW;
            images [leftImageIndex].position = tempVec;
            leftImageIndex++;
            if (leftImageIndex == images.Length) {
                leftImageIndex = 0;
            }
        }
    }
}
