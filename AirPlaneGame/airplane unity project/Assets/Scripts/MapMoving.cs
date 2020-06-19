using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    public class MapMoving : MonoBehaviour
    {
        private float speed = 2f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //背景移动
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
            Vector3 position = transform.position;

            if (position.x < 856.5f)
            {
                transform.position = new Vector3(position.x + 34f, position.y, position.z);
            }
        }
    }
}