using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private static AudioManager _shared;

    private void Awake()
    {
        if (!_shared)
        {
            _shared = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        LoadSounds();
    }

    // this func "loads" a sound by creating an audio source for the given clip 
    private void LoadSounds()
    {
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.spatialBlend = 0f;
        }
    }

    // this func plays a sound using its name
    public void PlaySound(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.soundName == soundName);
        sound?.audioSource.Play();
    }

    // this func plays a sound using its name
    public void PlayDelaySound(string soundName, float delay)
    {
        var sound = Array.Find(sounds, sound => sound.soundName == soundName);
        sound?.audioSource.PlayDelayed(delay);
    }

    // this func pauses a sound using its name
    public void PauseSound(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.soundName == soundName);
        sound?.audioSource.Pause();
    }
}