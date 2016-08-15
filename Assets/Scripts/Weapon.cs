using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject bulletGO;

    public int shotsToColldown = 10;
    private int shots;
    public float colldown = 2f;
    private float colldownTime = 1f;
    public float fireRate = 0.2f;
    private float fireTime = 1f;
    private float lastFireTime;

    private bool coolingdown;

    void Start ()
    {
        fireTime = 0;
        colldownTime = 0;
        coolingdown = false;
    }

    void Update ()
    {
        if (coolingdown) {
            colldownTime += Time.deltaTime;
            if (colldownTime > colldown)
                coolingdown = false;
        }
    }

    public bool CanShoot ()
    {
        if (!coolingdown) {
            fireTime += Time.timeSinceLevelLoad - lastFireTime;
            if (fireTime > fireRate) {
                lastFireTime = Time.timeSinceLevelLoad;
                fireTime = 0;
                return true;
            }
        } 
        return false;
    }

    public void Fire ()
    {
        CreateBullet ();
        fireTime = 0;

        shots++;
        if (shots == shotsToColldown) {
            shots = 0;
            coolingdown = true;
            colldownTime = 0;
        }
    }

    private void CreateBullet ()
    {
        GameObject.Instantiate (bulletGO, transform.position, transform.rotation, null);
    }
}
