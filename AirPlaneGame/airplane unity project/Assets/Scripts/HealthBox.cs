using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;//生命值盒
    public int speedHealthBox;//生命盒子降落速度
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-speedHealthBox * Time.deltaTime, 0, 0);
        if (transform.position.y < -6)
            Destroy(gameObject);
    }
}
