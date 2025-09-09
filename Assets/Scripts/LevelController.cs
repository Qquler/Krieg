using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    private float waitTime1 = 0.5f;
    private int g = 0;
    public GameObject panelPause;
    public Transform player;
    public Transform arm1;
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
        
        if (Input.GetKeyDown(KeyCode.Escape) && g == 0)
        {
            PauseOn(true);
            g = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && g == 1 && Input.GetKey(KeyCode.Escape))
            {
                PauseOn(false);
                StartCoroutine(Waiting1());
            }

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
            player.GetComponent<FireController>().enabled = false;
            panelPause.SetActive(true);
            arm1.GetComponent<Poit_to_mouse>().enabled = false;
            //arm2.GetComponent<Poit_to_mouse>().enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<FireController>().enabled = true;
            panelPause.SetActive(false);
            arm1.GetComponent<Poit_to_mouse>().enabled = true;
            //arm2.GetComponent<Poit_to_mouse>().enabled = true;
        }
    }

    //Перезагружаем текущую сцену
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Загрузке сцены
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime1); //строка ожидания
            g = 1;
        
           
        
    }
    IEnumerator Waiting1()
    {
        yield return new WaitForSeconds(waitTime1); //строка ожидания
       

        g = 0;

    }
}