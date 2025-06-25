using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip sound1, sound2; // è ò. ä.
    [SerializeField] MenuController menuController;
    private void Start()
    {
        PlayerPrefs.GetFloat(menuController.SOUND);
    }
    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void PlaySound()
    {
        PlayAudio(sound1);
    }
}
