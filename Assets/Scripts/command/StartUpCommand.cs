using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class StartUpCommand : MacroCommand
{

    protected override void InitializeMacroCommand()
    {
        base.InitializeMacroCommand();
        AddSubCommand(typeof(InitProxyCommand));
    }
}
