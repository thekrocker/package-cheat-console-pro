namespace _CheatConsole.Scripts
{
    public class BaseCommand
    {
        private string _commandId;
        private string _commandDescription;
        private string _commandFormat;

        public string CommandId => _commandId;
        public string CommandDescription => _commandDescription;
        public string CommandFormat => _commandFormat;

        public BaseCommand(string id, string description, string format)
        {
            _commandId = id;
            _commandDescription = description;
            _commandFormat = format;
        }
    }
}