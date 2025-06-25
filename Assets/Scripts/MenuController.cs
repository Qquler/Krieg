using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //библиотека компонентов интерфейса
using TMPro;//ƒл€ текста Text Mesh Pro

public class MenuController : MonoBehaviour
{
    public GameObject panelSetting;


    

   //Text Mesh Pro

    public AudioSource musicSource;
    public AudioSource soundSource;
    public Slider musicSlider, soundSlider;
    public TMP_Text musicText, soundText;
    public  string MUSICSOUND = "MusicSound";
    public  string SOUND = "Sound";
    // Start is called before the first frame update
    void Start()
    {
        panelSetting.SetActive(false);
        
        if (PlayerPrefs.HasKey(MUSICSOUND) && PlayerPrefs.HasKey("Sound"))
        {
            SetSettingsSound();
        }
        else
        {
            PlayerPrefs.SetFloat(MUSICSOUND, 0.5f);
            PlayerPrefs.SetFloat(SOUND, 0.5f);
            SetSettingsSound();
        }
    }
  

    public void OpenPanelSettings(bool isOpen)
    {
        panelSetting.SetActive(isOpen);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //¬ыходим из приложени€
    public void Exit()
    {
        Application.Quit();
        print(1);
    }
    private void Update()
    {
        musicText.text = musicSlider.value.ToString();
        soundText.text = soundSlider.value.ToString();

        //PlayerPrefs.HasKey("Key"); - проверка на существование записи
        //PlayerPrefs.GetFloat("Key"); - получение значени€ по ключу
        //PlayerPrefs.SetFloat("Key", 2.25f); - добавление/изменение значений
        //PlayerPrefs.DeleteKey("Key"); - удаление записи

       musicSource.volume = musicSlider.value / 100;
    }
    public void SetSettingsSound()
    {
        musicSlider.value = PlayerPrefs.GetFloat(MUSICSOUND) * 100;
        musicText.text = musicSlider.value.ToString();
        musicSource.volume = PlayerPrefs.GetFloat(MUSICSOUND);

        soundSlider.value = PlayerPrefs.GetFloat(SOUND) * 100;
        soundText.text = musicSlider.value.ToString();
        soundSource.volume = PlayerPrefs.GetFloat(SOUND);
    }
}