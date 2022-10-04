using System;
using System.Collections;
using System.Collections.Generic;
using _CheatConsole.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralCommandController : MonoBehaviour
{
    private Commands _allCommands;
    private void Start() => CreateCommands();
    private void CreateCommands()
    {
        _allCommands = new Commands();
        
        Create("freeze", _allCommands.FreezeTime);
        Create("unfreeze", _allCommands.UnfreezeTime);
        Create("restart", _allCommands.Restart);
        Create("next", _allCommands.LoadNextScene);
    }

    private void Create(string id, Action command, string description = "", string format = "")
    {
        CheatConsoleManager.CreateCommand(id, command, description, format);
    }

}