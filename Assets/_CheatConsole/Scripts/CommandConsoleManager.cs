using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(GeneralCommandController))]
public class CommandConsoleManager : MonoBehaviour
{
    public static CommandConsoleManager Instance;

    [Header("Console Shortcut")] public KeyCode consoleKey = KeyCode.BackQuote;

    [Header("Commands")] [SerializeField] private List<CommandData> commandData;

    [Header("Elements")] [SerializeField] public ConsoleElements consoleElements;

    private CommandConsole _commandConsole;

    private void Awake() => Initialize();
    private void OnEnable() => _commandConsole.AddListeners();
    private void OnDisable() => _commandConsole.RemoveListeners();
    private void Update()
    {
        if (Input.GetKeyDown(consoleKey))
        {
            _commandConsole.ToggleConsole();
            _commandConsole.SetInput("");
            _commandConsole.ClearInputText();
        }
    }
    
    
    // USE THIS TO CREATE COMMANDS.
    public static void CreateCommand(string id, Action Command, string description = "", string format = "")
    {
        Instance._commandConsole.CreateCommand(id, Command, description, format);
    }

    //
    private void InitCheatConsole()
    {
        _commandConsole = new CommandConsole(commandData, consoleElements);
    }
    private void CreateInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Initialize()
    {
        CreateInstance();
        InitCheatConsole();
    }

}