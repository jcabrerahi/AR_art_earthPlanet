using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystem : MonoBehaviour
{
    public static soundSystem instance;
    public AudioClip audioClip;       
    public AudioSource audioSource;

    private void Awake()
    {
        if (soundSystem.instance == null)
        {
            soundSystem.instance = this;
        }
        else if (soundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
  

    private void OnDestroy()
    {
        soundSystem.instance = null;
    }
}
