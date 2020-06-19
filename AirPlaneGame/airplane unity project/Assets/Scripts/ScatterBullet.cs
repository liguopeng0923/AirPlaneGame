using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ScatterBullet : MonoBehaviour
{
    public float scatShotSpeed;
    public int sizeSelfBullet;//子弹大小
    public int powerSelfBullet;//子弹攻击力

    public GameObject[] scatShot;

    public ScatterBullet()
    {
        this.scatShotSpeed = 1;
    }

    public ScatterBullet(int scatShotSpeed, int sizeSelfBullet, int powerSelfBullet)
    {
        this.sizeSelfBullet = sizeSelfBullet;
        this.scatShotSpeed = scatShotSpeed;
        this.powerSelfBullet = powerSelfBullet;
    }

    private void Start()
    {

    }
    private void Update()
    {
        Update1();
        Update2();
        Update3();
        /*最后在PlaneController实例化三个对象
         *   Instantiate(scatterBullets[0], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
             Instantiate(scatterBullets[1], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
             Instantiate(scatterBullets[2], new Vector3(position.x + 0.8f, position.y, position.z), Quaternion.identity);
                        */
    }
    //存在if(true)判断是为了防止卡帧
    //存在三个Update函数，且不能合并否则无法实现散弹效果
    void Update1()
    {
        if (true)
        {
            float scatShotSpeedy = 8;
            scatShot[0].gameObject.transform.Translate(scatShotSpeed * Time.deltaTime, scatShotSpeedy * Time.deltaTime, 0);
            //散弹中第一颗子弹速度方向斜向上方
            if (transform.position.x > 11)
            {
                Destroy(gameObject);
            }
        }
        /*
        transform.Translate(scatShotSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x > 11)
            Destroy(gameObject);
            */
    }
    void Update2()
    {
        if (true)
        {
            float scatShotSpeedy = 1;
            scatShot[1].gameObject.transform.Translate(scatShotSpeed * Time.deltaTime, scatShotSpeedy * Time.deltaTime, 0);
            //散弹中第二颗子弹速度方向正前方
            if (transform.position.x > 11)
            {
                Destroy(gameObject);
            }
        }
        /*
        transform.Translate(scatShotSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x > 11)
            Destroy(gameObject);
            */
    }
    void Update3()
    {
        if (true)
        {
            float scatShotSpeedy = -8;
            scatShot[2].gameObject.transform.Translate(scatShotSpeed * Time.deltaTime, scatShotSpeedy * Time.deltaTime, 0);
            //散弹中第三颗子弹速度方向斜向下方
            if (transform.position.x > 11)
            {
                Destroy(gameObject);
            }
        }
    }


}

