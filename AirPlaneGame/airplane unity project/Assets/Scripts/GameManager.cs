using Assets.Scripts;
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ctrl 
namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        //用于循环
        public Image bgImage1;//背景图片
        public Image bgImage2;//背景图片
        public AudioSource bgMusic;//背景音乐
        [HideInInspector]
        
        public GameObject gameOver;//游戏结束界面
        //static public string map;//地图
        public static float successTime;//通关需要的存活时间
        public float survivalTime;//当前存活时间
        SelfBullet bullet ;//收到的子弹类型
        public GUIStyle scoregs;//得分框
        public GUIStyle timegs;//倒计时框
        public GUIStyle lifegs;//生命值框
        public GUIStyle Energygs;//能量框
        public GUIStyle Skillgs;//终极技能框
        public Image lifeBar;//血量条
        public Image EnergyBar;//能量条
        public Image SkillTag;//终极技能提示
        public GameObject pauseMenu;//暂停菜单
        public GameObject WinUI;//胜利界面
        public GameObject DefeatUI;//失败界面
        private  SqliteHelper Sql;


        void Start()
        {
            

            //successTime = 60f;
            /*
            AirPlane myPlane = new AirPlane("selfplane1");
            pc = GameObject.Find("Player").GetComponent<PlaneController>();
            pc.myPlane = myPlane;
            */
            //map获取由上一个界面传来的地图，设置背景图片。
            /*
            bgImage1.sprite = Resources.Load("bgImage/" + map, typeof(Sprite)) as Sprite;
            bgImage2.sprite = Resources.Load("bgImage/" + map, typeof(Sprite)) as Sprite;
            */
        }

        private void Update()
        {
            survivalTime += Time.deltaTime;
            if(survivalTime >= successTime && StartGame.selfPlane.isAlive)
            {

                if (StartGame.selfPlane != null)
                    Destroy(StartGame.selfPlane.gameObject);
                GameObject[] obj;
                obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
                foreach (GameObject child in obj)    //遍历所有gameobject
                {
                    if (child.tag == "enemybullet" || child.tag == "bullet" || child.tag == "bossbullet" || child.tag == "Enemy1" || child.tag == "Enemy2" || child.tag == "Enemy3" || child.tag == "healthbox")
                        Destroy(child);
                }
                Sql = new SqliteHelper("data source=sqlite4unity.db");//连接数据库
                WinUI.SetActive(true);
                survivalTime = 0;
                successTime = 0;
                FreshData();//更新数据库中的数据
            }
            if(!StartGame.selfPlane.isAlive)
            {
                GameObject[] obj;
                obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
                foreach (GameObject child in obj)    //遍历所有gameobject
                {
                    if (child.tag == "enemybullet" || child.tag == "bullet" || child.tag == "bossbullet" || child.tag == "Enemy1" || child.tag == "Enemy2" || child.tag == "Enemy3" || child.tag == "healthbox")
                        Destroy(child);
                }
                Sql = new SqliteHelper("data source=sqlite4unity.db");
                DefeatUI.SetActive(true);
                survivalTime = 0;
                successTime = 0;
                FreshData();//更新数据库的数据
            }
            //恢复能量
            if (EnergyBar.fillAmount <= 1)
                EnergyBar.fillAmount += Time.deltaTime / 5f;
        }

        //展示得分框
        private void OnGUI()
        {
            GUI.Label(new Rect(600,10,200,100), "分数：" + StartGame.selfPlane.score ,scoregs);//得分
            GUI.Label(new Rect(20, 6, 100, 40), "生命值", lifegs);
            if (successTime - survivalTime >= 0) 
            GUI.Label(new Rect(800, 10, 200, 100), "倒计时："+(successTime-survivalTime).ToString("0.0"), timegs);
            else
            GUI.Label(new Rect(750, 10, 200, 100), "倒计时：" + (0.00).ToString("0.0"), timegs);
            GUI.Label(new Rect(35, 45, 100, 40), "能量", Energygs);
            GUI.Label(new Rect(420, 6, 100, 40), "终极技能", Skillgs);
        }

        //暂停游戏
        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        //返回游戏
        public void BackGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        //扣血
        public void ReduceHealth(float damage,float totalHealth)
        {
            lifeBar.fillAmount -= damage / totalHealth;
        }

        //加血
        public void AddHealth(float addBlood,float totalHealth)
        {
            lifeBar.fillAmount += addBlood / totalHealth;
        }

        //加满血
        public void FillHealth()
        {
            lifeBar.fillAmount = 1;
        }

        //清空能量
        public void ClearEnergy()
        {
            EnergyBar.fillAmount = 0f;
        }

        //更新数据库
        public void FreshData()
        {
            float Gold;
            float Score;

            SqliteDataReader GoldReader = Sql.ReadTable("Game", new string[] { "Gold" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });

            SqliteDataReader ScoreReader = Sql.ReadTable("Game", new string[] { "Score" }, new string[] { "UserName" }, new string[] { "=" }, new string[] { ("'" + Login.Name + "'").ToString() });


            Gold = float.Parse(GoldReader[0].ToString());
            Score = float.Parse(ScoreReader[0].ToString());
            Gold += Score ;
            Sql.UpdateValues("Game", new string[] { "Gold" }, new string[] { ("'" + Gold.ToString() + "'").ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());

            Sql.CloseConnection();
        }

        
        public void skillUsed()
        {
            SkillTag.color = Color.gray;
        }
    }

}

