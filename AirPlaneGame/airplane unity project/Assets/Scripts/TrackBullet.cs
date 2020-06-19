using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{

    public class TrackBullet : SelfBullet
    {
        float xb, yb, vb; //初始最大价值敌机的位置
        float coolingtime = 0; //技能冷却时间
        int flag = 0;
        public TrackBullet()
        {
            this.speedSelfBullet = 8f;
        }

        private void Start()
        {
            GameObject[] obj; //开头定义GameObject数组 
                              //GameObject tmp;
            obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //关键代码，获取所有gameobject元素给数组obj

            foreach (GameObject child in obj)    //遍历所有gameobject
            {
                //Debug.Log(child.gameObject.name);  //可以在unity控制台测试一下是否成功获取所有元素
                if (child.gameObject.tag == "Enemy3")    //价值排序是enemyplane1 < enemyplane2 < boss
                {
                    flag = 3;
                    vb = 0;
                    xb = child.gameObject.transform.position.x;
                    yb = child.gameObject.transform.position.y;
                    break;
                }
                else if (child.gameObject.tag == "Enemy2")
                {
                    if (flag >= 2) continue;
                    flag = 2;
                    vb = 4;
                    xb = child.gameObject.transform.position.x;
                    yb = child.gameObject.transform.position.y;
                }
                else if (child.gameObject.tag == "Enemy1")
                {
                    if (flag >= 1) continue;
                    flag = 1;
                    vb = 5;
                    xb = child.gameObject.transform.position.x;
                    yb = child.gameObject.transform.position.y;
                }
            }
        }

        private void Update()
        {
            //已知追踪子弹的初始x方向的速度，追踪子弹和最大价值的飞机的初始位置，
            //最大价值的飞机的速度，可以求出追踪子弹的y方向的速度,即speedSelfBullety
            float t = System.Math.Abs(xb - transform.position.x) / (speedSelfBullet + vb);
            speedSelfBullety = (yb - transform.position.y) / t;
            transform.Translate(speedSelfBullet * Time.deltaTime, speedSelfBullety * Time.deltaTime*2f, 0);
            if (transform.position.x > 11)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Enemy1" || collision.transform.tag == "Enemy2" || collision.transform.tag == "Enemy3")
            {
                collision.GetComponent<EnemyPlane>().health = 0f;
                Destroy(gameObject);
            }
        }
    }
}