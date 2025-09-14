using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    public GameObject panelPause;
    public Transform player;
    //public Transform arm1;
    //public Transform arm2;
    //public TMP_Text coinText;

    private void Start()
    {
        PauseOn(false);
        //coinText.text = "0";
    }

    private void Update()
    {
        //if (player.transform.position.y < -20)
        //{
        //    Lose();
        //}
    }

    //Метод паузы
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PauseOn(bool isActive)
    {
        if (isActive)
        {
            Time.timeScale = 0f;
            player.GetComponent<Player>().enabled = false;
            panelPause.SetActive(true);
            //arm1.GetComponent<Poit_to_mouse>().enabled = false;
            //arm2.GetComponent<Poit_to_mouse>().enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            player.GetComponent<Player>().enabled = true;
            //panelPause.SetActive(false);                                   //Включить, когда будет менюшка
            //arm1.GetComponent<Poit_to_mouse>().enabled = true;
            //arm2.GetComponent<Poit_to_mouse>().enabled = true;
        }
    }

    //Перезагружаем текущую сцену
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Загрузке сцены

}