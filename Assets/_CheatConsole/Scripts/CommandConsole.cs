using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommandConsole
{
    private List<CommandData> _commandData;
    private ConsoleElements _consoleElements;

    private string _input;

    public CommandConsole(List<CommandData> commandData, ConsoleElements elements)
    {
        _commandData = commandData;
        _consoleElements = elements;
    }

    public void CreateCommand(string id, Action Command, string description = "", string format = "")
    {
        UnityEvent action = new();
        action.AddListener(Command.Invoke);
        
        _commandData.Add(new CommandData()
        {
            id = id,
            description = description,
            format = format,
            OnInput = action
        });
    }

    public void ReadInput(string s)
    {
        if (s.Length == 0) return;

        SetInput(s);
        HandleInput();
    }

    public void AddListeners()
    {
        _consoleElements.inputField.onEndEdit.AddListener(ReadInput);
    }

    public void RemoveListeners()
    {
        _consoleElements.inputField.onEndEdit.RemoveListener(ReadInput);
    }


    public void SetInput(string s)
    {
        _input = s;
    }

    private int _failCount;

    private void HandleInput()
    {
        _failCount = 0;

        if (_commandData.Count == 0)
        {
            AddFailedText();
            SetInput("");
            ClearInputText();
            return;
        }

        foreach (CommandData command in _commandData)
        {
            string lowered = _input.ToLower();
            string commandId = command.id.ToLower();

            if (!lowered.Equals(commandId))
            {
                _failCount++;
            }
            else
            {
                AddTextToConsole(_input);
                AddSuccessText();
                command.RaiseEvent();
                break;
            }
        }

        if (AllCommandsFailed()) AddFailedText();

        SetInput("");
        ClearInputText();
    }

    private bool AllCommandsFailed() => _failCount >= _commandData.Count;

    public void AddTextToConsole(string s)
    {
        _consoleElements.consoleText.text += "\n" + s;
        _consoleElements.scrollRect.verticalNormalizedPosition = 0f;
    }

    public void ToggleConsole()
    {
        _consoleElements.consoleCanvas.SetActive(!_consoleElements.consoleCanvas.activeInHierarchy);
        if (_consoleElements.consoleCanvas.activeInHierarchy) ActivateInputField();
    }

    public void ClearInputText()
    {
        _consoleElements.inputField.text = "";
        ActivateInputField();
    }

    private void ActivateInputField()
    {
        _consoleElements.inputField.ActivateInputField();
    }

    public void AddSuccessText(string s = "")
    {
        AddTextToConsole("Command success!");
    }

    public void AddFailedText()
    {
        AddTextToConsole($"There is no command : {_consoleElements.inputField.text} ");
    }
}