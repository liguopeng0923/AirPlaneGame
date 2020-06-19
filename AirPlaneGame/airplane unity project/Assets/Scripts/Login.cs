using UnityEngine;
using System.Collections;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Login : MonoBehaviour, IPointerClickHandler
{
    public InputField UserName;

    public InputField Password;

    public Text LoginMessage;

    public GameObject LoginPanel;

    public GameObject RegisterPanel;

    private SqliteHelper sql;

    public static string Name;

    void Start()
    {
        sql = new SqliteHelper("data source=sqlite4unity.db");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress.name == "Login")
        {     //如果当前按下的按钮是登录按钮 
            OnClickedLoginButton();
        }
        else if(eventData.pointerPress.name=="Register")
        {      //如果按下注册按钮
            OnClickedRegisterButton();

        }
    }

    public void OnClickedLoginButton()
    {
        if (string.IsNullOrEmpty(UserName.text))
        {
            ShowTip("请输入用户名");
            return;
        }
        if (!string.IsNullOrEmpty(Password.text))
        {
            SqliteDataReader UsernameReader = sql.ReadTable("Game", new string[] { "UserName" }, new string[] { "`" + "UserName" + "`", "`" + "Password" + "`" }, new string[] { "=", "=" }, new string[] { ("'" + UserName.text.ToString() + "'").ToString(), ("'" + Password.text.ToString() + "'").ToString() });

            if (UsernameReader.HasRows)
            {
                ShowTip("登陆成功！！！");
                LoginPanel.SetActive(false);
                RegisterPanel.SetActive(false);
                //关闭数据库连接
                sql.CloseConnection();
                return;
            }
            else
            {
                ShowTip("登陆失败！！！");
                return;
            }
        }
        else
        {
            ShowTip("请输入密码！！！");
            return;
        }

        //关闭数据库连接
        sql.CloseConnection();
    }

    void Update()
    {
        Name = UserName.text.ToString();
    }

    public void OnClickedRegisterButton()
    {
        LoginPanel.SetActive(false);
    }

    //显示提示
    private void ShowTip(string _content)
    {
        LoginMessage.text = string.Format("<color=#FF0000>{0}</color>", _content);
    }
}
