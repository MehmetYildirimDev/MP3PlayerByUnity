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

    [SerializeField] private Slider DurationSlider;


    [SerializeField] List<AudioClip> MusicList = new List<AudioClip>();

    AudioSource audioSource;

    bool pause = true;

    int currentSong = 0;

    int LenghtMinute;
    int LenghtSecond;
    int DurationMinute;
    int DurationSecond;



    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        CalcalateMinute();
        NumberText.text = (currentSong + 1) + ".";
        SongNameText.text = MusicList[currentSong].name;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDuration();
        CalculateSlider();

        if (audioSource.time == MusicList[currentSong].length)
        {
            NextMusic();
        }

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
            CalcalateMinute();
            NumberText.text = (currentSong + 1) + ".";
            SongNameText.text = MusicList[currentSong].name;
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

    public void CalcalateMinute()
    {
        LenghtMinute = (int)MusicList[currentSong].length / 60;
        LenghtSecond = (int)MusicList[currentSong].length % 60;

        LenghtText.text = LenghtMinute + "." + LenghtSecond;

    }

    public void CalculateDuration()
    {
        DurationMinute = (int)audioSource.time / 60;
        DurationSecond = (int)audioSource.time % 60;

        if (DurationSecond<10)
        {
            DurationText.text = DurationMinute + ".0" + DurationSecond;
        }
        else
        {
            DurationText.text = DurationMinute + "." + DurationSecond;
        }
    }

    void CalculateSlider()
    {
        DurationSlider.maxValue = MusicList[currentSong].length;
        DurationSlider.value = audioSource.time;

    }
}
