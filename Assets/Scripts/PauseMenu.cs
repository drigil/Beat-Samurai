using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for handling all activities relating to the pause menu such as taking care of player movement and audio sources
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public AudioSource delayedAudio;
    public AudioSource silentAudio;
    

    // Update is called once per frame
    void Update()
    {   
        if(!GameEndMenu.isEnd){

            if(Input.GetKeyDown(KeyCode.Escape)){
                if(isPaused){
                    Resume();
                }
                else{
                    Pause();
                }
            }  
        }      
    }

    void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        delayedAudio.UnPause();
        silentAudio.UnPause();
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        delayedAudio.Pause();
        silentAudio.Pause();
    }
}
