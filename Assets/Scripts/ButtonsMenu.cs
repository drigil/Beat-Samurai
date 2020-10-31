using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using SimpleFileBrowser;

//Class for initial menu
public class ButtonsMenu : MonoBehaviour{

    List<AudioClip> audioclipArr = new List<AudioClip>();

    // Start is called before the first frame update
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Takes us to the gameplay scene
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }


}
