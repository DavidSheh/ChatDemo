using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class AppFacade : Facade
{
    private static AppFacade instance;
    private bool isStarUp = false;
    public AppFacade()
        : base()
    {
    }

    public static AppFacade getInstance()
    {
        if (instance == null)
        {
            instance = new AppFacade();
        }
        return instance;
    }

    public void StartUp()
    {
        if (!isStarUp)
        {
            SendNotification(NotiConst.START_UP);
            isStarUp = true;
        }
    }

    public void RegisterMultiCommand(SimpleCommand commandClassRef, params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RegisterCommand(notificationName[i], commandClassRef.GetType());
        }
    }

    public void RegisterMultiCommand(System.Type commandType, params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RegisterCommand(notificationName[i], commandType);
        }
    }

    public void RemoveMultiCommand(params string[] notificationName)
    {
        int count = notificationName.Length;
        for (int i = 0; i < count; i++)
        {
            RemoveCommand(notificationName[i]);
        }
    }

    override protected void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotiConst.START_UP, typeof(StartUpCommand));
        RegisterCommand(NotiConst.MENU_OPEN, typeof(MenuOpenCommand));
        RegisterMultiCommand(new ChatCommand(), NotiConst.SEND_INFO,
NotiConst.SEND_PUBLIC_INFO);

    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new ChatProxy()); //注册聊天委托
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new ChatMediator(ChatWindow.Instance)); //注册Mediator
    }
}

