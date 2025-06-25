using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Coin : MonoBehaviour
    {
    public AudioSource audioSource;
    public AudioClip sound1;
    public GameObject cameraObject;
        LevelController levelController;
    public int g = 1;

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            levelController = cameraObject.GetComponent<LevelController>();

            if (collision.gameObject.tag == "Player" && g==1)
            {
            g = 0;
            PlayAudio(sound1);
            levelController.coinText.text =
                     (int.Parse(levelController.coinText.text) + 10).ToString();
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);
                Destroy(this.gameObject);
            }
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

