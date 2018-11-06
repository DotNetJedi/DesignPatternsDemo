using System;
using System.Text;
using FluentAssertions;
using Xunit;

namespace DesignPattern.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("/ben/*/distress/true", "ben", "all")]
        [InlineData("/eric/*/distress/true", "eric", "all")]
        public void Test_if_message_is_a_command(string input, string from, string target)
        {
            // Arrange
            var messenger = new Messenger();
            
            // Act
            var message = messenger.CreateMessage(input);
            // messenger.Send(message);
            
            // Assert
            message.Should().BeOfType<Message>();
            message.IsCommand.Should().BeTrue();
            message.From.Should().Be(from);
            message.Target.Should().Be(target);
        }

        [Fact]
        public void Test_if_message_is_not_a_command()
        {
            // Arrange
            var input = "This is not a command";
            var messenger = new Messenger();
            
            // Act
            var message = messenger.CreateMessage(input);
            // messenger.Send(message);
            
            // Assert
            message.Should().BeOfType<Message>();
            message.IsCommand.Should().BeFalse();
        }
    }
}
