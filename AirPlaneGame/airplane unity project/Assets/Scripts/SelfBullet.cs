using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBullet : MonoBehaviour
{
    
    public int sizeSelfBullet;//子弹大小
    public float speedSelfBullet;//子弹速度 x方向
    public float speedSelfBullety;//子弹速度 y方向
    public int powerSelfBullet;//子弹攻击力
    public int BulletCost;
    int flag = 0;
    //flag的作用
    //1. 当前界面最有价值的是enemyplane1
    //2. 当前界面最有价值的是enemyplane2
    //3. 当前界面最有价值的是boss

    public SelfBullet()
    {
        this.speedSelfBullet = 10;
    }

    public SelfBullet(int sizeSelfBullet, int speedSelfBullet, int powerSelfBullet)
    {
        this.sizeSelfBullet = sizeSelfBullet;
        this.speedSelfBullet = speedSelfBullet;
        this.powerSelfBullet = powerSelfBullet;
    }

    private void Start()
    {
        /*GameObject[] obj; //开头定义GameObject数组 
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
            else if(child.gameObject.tag == "Enemy2")
            {
                if (flag >= 2) continue;
                flag = 2;
                vb = 4;
                xb = child.gameObject.transform.position.x;
                yb = child.gameObject.transform.position.y;
            }else if(child.gameObject.tag == "Enemy1")
            {
                if (flag >= 1) continue;
                flag = 1;
                vb = 5;
                xb = child.gameObject.transform.position.x;
                yb = child.gameObject.transform.position.y;
            }
        }*/
    }

    private void Update()
    {
        transform.Translate(speedSelfBullet * Time.deltaTime, 0, 0);
        if (transform.position.x > 11)
            Destroy(gameObject);
    }
}
