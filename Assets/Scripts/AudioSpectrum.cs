using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for processing data to detect beats later
//The audio source being used here wont be heard by the user, its there only to be processed
public class AudioSpectrum : MonoBehaviour
{   
    private float[] m_audioSpectrum;
    public static float spectrumValue {get; private set;} //{get; private set} is short hand for getter and setter methods
    public AudioSource audioSource;
    public AudioSource delayedAudioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        m_audioSpectrum = new float[128];  

    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);
        if(m_audioSpectrum!=null && m_audioSpectrum.Length>0){
            spectrumValue = m_audioSpectrum[0]*100;
        }
        
    }

    public void playClip(AudioClip audioClip){
        audioSource.clip = audioClip;
        audioSource.Play();
        delayedAudioSource.GetComponent<PlayDelayedAudio>().playClip(audioClip);
    }
}
