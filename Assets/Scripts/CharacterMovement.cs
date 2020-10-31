using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for handling character movement and playing sound and animation
public class CharacterMovement : MonoBehaviour{
    
    public Animator animator;
    public AudioSource audioSource;
    // Update is called once per frame
    void Update(){

        if(!PauseMenu.isPaused && !ButtonScrollView.isSelectMenu){
            if (Input.GetKeyDown(KeyCode.A))
                {
                    animator.SetBool("isLeftClicked", true);
                    audioSource.Play();
                    
                }
            else{
                    animator.SetBool("isLeftClicked", false);

            }

            if (Input.GetKeyDown(KeyCode.D))
                {
                    animator.SetBool("isRightClicked", true);
                    audioSource.Play();
                    
                }
            else{
                    animator.SetBool("isRightClicked", false);

            }

            if (Input.GetKeyDown(KeyCode.S))
                {
                    animator.SetBool("isCrouched", true);
                    
                }
            else{
                    animator.SetBool("isCrouched", false);

            }

            if (Input.GetKeyDown(KeyCode.W))
                {
                    animator.SetBool("isUpClicked", true);
                    audioSource.Play();
                    
                }
            else{
                    animator.SetBool("isUpClicked", false);

            }
        }

    }
}

