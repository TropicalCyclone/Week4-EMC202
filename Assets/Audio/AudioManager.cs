using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            if(!s.random)
            {
                s.audioSource.pitch = s.pitch;
            }
            s.audioSource.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BackgroundMusic");
    }

    public void Play(string name)
    {
       Sound S = Array.Find(sounds, sound => sound.name == name);
        
        foreach (Sound s in sounds)
        {
            if (s.random)
            {
                s.audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            }
        }
        S.audioSource.Play();
    }

    public void Stop(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);

        S.audioSource.Stop();
    }

}
