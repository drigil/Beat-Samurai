using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Class for getting audio files from resources folder and dynamically placing them in a scroll view
public class ButtonScrollView : MonoBehaviour {

    public GameObject Button_Template;
    private List<string> NameList = new List<string>();
    
    private Object[] audioClipArr;
    public AudioSource silentAudioSource;
    public GameObject currentMenu;
    public static bool isSelectMenu = true;

 // Use this for initialization
    void Start () {
        
        audioClipArr = Resources.LoadAll<AudioClip>("AudioClips");
        Debug.Log("Array size is " + audioClipArr.Length);
        foreach(var clip in audioClipArr){
            NameList.Add(clip.name);
            Debug.Log("Added");
        }
        
       
        int len = NameList.Count;
        for(int i = 0; i<len; i++){
            GameObject go = Instantiate(Button_Template) as GameObject;
            go.SetActive(true);
            MusicButton TB = go.GetComponent<MusicButton>();
            TB.SetName(NameList[i]);
            TB.SetClip((AudioClip)audioClipArr[i]);
            go.transform.SetParent(Button_Template.transform.parent);
        }
    }   
 
    public void ButtonClicked(MusicButton button){
        Debug.Log(button.GetName() + " button clicked.");
        silentAudioSource.GetComponent<AudioSpectrum>().playClip(button.GetClip());
        isSelectMenu = false;
        currentMenu.SetActive(false);

    }
} 