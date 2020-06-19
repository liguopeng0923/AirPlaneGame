using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [HideInInspector]
        public GameObject[] Enemies;//敌方飞机
        float timer = 0f;//时间
        public static  float updateTimer=1.5f;//更新飞机时间
        void Start()
        {

        }
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= updateTimer)
            {
                CreateEnemy();
                timer = 0;
            }
            
        }

        void CreateEnemy()
        {
            //随机生成敌机
            int x = Random.Range(0, 10);
            int index = 0;
            if (x >= 9)
                index = 2;
            else if (x < 3)
                index = 1;
           Instantiate(Enemies[index], new Vector3(9.6f, Random.Range(-4.2f, 4.2f), 0), Quaternion.identity);
        }
    }
}
