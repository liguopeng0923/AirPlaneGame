using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlaneController : MonoBehaviour
    {
        
        //public string planeType = "selfPlane4";
        public SelfBullet [] selfBullet;//子弹类型
        public TrackBullet trackBullet;//追踪导弹
        public ScatterBullet[] scatterBullets;//散弹
        public ShockWave shockWave;//冲击波
        public float health;//初始血量
        public float currentHealth;//当前血量
        public float speed = 5f;//飞机运行的速度
        public GameObject boom;//显示爆炸效果
        [HideInInspector]
        public float score = 0;//得分
        public bool isAlive = true;//玩家飞机是否存活
        [HideInInspector]
        public GameManager Game;
        [HideInInspector]
        public float coolingtime = 0f; //追踪导弹冷却时间
        public int waveTimes = 1;//冲击波剩余次数

        // Start is called before the first frame update
        void Start()
        {
            Game = GameObject.Find("SingleGame").GetComponent<GameManager>();
            
            currentHealth = health;
            //transform.GetComponent<SpriteRenderer>().sprite = Resources.Load("typeplane/"+planeType, typeof(Sprite)) as Sprite;
        }

        void Update()
        {
            //设置飞机移动方向
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            //GameObject[] obj; //开头定义GameObject数组  

            //控制飞机移动范围
            if (transform.position.y <= -4.6)//超出下方边界时
                if (y < 0)//禁止向下移动
                    y = 0;
            if (transform.position.y >= 4.6)//超出上方边界时
                if (y > 0)//禁止向上移动
                    y = 0;
            if (transform.position.x <= -8.2)//超出左边界时
                if (x < 0)//禁止向左移动
                    x = 0;
            if (transform.position.x >= 8.2)//超出右边界时
                if (x > 0)//禁止向右移动
                    x = 0;
            //飞机移动
            transform.Translate(new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0));

            //获取当前飞机位置
            Vector3 position = transform.position;

            //追踪导弹冷却恢复
            if(coolingtime <= 5f)
                coolingtime += Time.deltaTime;

            //发生追踪导弹
            if (Input.GetKeyDown(KeyCode.J) && coolingtime > 5f)
            {
                coolingtime = 0f;//重置技能冷却时间
                Game.ClearEnergy();//清空能量条
                //实例化导弹
                Instantiate(trackBullet, new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
            }

            //按空格发射子弹
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                position = transform.position;
                //实例化子弹并设置初始位置
                if (SelectPlane.IsdefaultbulletChosen == true)
                {
                    Instantiate(selfBullet[0], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                }
                else if (SelectPlane.IsSoccerChosen == true)
                {
                    Instantiate(selfBullet[1], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                }
                else
                {//散弹的三个子弹实例化
                    Instantiate(scatterBullets[0], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                    Instantiate(scatterBullets[1], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                    Instantiate(scatterBullets[2], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                }
            }

            //按K键释放冲击波
            if (Input.GetKeyDown(KeyCode.K) && waveTimes > 0)
            {
                waveTimes--;
                Game.skillUsed();
                Instantiate(shockWave, new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
            }

            /*
            if (Input.GetKeyDown(KeyCode.J))
            {
                obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj
                foreach (GameObject child in obj)    //遍历所有gameobject
                {
                    //Debug.Log(child.gameObject.name);  //可以在unity控制台测试一下是否成功获取所有元素
                    if (child.gameObject.tag == "Enemy3" )    //进行操作
                    {
                        //child.gameObject.SetActive(false);
                        Destroy(child.gameObject);
                    }
                }
            }
            */
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "enemybullet"|| collision.transform.tag == "bossbullet")//与玩家的子弹发生碰撞
            {
                float damage = collision.GetComponent<EnemyBullet>().powerEnemyBullet + EnemyBullet.addPowerEnemyBullet;
                this.currentHealth -= damage;//生命值-敌方子弹伤害
                Game.ReduceHealth(damage,health);//改变血条
                Destroy(collision.gameObject);//碰撞后子弹消失
            }
            if(collision.transform.tag == "healthbox")
            {
                if (this.currentHealth + collision.GetComponent<HealthBox>().health <= health)
                {
                    this.currentHealth += collision.GetComponent<HealthBox>().health;//生命值+盒子携带的生命值
                    //lifeBar.fillAmount += collision.GetComponent<HealthBox>().health / health;//改变血条
                    Game.AddHealth(collision.GetComponent<HealthBox>().health, health);
                    Destroy(collision.gameObject);//碰撞后盒子消失
                }
                else if(this.currentHealth + collision.GetComponent<HealthBox>().health >= health)
                {
                    this.currentHealth = health;
                    //lifeBar.fillAmount = 1f;
                    Game.FillHealth();
                    Destroy(collision.gameObject);//碰撞后盒子消失
                }
            }
            if (currentHealth <= 0)
            {
                Destroy(gameObject);//飞机爆炸
                StartGame.selfPlane.isAlive = false;
                Instantiate(boom, transform.position, Quaternion.identity);//显示爆炸动画
            }
        }
    }
}