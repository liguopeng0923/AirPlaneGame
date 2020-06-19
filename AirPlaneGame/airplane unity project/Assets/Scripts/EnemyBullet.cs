using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    public int intSpeedEnemyBullet;//子弹速度初始值
    public int intPowerEnemyBullet;//子弹攻击力初始值
    public float speedEnemyBullet;//子弹速度
    public float powerEnemyBullet;//敌方子弹伤害
    public static float addSpeedEnemyBullet;//子弹速度增量
    public static float addPowerEnemyBullet;//子弹攻击力增量

    public Text TextDescribe;

    public void EnterEasy()
    {
        //显示
        TextDescribe.text = "简单模式下：\n敌机子弹攻击速度=8\n敌机子弹攻击力量=50\n游戏通关时长：10秒";
    }
    public void EnterReg()
    {
        //显示
        TextDescribe.text = "普通模式下：\n敌机子弹攻击速度增加：2\n敌机子弹攻击伤害增加：10\n游戏通关时长：20秒";
    }
    public void EnterHard()
    {
        //显示
        TextDescribe.text = "困难模式下：\n敌机子弹攻击速度增加：4\n敌机子弹攻击力量增加：20\n游戏通关时长：30秒";
    }
    public void useEasy()
    {
        addSpeedEnemyBullet = 0;//子弹速度增加值
        addPowerEnemyBullet = 0;//子弹伤害增加值
    }
    public void useUsual()
    {
        addSpeedEnemyBullet = 0.1f;//子弹速度增加值
        addPowerEnemyBullet = 50;//子弹伤害增加值
    }
    public void useHard()
    {
        addSpeedEnemyBullet = 0.1f;//子弹速度增加值
        addPowerEnemyBullet = 100;//子弹伤害增加值
    }
    public void Exit()
    {
        TextDescribe.text = "";
    }
    void Update()
    {
        transform.Translate(-(speedEnemyBullet + addSpeedEnemyBullet) * Time.deltaTime , 0, 0);
        if (transform.position.x <-11)
            Destroy(gameObject);
    }
}
