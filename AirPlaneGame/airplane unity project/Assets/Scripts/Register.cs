using UnityEngine;
using System.Collections;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Register : MonoBehaviour,IPointerClickHandler
{
    public InputField UserName;

    public InputField Password;

    public Text RegisterMessage;

    public GameObject LoginPanel;

    public GameObject RegisterPanel;

    private SqliteHelper sql;

    void Start()
    {
        sql = new SqliteHelper("data source=sqlite4unity.db");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress.name == "Register")
        {     //如果当前按下的按钮是登录按钮 
            OnClickedRegisterButton();
        }
        else if (eventData.pointerPress.name == "Back")
        {      //如果按下注册按钮
            OnClickedBackButton();

        }
    }

    public void OnClickedRegisterButton()
    {
        if (string.IsNullOrEmpty(UserName.text))
        {
            ShowTip("请输入用户名");
            return;
        }
        else
        {
            SqliteDataReader UsernameReader = sql.ReadTable("Game", new string[] { "UserName" }, new string[] { "`" + "UserName" + "`" }, new string[] { "=" }, new string[] { ("'" + UserName.text.ToString() + "'").ToString() });

            if (UsernameReader.HasRows)
            {
                ShowTip("用户名已存在！！！");
                return;
            }
            else
            {
                if(string.IsNullOrEmpty(Password.text))
                {
                    ShowTip("请输入密码！！！");
                    return;
                }
                else
                {
                    sql.InsertValues("Game", new string[] { ("'" + UserName.text.ToString() + "'").ToString(), ("'" + Password.text.ToString() + "'").ToString(), "6000000", "true", "true", "false", "false", "false", "false", "0" });

                    ShowTip("注册成功！！！");
                }
            }
        }
        //关闭数据库连接
        sql.CloseConnection();
    }

    public void OnClickedBackButton()
    {
        LoginPanel.SetActive(true);
    }

    //显示提示
    private void ShowTip(string _content)
    {
        RegisterMessage.text = string.Format("<color=#FF0000>{0}</color>", _content);
    }
}
