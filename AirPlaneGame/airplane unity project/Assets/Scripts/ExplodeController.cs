using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeController : MonoBehaviour
{

    void Update()
    {
        //爆炸动画显示0.4s消失
        Destroy(gameObject, 0.4f);
    }
}
