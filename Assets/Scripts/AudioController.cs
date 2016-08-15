using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{

    private AudioSource source;

    public AudioClip shootClip;
    public AudioClip bombClip;
    public AudioClip[] girlHitClips;

    void Awake ()
    {
        source = GetComponent<AudioSource> ();
    }

    public void PlayShoot ()
    {
        source.PlayOneShot (shootClip);
    }

    public void PlayGirlHit ()
    {
        source.pitch = Random.Range (0.8f, 1.2f);
        source.PlayOneShot (girlHitClips [Random.Range (0, girlHitClips.Length)]);
        source.pitch = 1;
    }

    public void PlayBomb ()
    {
        source.PlayOneShot (bombClip);
    }
}
