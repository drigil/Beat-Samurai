using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Class for checking player(hero) collision and in case collision occures setting the player's statues to dead
public class HeroCollision : MonoBehaviour
{   
    public bool isDead = false;
    public ParticleSystem particleSystem;
    //Check for Collisions
    void OnTriggerEnter(Collider other){
        if(other.tag == "Shuriken"){
            if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Crouch")){
                //Destroy(other.gameObject);
            }

            else{
                Debug.Log("Game Over");
                particleSystem.Play();
                isDead = true;
            }
        }

        else if(other.tag != "Sword"){
            Debug.Log("Game Over");
            particleSystem.Play(); 
            isDead = true;
            
        }

        
    }

}
