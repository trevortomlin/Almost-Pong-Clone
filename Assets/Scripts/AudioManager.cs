using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] sounds;

    public AudioClip musicClip;

    public bool musicOn = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (musicOn) {

            AudioSource musicAS = gameObject.AddComponent<AudioSource>();

            musicAS.loop = true;
            musicAS.clip = musicClip;
            musicAS.Play();

        }

        foreach (Sound s in sounds) {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }

    }

    public void Play(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    
    }

}
