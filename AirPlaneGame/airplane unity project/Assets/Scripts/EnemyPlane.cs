using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    public class EnemyPlane : MonoBehaviour
    {
        public float speed;//敌人速度
        public float health;//敌人生命值
        private float score;//被击毁后得分
        public EnemyBullet enemyBullet;//子弹
        float timer = 0f;//时间
        public static float updateTimer = 1.5f;//更新子弹时间
        public GameObject boom;//显示爆炸效果
        public GameManager Game;
        private SqliteHelper Sql;

        void Start()
        {
            Game = GameObject.Find("SingleGame").GetComponent<GameManager>();
            score = health / 10f;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < -11)
                Destroy(gameObject);
            timer += Time.deltaTime;
            if (timer >= updateTimer)
            {
                Vector3 position = transform.position;
                //实例化子弹并设置初始位置
                Instantiate(enemyBullet, new Vector3(position.x - 0.8f, position.y, position.z), Quaternion.identity);
                timer = 0;
            }
            if (this.health <= 0)//敌机生命值小于0时
            {
                Destroy(gameObject);//飞机爆炸
                Instantiate(boom, transform.position, Quaternion.identity);//显示敌机爆炸动画
                StartGame.selfPlane.score += score;//得分增加

                Sql = new SqliteHelper("data source=sqlite4unity.db");//连接数据库
                float Score = StartGame.selfPlane.score;
                Sql.UpdateValues("Game", new string[] { "Score" }, new string[] { ("'" + Score.ToString() + "'").ToString() }, "UserName", "=", ("'" + Login.Name + "'").ToString());//更新分数
                Sql.CloseConnection();//关闭数据库连接
            }
        }

        //检测碰撞
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "bullet")//与玩家的子弹发生碰撞
            {
                this.health -= collision.GetComponent<SelfBullet>().powerSelfBullet;//生命值-子弹伤害
                Destroy(collision.gameObject);//碰撞后子弹消失
            }
            
            if (collision.transform.tag == "Player")
            {
                float damage = health / 2;
                collision.GetComponent<PlaneController>().currentHealth -= damage;
                Game.ReduceHealth(damage, collision.GetComponent<PlaneController>().health);
                this.health = 0;
            }
        }
    }
}