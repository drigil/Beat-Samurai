using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for the audio source which plays at a delay of time to beat. This audio is the one the player hears
public class PlayDelayedAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public GameObject silentAudio;


    // void Start()
    // {
    //     audioSource.PlayDelayed(silentAudio.GetComponent<AudioSyncScale>().timeToBeat);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClip(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.PlayDelayed(silentAudio.GetComponent<AudioSyncScale>().timeToBeat);
    }
}
