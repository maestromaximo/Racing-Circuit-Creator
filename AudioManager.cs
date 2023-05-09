using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    private void Start()
    {
        int songChoice = UnityEngine.Random.Range(1, 5);
        //Debug.Log(songChoice);
        if(songChoice == 1)
        {
            FindObjectOfType<AudioManager>().Play("Track 1");
        }
        else if(songChoice == 2)
        {
            FindObjectOfType<AudioManager>().Play("Track 2");
        }
        else if(songChoice == 3)
        {
            FindObjectOfType<AudioManager>().Play("Track 3");
        }
        else if(songChoice == 4)
        {
            FindObjectOfType<AudioManager>().Play("Track 4");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Track 1");
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound name not found: "+ name + " .");
            return;
        }
        s.source.Play();

    }//Play

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound name not found: " + name + " .");
            return;
        }
        s.source.Stop();
    }//StopPlaying

    public void ChangeVolume(string name, float intencity)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound name not found: " + name + " .");
            return;
        }
        if(intencity > 1f)
        {
            intencity = 1f;
        }else if(intencity < 0f)
        {
            intencity = 0f;
        }
        s.source.volume = intencity;

    }//ChangeVolume
}
//FindObjectOfType<AudioManager>().Play("name");