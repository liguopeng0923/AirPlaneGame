using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backmainmnue2 : MonoBehaviour
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
        /*
         backmenu()负责返回主页面，从商店返回和机型选择返回都是这里负责，数据库关闭的操作要放在这里，由于
         无法判断是从商店返回还是从机型选返回，不能将两个数据库关闭操作全放在这里。
         否则会造成未进入商店而关闭其数据库链接；或者未进入机型选择而关闭其数据库链接,


        *********************建议改成两个脚本，一个从商店返回，一个从机型选择中返回*****************************
         */
         

        //********************此操作应放在从选择飞机返回脚本中↓↓↓↓↓↓↓↓
        SelectPlane.Sql.CloseConnection();//关闭飞机选择中的数据库连接

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
