using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public GameObject menu;
    public GameObject SingleGame;
    public GameObject UICamera;
    // public GameObject myPlane;
    public GameObject bgMusic;
    public GameObject GameUI;
    public GameObject shop;
    public GameObject ChoosePlanes;
    public GameObject WinUI;
    public GameObject DefeatUI;
    public GameObject lifebarBG;
    //public GameObject lifeBar;//血量条
    public GameObject pausebtn;
    public GameObject pauseUI;
    public GameObject modeUI;
    public Text describedText;
    public GameObject chooseMode;

    private SqliteHelper Sql;


    public PlaneController [] Plane;//己方飞机
    public static PlaneController selfPlane;//实例化的己方飞机
    // Start is called before the first frame update
    void Start()
    {
        SingleGame.SetActive(false);
        UICamera.SetActive(false);
        //myPlane.SetActive(false);
        bgMusic.SetActive(false);
        //GameUI.SetActive(false);
        shop.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void entryMode()
    {
        menu.SetActive(false);
        ChoosePlanes.SetActive(false);
        modeUI.SetActive(true);
    }


    public void entryGame(GameObject sender)
    {
        Sql = new SqliteHelper("data source=sqlite4unity.db");//连接数据库
        Sql.UpdateValues("Game", new string[] { "Score" }, new string[] { ("'" + "0" + "'").ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());//将分数置0
        Sql.CloseConnection();//关闭数据库连接

        describedText.text = "";
        menu.SetActive(false);
        modeUI.SetActive(false);
        ChoosePlanes.SetActive(false);
        SingleGame.SetActive(true);
        UICamera.SetActive(true);
        //myPlane.SetActive(true);
        bgMusic.SetActive(true);
        lifebarBG.SetActive(true);
        //lifeBar.SetActive(true);
        pausebtn.SetActive(true);
        pauseUI.SetActive(false);
        WinUI.SetActive(false);
        DefeatUI.SetActive(false);
        //刷新时间和生命值
        GameObject.Find("SingleGame").GetComponent<GameManager>().lifeBar.fillAmount = 1f;
        GameObject.Find("SingleGame").GetComponent<GameManager>().survivalTime = 0;

        switch (sender.name)
        {
            case "ButtonEasy":
                GameManager.successTime = 10f;
                EnemyController.updateTimer = 1.5f;//飞机生成频率
                EnemyPlane.updateTimer = 1.5f;//子弹更新频率
                //GameManager.map = "bg1";
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage1.sprite = Resources.Load("bgImage/bg1", typeof(Sprite)) as Sprite;
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage2.sprite = Resources.Load("bgImage/bg1", typeof(Sprite)) as Sprite;
                break;
            case "ButtonUsual":
                GameManager.successTime = 20f;
                EnemyController.updateTimer = 1.0f;//飞机生成频率
                EnemyPlane.updateTimer = 1.0f;//子弹更新频率
                //GameManager.map = "bg2";
                //加载地图
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage1.sprite = Resources.Load("bgImage/bg2" , typeof(Sprite)) as Sprite;
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage2.sprite = Resources.Load("bgImage/bg2", typeof(Sprite)) as Sprite;
                break;
            case "ButtonHard":
                GameManager.successTime = 30f;
                EnemyController.updateTimer = 0.5f;//飞机生成频率
                EnemyPlane.updateTimer = 0.5f;//子弹更新频率
                //GameManager.map = "bg3";
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage1.sprite = Resources.Load("bgImage/bg3", typeof(Sprite)) as Sprite;
                GameObject.Find("SingleGame").GetComponent<GameManager>().bgImage2.sprite = Resources.Load("bgImage/bg3", typeof(Sprite)) as Sprite;
                break;
            default:
                break;
        }
        //transform.GetComponent<GameManager>().pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        if (selfPlane == null)
        {

            if (SelectPlane.IsdefaultplaneChosen == true)
            {
                selfPlane = Instantiate(Plane[0], new Vector3(-8f, 0f, 0f), Quaternion.identity);
              
            }
            else if (SelectPlane.IsheliChosen == true)
            {
                selfPlane = Instantiate(Plane[1], new Vector3(-8f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                selfPlane = Instantiate(Plane[2], new Vector3(-8f, 0f, 0f), Quaternion.identity);
                
            }
            
        }
    }
}
