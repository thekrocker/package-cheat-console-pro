using System;
using UnityEngine;

namespace _CheatConsole.Scripts
{
    public class DebugCommand : BaseCommand
    {
        private Action _commandAction;

        public DebugCommand(string id, string description, string format, Action commandAction) : base(id, description,
            format)
        {
            _commandAction = commandAction;
        }

        public void Invoke()
        {
            _commandAction?.Invoke();
        }
    }
    
    
}