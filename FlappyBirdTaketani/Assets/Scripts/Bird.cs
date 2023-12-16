using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public AudioSource audio;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                if(audio.isPlaying == false){
                    audio.clip = jumpClip;
                    audio.Play();
                }
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
        audio.clip = deathClip;
        audio.Play() ;
    }
}
