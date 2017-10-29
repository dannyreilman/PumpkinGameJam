using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer instance = null;

    public AudioClip menuTheme;
    public AudioClip mainTheme;

    private AudioSource player;
    private AudioLowPassFilter deadFilter;
    private bool currState;
    bool dead = false;

    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        player = GetComponent<AudioSource>();
        deadFilter = GetComponent<AudioLowPassFilter>();
        StartMusic(false);
	}

    private void Update()
    {
        if (GameController.instance == null)
        {
            dead = false;
        }
        else
        {
            dead = GameController.instance.gameOver;
        }

        deadFilter.enabled = dead;
    }

    public void StartMusic(bool main)
    {
        currState = main;
        player.loop = false;
        if (main)
            StartCoroutine(StartAfterEnd(mainTheme, main));
        else
            StartCoroutine(StartAfterEnd(menuTheme, main));
    }

    IEnumerator StartAfterEnd(AudioClip toPlay, bool state)
    {
        while (player.isPlaying)
        {
            if(state != currState)
            {
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }

        player.clip = toPlay;
        player.Play();
        player.loop = true;
    }
}
