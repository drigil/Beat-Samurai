using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

//Class for opening files through the file explorer and converting them to audio sources to be used at runtime
public class GetSong : MonoBehaviour
{
    public GameObject currentMenu;
    public AudioSource silentAudioSource;
    
    public void ChooseFile(){
        
        StartCoroutine(ShowLoadDialogRoutine());
    }
    IEnumerator ShowLoadDialogRoutine(){
        
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Music", ".wav"));
        FileBrowser.SetDefaultFilter(".wav");
        yield return FileBrowser.WaitForLoadDialog(false, true, null, "Load File", "Load");
        Debug.Log(FileBrowser.Success);
        if(FileBrowser.Success){
            
            string fileName = FileBrowser.Result[0];
            Debug.Log(fileName);
            fileName = string.Format("file://{0}", fileName);
            WWW www = new WWW(fileName);
            yield return www;
            AudioClip audioClip = www.GetAudioClip(false, false);
            silentAudioSource.GetComponent<AudioSpectrum>().playClip(audioClip);
            ButtonScrollView.isSelectMenu = false;
            currentMenu.SetActive(false);
        
        }
        
    }
}
