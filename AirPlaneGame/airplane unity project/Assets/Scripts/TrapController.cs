using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private float timer = 5f;//时间
    private float updateTimer = 8f;//更新陷阱时间
    public GameObject Trap;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateTimer)
        {
            CreateTrap();
            timer = 0f;
        }
    }

    void CreateTrap()
    {
        //随机生成陷阱
        Instantiate(Trap, new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), 2), Quaternion.identity);
    }
}

