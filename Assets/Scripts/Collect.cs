using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        //collectSound.Play();
        Score_card. score += 50;
        Destroy(gameObject);
    }
}
