using System;
using System.Windows.Input;

namespace PersonsDb.GuiApp.Commands;

public class LambdaCommand : ICommand
{
    private readonly Func<bool> _canExecute;
    private readonly Action _execute;

    public LambdaCommand(Action execute, Func<bool>? canExecute = null)
    {
        _canExecute = canExecute ?? (() => true);
        _execute = execute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke();
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}