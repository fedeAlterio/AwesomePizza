using System.Transactions;

namespace AwesomePizza.Application.Actions.Abstractions;

public interface ICommand;

public class IsolationLevelAttribute(IsolationLevel isolationLevel) : Attribute
{
    public IsolationLevel IsolationLevel { get; } = isolationLevel;
}