using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider slider;
   public List <GameObject> targets;
   public TextMeshProUGUI scoreText,gameOverText,timeText,livesText,volumeText;
    public Button restartButton;
   public bool isGameOver=false;
   public bool isPouseGame=false;
   public GameObject titleScreen;
   private AudioSource audioSource;


    int score=0;
    float time=60;
   float spawnRate=0.7f;
   bool isStartGame=false;
   


    // Start is called before the first frame update
    void Start()
    {
      audioSource=GetComponent<AudioSource>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
       SoundMethod();
        livesText.text="Lives: "+Target.lives;
        

       if(isGameOver)
       {
        restartButton.gameObject.SetActive(true);
       }else if(time>0 && isStartGame)
       {
        time-= Time.deltaTime;
        timeText.text="Time: "+Mathf.FloorToInt(time);
       }
       else if(time<1)
       {
        isGameOver=true;
        timeText.text="Time: 0";
       }
       if(Input.GetKeyDown(KeyCode.Space))
       {
       PouseMethod();
       }
       
       
    }
  
    IEnumerator SpawnTargets(){
        while(!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index=Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            

        }
        

    }
    public void StartGame(float diffnumber)
    {
        isStartGame=true;
        spawnRate/=diffnumber;
        StartCoroutine("SpawnTargets");
        titleScreen.gameObject.SetActive(false);
    }
   public void UpdateScore(int addPoint){
        score+=addPoint;
        scoreText.text=("Score: "+score);
    }
    public void RestartMethod(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void  SoundMethod(){
         audioSource.volume=slider.value;
        if(isStartGame==true)
        {
            slider.gameObject.SetActive(false);
            volumeText.gameObject.SetActive(false);
            
        }
    }
    void PouseMethod(){
         if(Time.timeScale==1)
        {
            Time.timeScale=0;
            isPouseGame=true;

        }else{
            Time.timeScale=1;
            isPouseGame=false;
        }
    }
    

    
    
   
}
