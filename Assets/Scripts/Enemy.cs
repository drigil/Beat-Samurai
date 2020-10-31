using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour{

    public float speed = 0;
    public float jumpSpeed = 0;
    public ParticleSystem particleSystem;
    private Rigidbody rb;
    private Vector2 screenBounds;
    public bool isJumping;

    public Animator animator;

    //Class for initializing enemies and destroying them after they cross certain boundaries and leave the scene
    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        if(isJumping==false){
            rb.velocity = new Vector3(speed, 0, 0);    
        }

        else{
            animator.SetBool("isJumping", true);
            transform.Rotate(0.0f, 180.0f, 0.0f);
            rb.velocity = new Vector3(0, jumpSpeed, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        if(speed > 0){
            if(transform.position.x > screenBounds.x * 2){
                Destroy(this.gameObject);
            }
        }

        else if(speed < 0){
            if(transform.position.x < -screenBounds.x * 2){
                Destroy(this.gameObject);
            }
        }

        else if(jumpSpeed > 0){
            if(transform.position.y < -screenBounds.y * 2){
                Destroy(this.gameObject);
            }
        }
        
    }
}
