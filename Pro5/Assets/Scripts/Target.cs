using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour
{
    
    public ParticleSystem explosionParticle;
     AudioSource audioSource;
    public AudioClip explosionClip;
    
    GameManager gMScript;
    Rigidbody targetRg;
    public int pointValue;
    
    //torque value
    int tor=10;
    int minForceTarget=12;
    int maxForceTarget=19;
    int ySpawnPos=-6;
    float xRange=4;
    public static int  lives=3;
    

    // Start is called before the first frame update
    void Start()
    {
        targetRg=gameObject.GetComponent<Rigidbody>();
        targetRg.AddForce(RandomForce(),ForceMode.Impulse);
        targetRg.AddTorque(RandomTorque(),RandomTorque(),RandomTorque());
        transform.position=RandomSpawnPos();
        gMScript= GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnMouseDown()
    {
        if(gameObject.CompareTag("Obstacle") && !gMScript.isGameOver && !gMScript.isPouseGame)
        {
            Instantiate(explosionParticle,transform.position,transform.rotation);
            audioSource.PlayOneShot(explosionClip,1);
            gMScript.UpdateScore(pointValue);
            Destroy(gameObject);
        }
        else if ( gameObject.CompareTag("Bomb") && !gMScript.isGameOver && !gMScript.isPouseGame){
             Instantiate(explosionParticle,transform.position,transform.rotation);
             audioSource.PlayOneShot(explosionClip,1);
            Destroy(gameObject);
            lives--;
            if(lives==0)
            {
                gMScript.isGameOver=true;
            }
           
            
           
        }
        
      
    }
    void OnTriggerEnter(){
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minForceTarget,maxForceTarget);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }
    float RandomTorque(){
        return Random.Range(-tor,tor);
    }
}
