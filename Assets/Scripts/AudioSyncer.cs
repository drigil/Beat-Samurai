using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for beat detection
public class AudioSyncer : MonoBehaviour
{
    // Start is called before the first frame update

    public float bias; //Spectrum value that trigger beat
    public float timeStep; //Minimum interval between each beat
    public float timeToBeat; //Time before visualization completes
    public float restSmoothTime; //How fast object goes to rest after beat

    private float m_previousAudioValue; 
    private float m_audioValue;
    private float m_timer; //Keep track of time step

    protected bool m_isBeat; //Check if object in beat state
    
    // Update is called once per frame
    void Update()
    {
        onUpdate();
    }

    public virtual void onBeat(){
        //Debug.Log("beat");
        m_timer = 0;
        m_isBeat = true;
    }

    public virtual void onUpdate(){ //Virtual allows for inherited class to override the method
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioSpectrum.spectrumValue;


        //Check if beat occurred and call onBeat() in case it did
        if(m_previousAudioValue>bias && m_audioValue <= bias){
            if(m_timer > timeStep){
                onBeat();
            }
        }

        if(m_previousAudioValue<=bias && m_audioValue > bias){
            if(m_timer > timeStep){
                onBeat();
            }
        }

        m_timer = m_timer + Time.deltaTime;

        
    }
}
