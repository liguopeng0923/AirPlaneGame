using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Trap : MonoBehaviour
    {
        private float speed = 1f;
        private float timer = 0f;//陷阱存在时间

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, 0, speed);//控制图片旋转
            timer += Time.deltaTime;
            //陷阱存在时间为10s
            if (timer > 5f)
            {
                Destroy(gameObject);
            }
        }

        //检测玩家是否进入陷阱
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //飞机进入陷阱，速度减半
            if (collision.transform.tag == "Player")
            {
                collision.GetComponent<PlaneController>().speed = collision.GetComponent<PlaneController>().speed / 3f;
            }
        }

        //检测玩家是否离开陷阱范围
        private void OnTriggerExit2D(Collider2D collision)
        {
            //飞机离开陷阱，速度恢复
            if (collision.transform.tag == "Player")
            {
                collision.GetComponent<PlaneController>().speed = collision.GetComponent<PlaneController>().speed * 3f;
            }
        }
    }
}