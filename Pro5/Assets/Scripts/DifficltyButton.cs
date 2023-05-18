using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficltyButton : MonoBehaviour
{
    public float diffnumber;
    
    Button button;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
      button=GetComponent<Button>();  
      button.onClick.AddListener(SetDifficultyandLives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficultyandLives(){
    
       
       gameManager.StartGame(diffnumber);
       
    }
}
