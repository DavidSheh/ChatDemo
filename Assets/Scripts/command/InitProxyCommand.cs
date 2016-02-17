using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

/// <summary>
/// proxy注册类
/// </summary>
public class InitProxyCommand : SimpleCommand
{
    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        base.Execute(notification);

        // TODO: 初始化本地数据
    }
}
