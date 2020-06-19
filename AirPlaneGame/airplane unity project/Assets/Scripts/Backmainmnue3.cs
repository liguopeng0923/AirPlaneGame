using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backmainmnue3 : MonoBehaviour
{
    public GameObject menu;
    public GameObject Shop;
    public GameObject ChoosePlane;
    public GameObject pauseMenu;
    public GameObject SingleGame;
    //public GameObject GameUI;
    public GameObject UICamera;
    //public GameObject myPlane;
    public GameObject bgMusic;

    public void backmenu()
    {
        Time.timeScale = 3f;
        if (StartGame.selfPlane != null)
        {
            Destroy(StartGame.selfPlane.gameObject);
        }
        Shop.SetActive(false);
        ChoosePlane.SetActive(false);
        SingleGame.SetActive(false);
        //GameUI.SetActive(false);
        UICamera.SetActive(false);
        //myPlane.SetActive(false);
        bgMusic.SetActive(false);
        menu.SetActive(true);
        GameObject[] obj; //开头定义GameObject数组 
        //GameObject tmp;
        obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
        foreach (GameObject child in obj)    //遍历所有gameobject
        {
            if (child.tag == "enemybullet" || child.tag == "bullet" || child.tag == "bossbullet" || child.tag == "Enemy1" || child.tag == "Enemy2" || child.tag == "Enemy3" || child.tag == "healthbox")
                Destroy(child);
        }
    }
}
