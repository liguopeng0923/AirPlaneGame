using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlane : MonoBehaviour
{


    public GameObject menu;
    public GameObject ChoosePlanes;

    public GameObject SingleGame;
    //public GameObject GameUI;
    public GameObject UICamera;
    //public GameObject myPlane;
    //public GameObject lifebar;
    public GameObject lifebg;
    public GameObject pausebtn;
    public GameObject bgMusic;
    //public GameObject pauseUI;

    public static SqliteHelper Sql;
    

    public static bool IsdefaultplaneChosen = true;
    public static bool IsheliChosen = false;
    public static bool IsbombChosen = false;

    public static bool IsdefaultbulletChosen = true;
    public static bool IsSoccerChosen = false;
    public static bool IsbasketballChosen = false;

    public Text tip;
    public Text bullettip;


    public void entryChoose()
    {
        Sql = new SqliteHelper("data source=sqlite4unity.db");
        menu.SetActive(false);
        SingleGame.SetActive(false);
        //GameUI.SetActive(false);
        UICamera.SetActive(false);
        //myPlane.SetActive(false);
        //lifebar.SetActive(false);
        lifebg.SetActive(false);
        pausebtn.SetActive(false);
        bgMusic.SetActive(false);
        //pauseUI.SetActive(false);
        ChoosePlanes.SetActive(true);

        if(IsheliChosen == true)
        {
            tip.text = "飞机已选择：直升飞机";
        }
        else if(IsbombChosen == true)
        {
            tip.text = "飞机已选择：歼击机";
        }
        else
        {
            tip.text = "飞机已选择：默认飞机。";
        }

        if(IsSoccerChosen == true)
        {
            bullettip.text = "子弹已选择：足球子弹。";
        }
        else if(IsbasketballChosen == true)
        {
            bullettip.text = "子弹已选择：篮球子弹。";
        }
        else
        {
            bullettip.text = "子弹已选择：默认子弹。";
        }
    }

    public void chooseheli()
    {
        SqliteDataReader GetheliReader = Sql.ReadTable("Game", new string[] { "Getheli" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        StartShop.Getheli = bool.Parse(GetheliReader[0].ToString());
        if (StartShop.Getheli == true)
        {
            if(IsheliChosen==false)
            {
                IsheliChosen = true;
                IsdefaultplaneChosen = false;
                IsbombChosen = false;
                tip.text = "飞机已选择：直升飞机";
            }
        }
        else
        {
            tip.text = "尚未购买该飞机，请先前往商店购买。";
        }
    }

    public void choosebomb()
    {
        SqliteDataReader GetbombReader = Sql.ReadTable("Game", new string[] { "Getbomb" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        StartShop.Getbomb = bool.Parse(GetbombReader[0].ToString());
        if (StartShop.Getbomb == true)
        {
            if(IsbombChosen==false)
            {
                IsbombChosen = true;
                IsdefaultplaneChosen = false;
                IsheliChosen = false;
                tip.text = "飞机已选择：歼击机";
            }
        }
        else
        {
            tip.text = "尚未购买该飞机，请先前往商店购买。";
        }
    }

    public void choosedefaultplane()
    {
        if(IsdefaultplaneChosen == false)
        {
            IsdefaultplaneChosen = true;
            IsheliChosen = false;
            IsbombChosen = false;
            tip.text = "飞机已选择：默认飞机。";
        }
    }

    public void ChooseSoccer()
    {
        SqliteDataReader GetscoreReader = Sql.ReadTable("Game", new string[] { "Getscore" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        StartShop.Getscore = bool.Parse(GetscoreReader[0].ToString());
        if (StartShop.Getscore == true)
        {
            if(IsSoccerChosen == false)
            {
                IsSoccerChosen = true;
                IsdefaultbulletChosen = false;
                IsbasketballChosen = false;
                bullettip.text = "子弹已选择：足球子弹。";
            }
        }
        else
        {
            bullettip.text = "尚未购买该子弹，请先前往商店购买。";
        }
    }

    public void choosebasketball()
    {
        SqliteDataReader GetbasketballReader = Sql.ReadTable("Game", new string[] { "Getbomb" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        StartShop.Getbasketball = bool.Parse(GetbasketballReader[0].ToString());
        if (StartShop.Getbasketball == true)
        {
            if (IsbasketballChosen == false)
            {
                IsbasketballChosen = true;
                IsdefaultbulletChosen = false;
                IsSoccerChosen = false;
                bullettip.text = "子弹已选择：篮球子弹。";
            }
        }
        else
        {
            bullettip.text = "尚未购买该子弹，请先前往商店购买。";
        }
    }

    public void choosedefaultbullet()
    {
        if(IsdefaultbulletChosen == false)
        {
            IsdefaultbulletChosen = true;
            IsSoccerChosen = false;
            IsbasketballChosen = false;
            bullettip.text = "子弹已选择：默认子弹。";
        }
    }

    public void PointEnterheli()
    {
        if(IsheliChosen==true)
        {
            tip.text = "已选择该飞机。";
        }
        else
        {
            tip.text = "点击选择该飞机。";
        }
    }
    public void PointEnterbomb()
    {
        if (IsbombChosen == true)
        {
            tip.text = "已选择该飞机。";
        }
        else
        {
            tip.text = "点击选择该飞机。";
        }
    }

    public void PointEnterdefaultplane()
    {
        if (IsdefaultplaneChosen == true)
        {
            tip.text = "已选择该飞机。";
        }
        else
        {
            tip.text = "点击选择该飞机。";
        }
    }

    public void PointEnterSoccer()
    {
        if(IsSoccerChosen == true)
        {
            bullettip.text = "已选择该子弹。";
        }
        else
        {
            bullettip.text = "点击选择该子弹。";
        }
    }

    public void PointEnterbasketball()
    {
        if (IsbasketballChosen == true)
        {
            bullettip.text = "已选择该子弹。";
        }
        else
        {
            bullettip.text = "点击选择该子弹。";
        }
    }

    public void PointEnterdefaultbullet()
    {
        if (IsdefaultbulletChosen == true)
        {
            bullettip.text = "已选择该子弹。";
        }
        else
        {
            bullettip.text = "点击选择该子弹。";
        }
    }

    public void Exit()
    {
        if(IsheliChosen == true)
        {
            tip.text = "飞机已选择：直升飞机。";
        }
        else if(IsbombChosen == true)
        {
            tip.text = "飞机已选择：歼击机。";
        }
        else
        {
            tip.text = "飞机已选择:默认飞机。";
        }
    }

    public void bulletExit()
    {
        if(IsSoccerChosen == true)
        {
            bullettip.text = "子弹已选择：足球子弹。";
        }
        else if(IsbasketballChosen == true)
        {
            bullettip.text = "子弹已选择：篮球子弹。";
        }
        else
        {
            bullettip.text = "子弹已选择：默认子弹。";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
