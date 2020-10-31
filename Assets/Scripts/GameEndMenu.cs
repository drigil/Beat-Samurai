using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEndMenu : MonoBehaviour
{
    public static bool isEnd = false;
    public GameObject endMenu;
    public GameObject samurai;
    public AudioSource delayedAudio;
    public AudioSource silentAudio;
    
    //Class for handling events after game ends either due to player death or player winning
    // Update is called once per frame
    void Update()
    {   
        
        if(samurai.GetComponent<HeroCollision>().isDead==true || (!delayedAudio.isPlaying && ButtonScrollView.isSelectMenu==false && PauseMenu.isPaused==false)){
            
            Stop();            
        }
        
        if(isEnd==true){
            
            if(Input.GetKeyDown("space")){
                Play();
                samurai.GetComponent<HeroCollision>().isDead = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            }
        }   
    }
    void Stop(){
        
        Time.timeScale = 0f;
        isEnd = true;
        delayedAudio.Stop();
        silentAudio.Stop();
        StartCoroutine(waitCoroutine());
        
    }

    void Play(){
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        isEnd = false;
        ButtonScrollView.isSelectMenu=true;
        
    }

    
    IEnumerator waitCoroutine(){
        yield return new WaitForSecondsRealtime(2);
        endMenu.SetActive(true);
    }
}
