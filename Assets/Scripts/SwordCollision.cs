using UnityEngine;

//Class for sword collision detection used to detect if enemy attacked and accordingly destroyin them
public class SwordCollision : MonoBehaviour
{   
    public Animator playerAnimator;
    //Check for Collisions
    void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){

            //Check if enemy coming from left or right or top
            //Coming from top
            if(other.gameObject.GetComponent<Enemy>().jumpSpeed != 0){
                if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Up Attack")){
                    Instantiate(original: other.gameObject.GetComponent<Enemy>().particleSystem, position: other.gameObject.transform.position, rotation: new Quaternion(0.707106829f , 0f, 0f, 0.707106829f));
                    Destroy(other.gameObject);
                }
                else{

                }
                Debug.Log("Enemy Top");
            }
            
            else{
                //Coming from left
                if(other.gameObject.GetComponent<Enemy>().speed > 0){
                    if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Left Attack")){
                        Instantiate(original: other.gameObject.GetComponent<Enemy>().particleSystem, position: new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 40, other.gameObject.transform.position.z), rotation: new Quaternion(0.707106829f , 0f, 0f, 0.707106829f));
                        Destroy(other.gameObject);
                    }
                    else{

                    }
                    Debug.Log("Enemy Left");
                }

                //Coming from right
                else{
                    if(playerAnimator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Right Attack")){
                        Instantiate(original: other.gameObject.GetComponent<Enemy>().particleSystem, position: new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 40, other.gameObject.transform.position.z), rotation: new Quaternion(0.707106829f , 0f, 0f, 0.707106829f));
                        Destroy(other.gameObject);
                    }
                    else{

                    }
                   Debug.Log("Enemy Right");
                }
            
            }
        }
    }
}
