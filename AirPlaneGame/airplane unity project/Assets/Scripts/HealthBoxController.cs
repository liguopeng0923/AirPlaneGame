using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxController : MonoBehaviour
{
    float timer = 0f;//时间
    float updateTimer = 2;//降落生命盒时间
    public GameObject[] HealthBoxs;//生命盒子
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateTimer)
        {
            CreateHealthBoxs();
            timer = 0;
        }

    }

    void CreateHealthBoxs()
    {
        //随机生成生命盒
        int x = Random.Range(0, 15);
        int index = 0;
        if (x == 15)
            index = 2;
        else if (x < 5)
            index = 1;
        Instantiate(HealthBoxs[index], new Vector3(Random.Range(-11f, 11f),6f, 0), Quaternion.identity);
    }
}
