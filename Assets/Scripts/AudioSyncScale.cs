using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Child class of AudioSyncer
//Class for spawning enemies on beat and changing the size of sun on beat
public class AudioSyncScale : AudioSyncer
{   
    public Vector3 beatScale;
    public Vector3 restScale;
    public GameObject enemyPrefab;
    public GameObject shurikenPrefab;
    
    public GameObject hero;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    //Overriding the virtual methods
    public override void onUpdate(){
        base.onUpdate();
        if(m_isBeat){
            return;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
    }

    public override void onBeat(){
        base.onBeat();
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
        spawnEnemy();
    }

    //Function to change the size of sun
    private IEnumerator MoveToScale(Vector3 _target){
        Vector3 _curr = transform.localScale;
        Vector3 _initial = _curr;
        float _timer = 0;

        while(_curr != _target){
            _curr = Vector3.Lerp(_initial, _target, _timer/timeToBeat); //We pick intermediate values between initial and target
            _timer = _timer + Time.deltaTime;

            transform.localScale = _curr; //Set the scale to the intermediate value
            yield return null; // Yield is a contextual keyword to indicate to the compiler that the method is an iterator
        }

        m_isBeat = false;
    }

    //Function to spawn enemy
    public void spawnEnemy(){

        //Spawn enemy from left or right or top randomly
        bool isLeft = false;
        bool isJump = false;
        float randomValIsShuriken = Random.value;
        
        if(randomValIsShuriken <=0.3){
            float randomVal = Random.value;

            if(randomVal > 0.5){
                GameObject shuriken = Instantiate(shurikenPrefab) as GameObject;
                shuriken.transform.position = new Vector2(screenBounds.x * 1.2f, 40);
                shuriken.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
                float heroEnemyDist = hero.transform.position.x - shuriken.transform.position.x;
                shuriken.GetComponent<Shuriken>().speed = heroEnemyDist / timeToBeat;
            }

            else{
                GameObject shuriken = Instantiate(shurikenPrefab) as GameObject;
                shuriken.transform.position = new Vector2(- screenBounds.x * 1.2f, 40);
                shuriken.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
                float heroEnemyDist = hero.transform.position.x - shuriken.transform.position.x;
                shuriken.GetComponent<Shuriken>().speed = heroEnemyDist / timeToBeat;
            }
            
            
        }
        
        else{

            float randomVal = Random.value;    
            if(randomVal <= 0.3){
                isJump = true;
            }

            else if(randomVal <=0.6){
                isLeft = true;
            }

            if(isJump==true){
                GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector2(0, screenBounds.y * 1.2f);
                float heroEnemyDist = hero.transform.position.y + 60 - enemy.transform.position.y;
                enemy.GetComponent<Enemy>().jumpSpeed = heroEnemyDist / timeToBeat;
                enemy.GetComponent<Enemy>().isJumping = true;
                  
            }

            else{
                if(isLeft==true){
                    GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                    enemy.transform.position = new Vector2(screenBounds.x * -1.2f, 0);
                    float heroEnemyDist = hero.transform.position.x - 60 -  enemy.transform.position.x;
                    enemy.GetComponent<Enemy>().speed = heroEnemyDist / timeToBeat;
                }
            

                else{
                    GameObject enemy = Instantiate(enemyPrefab) as GameObject;
                    enemy.transform.position = new Vector2(screenBounds.x * 1.2f, 0);
                    enemy.transform.Rotate(0.0f, -180.0f, 0.0f); 
                    float heroEnemyDist = hero.transform.position.x + 60 - enemy.transform.position.x;
                    enemy.GetComponent<Enemy>().speed = heroEnemyDist / timeToBeat;
                }
            }
        }
    }
}
