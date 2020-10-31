using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Class for setting names of buttons on music selection screen and getting and setting the corresponding audio sources

public class MusicButton : MonoBehaviour {

    private string Name;
    private AudioClip audioClip;
    
    public TMPro.TextMeshProUGUI ButtonText;
    public ButtonScrollView ScrollView;

    public void SetName(string name){
        Name = name;
        ButtonText.text = name;
    }

    public void SetClip(AudioClip ac){
        audioClip = ac;
    }
    public void Button_Click(){
        ScrollView.ButtonClicked(this);
    }

    public string GetName(){
        return Name;
    }

    public AudioClip GetClip(){
        return audioClip;
    }
} 