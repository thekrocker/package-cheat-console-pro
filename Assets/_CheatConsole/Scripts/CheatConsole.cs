using System;
using System.Collections;
using System.Collections.Generic;
using _CheatConsole.Scripts;
using UnityEngine;

public class CheatConsole : MonoBehaviour
{
    public KeyCode consoleKey;

    private bool _showConsole;

    private string _input;

    public static DebugCommand TEST_DEBUG;

    private List<object> _commandList;

    private void Awake()
    {
        TEST_DEBUG = new DebugCommand("test", "testing..", "test", () => { Debug.Log("Testing.."); });

        _commandList = new List<object>
        {
            TEST_DEBUG
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(consoleKey)) ToggleConsole();
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!_showConsole) return;
            
            HandleInput();
            _input = "";
        }
    }

    private void HandleInput()
    {
        for (int i = 0; i < _commandList.Count; i++)
        {
            BaseCommand command = _commandList[i] as BaseCommand;
        }
        
        
        
    }

    private void ToggleConsole()
    {
        _showConsole = !_showConsole;
    }

    private void OnGUI()
    {
        if (!_showConsole) return;

        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        _input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), _input);
    }
}