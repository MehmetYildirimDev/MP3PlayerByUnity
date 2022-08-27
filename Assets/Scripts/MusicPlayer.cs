using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private Text SongNameText;
    [SerializeField] private Text DurationText;
    [SerializeField] private Text LenghtText;
    [SerializeField] private Text NumberText;
    [SerializeField] private Text PlayPauseButtonText;


    [SerializeField] List<AudioClip> MusicList = new List<AudioClip>();

    AudioSource audioSource;

    bool pause = true;

    int currentSong = 0;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NumberText.text = (currentSong + 1) + ".";

    }

    public void PlayMusic()
    {
        audioSource.clip = MusicList[currentSong];
        if (audioSource.isPlaying && !pause)
        {
            audioSource.Pause();
            pause = true;
            PlayPauseButtonText.text = "l>";
        }
        else
        {
            audioSource.Play();
            pause = false;
            PlayPauseButtonText.text = "ll";
        }

    }


    public void NextMusic()
    {
        if (currentSong != MusicList.Count - 1)
        {
            currentSong++;
        }
        else
        {
            currentSong = 0;
        }

        PlayMusic();

    }

    public void PreviousdMusic()
    {
        if (currentSong == 0)
        {
            currentSong = MusicList.Count - 1;
        }
        else
        {
            currentSong--;
        }

        PlayMusic();

    }


}
