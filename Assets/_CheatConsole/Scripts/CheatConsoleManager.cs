using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatConsoleManager : MonoBehaviour
{
    public static CheatConsoleManager Instance;

    [Header("Console Shortcut")] public KeyCode consoleKey = KeyCode.BackQuote;

    [Header("Commands")] [SerializeField] private List<CommandData> commandData;

    [Header("Elements")] [SerializeField] public ConsoleElements consoleElements;

    private CheatConsole _cheatConsole;

    private void Awake() => Initialize();
    private void OnEnable() => _cheatConsole.AddListeners();
    private void OnDisable() => _cheatConsole.RemoveListeners();
    private void Update()
    {
        if (Input.GetKeyDown(consoleKey))
        {
            _cheatConsole.ToggleConsole();
            _cheatConsole.SetInput("");
            _cheatConsole.ClearInputText();
        }
    }
    
    
    // USE THIS TO CREATE COMMANDS.
    public static void CreateCommand(string id, Action Command, string description = "", string format = "")
    {
        Instance._cheatConsole.CreateCommand(id, Command, description, format);
    }

    //
    private void InitCheatConsole()
    {
        _cheatConsole = new CheatConsole(commandData, consoleElements);
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