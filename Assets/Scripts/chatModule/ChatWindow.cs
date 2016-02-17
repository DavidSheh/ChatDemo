using UnityEngine;
using System.Collections;

public class ChatWindow : MonoBehaviour
{
    public static ChatWindow Instance;

    public UITextList textList;
    public UIInput mInput;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        AppFacade.getInstance().StartUp(); //启动
    }

    public void SendMsg()
    {
        if (textList != null)
        {
            string text = NGUIText.StripSymbols(mInput.value);
            if (!string.IsNullOrEmpty(text))
            {
                mInput.value = "";
                mInput.isSelected = false;
                Debug.Log("UI发送聊天信息：" + text);
                AppFacade.getInstance().SendNotification(NotiConst.SEND_INFO, text);
            }
        }
    }

    public void ReturnServerHander(string str)
    {
        Debug.Log("来自Mediator的返回，刷新UI界面");
        textList.Add(str);
    }

    public void ReturnPrivateMsg(object obj)
    {
        Debug.Log(obj);
    }
}
