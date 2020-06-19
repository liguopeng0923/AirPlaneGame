using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartShop : MonoBehaviour
{
    public GameObject menu;
    public GameObject Shop;
    public GameObject ChoosePlanes;

    public GameObject SingleGame;
    //public GameObject GameUI;
    public GameObject UICamera;
    //public GameObject myPlane;
    //public GameObject lifebar;
    public GameObject lifebg;
    public GameObject pausebtn;
    //public GameObject pauseUI;
    public GameObject bgMusic;

    
    public Text Itemdescribe;
    public Text balance;
    

    static int heliprice = 1500000;
    static int bombprice = 2250000;

    static int scorebulletprice = 1000000;
    static int basketballbulletprice = 1750000;

    public static float endbalance;//余额

    public static bool Getdefaultplane ;
    public static bool Getheli;
    public static bool Getbomb ;

    public static bool Getdefaultbullet;
    public static bool Getscore;
    public static bool Getbasketball;

    public static SqliteHelper Sql;


    void Start()
    {

    }

    public void entryShop()
    {
        Sql = new SqliteHelper("data source=sqlite4unity.db");
        SqliteDataReader GoldReader = Sql.ReadTable("Game", new string[] { "Gold" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        endbalance = float.Parse(GoldReader[0].ToString());
        //balance.text = endbalance.ToString();
        menu.SetActive(false);
        ChoosePlanes.SetActive(false);
        SingleGame.SetActive(false);
        //GameUI.SetActive(false);
        //lifebar.SetActive(false);
        lifebg.SetActive(false);
        pausebtn.SetActive(false);
        UICamera.SetActive(false);
        //myPlane.SetActive(false);
        bgMusic.SetActive(false);
        //pauseUI.SetActive(false);
        Shop.SetActive(true);

        balance.text = endbalance.ToString();
    }

    public void Enterheli()
    {
        SqliteDataReader GetheliReader = Sql.ReadTable("Game", new string[] { "Getheli" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        Getheli = bool.Parse(GetheliReader[0].ToString());
        if (Getheli == false)
        {
            Itemdescribe.text = "直升机\n 价格：" + heliprice + "效果：子弹威力变成2倍。 未购买";
        }
        else
            Itemdescribe.text = "效果：子弹威力变成2倍。 已购买";
    }

    public void Enterbomb()
    {
        SqliteDataReader GetbombReader = Sql.ReadTable("Game", new string[] { "Getbomb" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        Getbomb = bool.Parse(GetbombReader[0].ToString());
        if (Getbomb == false)
        {
            Itemdescribe.text = "歼击机\n价格：" + bombprice + "效果：子弹威力变成3倍。 未购买";
        }
        else
            Itemdescribe.text = "效果：子弹威力变成3倍。 已购买";
    }

    public void Enterscore()
    {
        SqliteDataReader GetscoreReader = Sql.ReadTable("Game", new string[] { "Getscore" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        Getscore = bool.Parse(GetscoreReader[0].ToString());
        if (Getscore == false)
        {
            Itemdescribe.text = "足球子弹\n价格：" + scorebulletprice + "效果：子弹速度变为1.6倍，子弹威力变成1.5倍。 未购买";
        }
        else
            Itemdescribe.text = "效果：子弹速度变为1.6倍，子弹威力变成1.5倍。 已购买";
    }

    public void Enterbasketball()
    {
        SqliteDataReader GetbasketballReader = Sql.ReadTable("Game", new string[] { "Getbomb" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        Getbasketball = bool.Parse(GetbasketballReader[0].ToString());
        if (Getbasketball == false)
        {
            Itemdescribe.text = "篮球子弹\n价格：" + basketballbulletprice + "效果：子弹速度变为2倍，子弹威力变成2.5倍。 未购买";
        }
        else
            Itemdescribe.text = "效果：子弹速度变为2倍，子弹威力变成2.5倍。 已购买";
    }
    public void Exit()
    {
        Itemdescribe.text = "";
    }

    public void buyheli()
    {
        if (Getheli == false)
        {
            beforeUpdate();
            if (endbalance - heliprice >= 0)
            {
                endbalance = endbalance - heliprice;
                afterUpdate();
                Getheli = true;
                Sql.UpdateValues("Game", new string[] { "Getheli" }, new string[] { Getheli.ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());

                Itemdescribe.text = "效果：子弹威力变成2倍。 已购买";
            }
            else
            {
                Itemdescribe.text = "金币不足。";
            }
        }
    }
    public void buybomb()
    {
        if (Getbomb == false)
        {
            beforeUpdate();
            if (endbalance - bombprice >= 0)
            {
                endbalance = endbalance - bombprice;
                afterUpdate();
                Getbomb = true;
                Sql.UpdateValues("Game", new string[] { "Getbomb" }, new string[] { Getbomb.ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());

                Itemdescribe.text = "效果：子弹威力变成3倍。 已购买";
            }
            else
            {
                Itemdescribe.text = "金币不足。";
            }
        }
    }

    public void buyscore()
    {
        if (Getscore == false)
        {
            beforeUpdate();
            if (endbalance - scorebulletprice >= 0)
            {
                endbalance = endbalance - scorebulletprice;
                afterUpdate();
                Getscore = true;
                Sql.UpdateValues("Game", new string[] { "Getscore" }, new string[] { Getscore.ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());

                Itemdescribe.text = "效果：子弹速度变为1.6倍，子弹威力变成1.5倍。 已购买";
            }
            else
            {
                Itemdescribe.text = "金币不足。";
            }
        }
    }

    public void buybasketball()
    {
        if (Getbasketball == false)
        {
            beforeUpdate();
            if (endbalance - basketballbulletprice >= 0)
            {
                afterUpdate();
                endbalance = endbalance - basketballbulletprice;
                Getbasketball = true;
                Sql.UpdateValues("Game", new string[] { "Getbasketball" }, new string[] { Getbasketball.ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());

                Itemdescribe.text = "效果：子弹速度变为2倍，子弹威力变成2.5倍。 已购买";
            }
            else
            {
                Itemdescribe.text = "金币不足。";
            }
        }
    }

    public void beforeUpdate()
    {
        SqliteDataReader GoldReader = Sql.ReadTable("Game", new string[] { "Gold" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });
        endbalance = float.Parse(GoldReader[0].ToString());
    }

    public void afterUpdate()
    {
        Sql.UpdateValues("Game", new string[] { "Gold" }, new string[] { ("'" + endbalance.ToString() + "'").ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());
    }

    void Update()
    {
        balance.text = endbalance.ToString();
    }
}
