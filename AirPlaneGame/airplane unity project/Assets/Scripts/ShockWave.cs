using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class ShockWave : MonoBehaviour
    {
        private float waveSpeed = 8f;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(waveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x > 11)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Enemy1" || collision.transform.tag == "Enemy2" || collision.transform.tag == "Enemy3")
            {
                collision.GetComponent<EnemyPlane>().health = 0;
            }
        }
    }
}