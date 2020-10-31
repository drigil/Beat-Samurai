using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for shuriken initialization and destruction
public class Shuriken : MonoBehaviour
{   
    public float speed = 0;
    public GameObject shurikenRef;
    
    private Rigidbody rb;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = new Vector3(speed, 0, 0);

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
        
    }
}
