using System;
using _CheatConsole.Scripts;
using UnityEngine;

public class GeneralCommandController : MonoBehaviour
{
    private Commands _allCommands;
    private void Start() => CreateCommands();
    private void CreateCommands()
    {
        _allCommands = new Commands();
        
        Create("freeze", _allCommands.FreezeTime, "freezing the time");
        Create("unfreeze", _allCommands.UnfreezeTime);
        Create("restart", _allCommands.Restart);
        Create("next", _allCommands.LoadNextScene);
        Create("Quit", _allCommands.Quit);
    }

    private void Create(string id, Action command, string description = "", string format = "")
    {
        CommandConsoleManager.CreateCommand(id, command, description, format);
    }

}