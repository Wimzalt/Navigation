using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Hurt, Shoot;
    static AudioSource audioSrc;

    void Start()
    {
        Hurt = Resources.Load<AudioClip>("Hurt");
        Shoot = Resources.Load<AudioClip>("Shoot");
        

        audioSrc = GetComponent<AudioSource> ();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Hurt":
                audioSrc.PlayOneShot (Hurt);
                break;
            case "Shoot":
                audioSrc.PlayOneShot (Shoot);
                break;
            
        }
    }

   

   
}
