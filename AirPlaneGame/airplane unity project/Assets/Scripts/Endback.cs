using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Endback : MonoBehaviour
{

    public GameObject menu;
    public GameObject Shop;

    public GameObject SingleGame;
    public GameObject GameUI;
    public GameObject UICamera;
    //public GameObject myPlane;
    public GameObject bgMusic;
    public GameObject WinUI;
    public GameObject DefeatUI;


    public void back()
    {
        
        StartShop.endbalance = StartShop.endbalance + StartGame.selfPlane.score;
        Shop.SetActive(false);
        SingleGame.SetActive(false);
        //GameUI.SetActive(false);
        UICamera.SetActive(false);
        bgMusic.SetActive(false);
        WinUI.SetActive(false);
        DefeatUI.SetActive(false);
        menu.SetActive(true);
    }

}
