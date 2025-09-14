
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //библиотека компонентов интерфейса
using TMPro;//Для текста Text Mesh Pro

public class AmmosCount : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    private FireController fc;
    private Player pl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fc = GetComponent<FireController>();
        pl = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    
        
        //sprintf(str, "%d", ammo);
        text.text = "Ammos: " + fc.ammo.ToString(); 
        text2.text = "HP " + pl.CurHP().ToString(); 
    }
}
