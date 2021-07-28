using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_card : MonoBehaviour
{
    //https://www.youtube.com/watch?v=D0lx90n0s-4
    public GameObject scoreText;
    public static int score;
    
    void Update()
    {
       scoreText.GetComponent<Text>().text = "SCORE :  " + score;
       
    }


}
