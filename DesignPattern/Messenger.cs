using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public class Messenger
    {
        private IDictionary<string, Func<IEnumerable<string>, ICommand>> _commmands = new Dictionary<string, Func<IEnumerable<string>, ICommand>>()
        {
            { "SayHello", args => new SayHelloCommand(args) },
            { "SayGoodbye", args => new SayHelloCommand(args) },
        };
        
        public Message CreateMessage(string input)
        {
            var commandName = "SayHello";
            var command = _commmands[commandName](new[]{"a", "b"});
            command.Execute();


            return new Message()
            {
                IsCommand = input.Substring(0, 1) == "/",
                From = input.Substring(1).Split("/")[0],
                Target = "all"
            };
        }
    }

    public class Message
    {
        public bool IsCommand { get; set; }
        public string From { get; set; }
        public string Target { get; set; }
    }
}