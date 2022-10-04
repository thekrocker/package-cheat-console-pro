using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]


public class CheatConsoleV2 : MonoBehaviour
{
    [SerializeField] private CommandData[] commandData;

    public CommandData[] CommandData => commandData;

    // Console properties

    public KeyCode consoleKey;
    private bool _showConsole;
    private string _input;


    private void Update()
    {
        if (Input.GetKeyDown(consoleKey)) ToggleConsole();
    }

    private void ToggleConsole()
    {
        _showConsole = !_showConsole;
    }

    private Vector2 scroll;

    private void OnGUI()
    {
        if (!_showConsole) return;

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 100), "");
        
        Rect viewPort = new Rect(0, 0, Screen.width - 30, 20 * commandData.Length);

        scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewPort);

        for (int i = 0; i < commandData.Length; i++)
        {
            CommandData command = commandData[i];
            
            string label = $"{command.format} - {command.description}";

            Rect labelRect = new Rect(5, 20 * i, viewPort.width - 100, 20);
            GUI.Label(labelRect, label);
        }
        
        GUI.EndScrollView();

        y += 100;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        GUI.SetNextControlName("console");
        _input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), _input);
        GUI.FocusControl("console");

        if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
        {
            HandleInput();
            _input = "";
        }
    }

    private void HandleInput()
    {
        foreach (CommandData cheat in commandData)
        {
            string cheatId = cheat.id;
            if (_input.Contains(cheatId))
            {
                cheat.RaiseEvent();
            }
            else
            {
                Debug.LogWarning($"{cheat} is not a valid command!");
            }
        }
    }
}