using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip Assets_Sounds_score;
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<Bird> () != null)
        {
            GameControl.instance.BirdScored();
            audio.clip = Assets_Sounds_score;
            audio.Play();

        }
    }
}
