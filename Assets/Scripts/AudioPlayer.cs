using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip pref1; // è ò. ä.
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(AudioClip audioClip, float volume = 1, string type = "No_Type")
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
    public void PlayPref1()
    {
        PlayAudio(pref1);
    }
}
