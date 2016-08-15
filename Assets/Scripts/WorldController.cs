using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    public static WorldController Instance;

    void Awake ()
    {
        if (Instance) {
            DestroyImmediate (gameObject);
        } else {
//          DontDestroyOnLoad(gameObject);
            Instance = this;
            audio = GetComponent<AudioController> ();
        }
    }

    public GameObject menu;
    public ParticleSystem explosionPS;
    public ParticleSystem bloodsPS;

    public Level[] levels;
    public bool playing;

    public LifeUI[] lifes;

    private float lastPlayerX;
    public float nextPlayerLimitX;
    public float levelW;
    public float levelX;

    public AudioController audio;

    private int leftLevelIndex;

    public PlayerController player;
    public CameraController camera;

    private int playerLife;

    void Start ()
    {
        menu.SetActive (true);
        playing = false;
        for (int i = 0; i < levels.Length; i++) {
            levels [i].gameObject.SetActive (false);
        }
        for (int i = 0; i < 3 && leftLevelIndex + i < levels.Length; i++) {
            levels [i + leftLevelIndex].gameObject.SetActive (true);
        }
        nextPlayerLimitX = levelW * 1.5f;

        playerLife = 5;
        UpdateLifesUI ();
    }

    void Update ()
    {
        if (!playing) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                StartGame ();
                playing = true;
                Time.timeScale = 1;
            }

            return;
        }

        if (player.trans.position.x > nextPlayerLimitX) {
            nextPlayerLimitX += levelW;
            levels [leftLevelIndex].gameObject.SetActive (false);
            leftLevelIndex++;
            if (leftLevelIndex == levels.Length) {
                leftLevelIndex = 0;
            }
            int tempIndex = leftLevelIndex;
            for (int i = 0; i < 3 && leftLevelIndex + i < levels.Length; i++) {
                tempIndex++;
                if (tempIndex == levels.Length) {
                    tempIndex = 0;
                }
                levels [tempIndex].gameObject.SetActive (true);
            }
        }
    }

    private Level RandomUnusedLevel (int index)
    {
        if (index == -1)
            index = Random.Range (0, levels.Length);
        else {
            index++;
            if (index == levels.Length)
                index = 0;
        }
        if (levels [index].InUse ()) {
            return RandomUnusedLevel (index);
        } else {
            return levels [index];
        }
    }

    public void HitPlayer (int value)
    {
        playerLife -= value;
        Debug.Log ("hit player" + playerLife);

        if (playerLife <= 0)
            SceneManager.LoadScene (0);
        else
            UpdateLifesUI ();
    }

    public void AddLifePlayer (int value)
    {
        playerLife += value;
        if (playerLife > lifes.Length)
            playerLife = lifes.Length;
        UpdateLifesUI ();
    }

    public void UpdateLifesUI ()
    {
        for (int i = 0; i < lifes.Length; i++) {
            if (i < playerLife)
                lifes [i].SetOn ();
            else
                lifes [i].SetOff ();
        }
    }

    public void StartGame ()
    {
        menu.SetActive (false);
    }
}
