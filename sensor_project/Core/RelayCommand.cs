using System.Windows.Input;

/*
 * Define um comando que pode ser executado por um controle de interface do usuário (UI) para realizar uma ação específica.
 * O comando pode ser associado a um evento de controle de interface do usuário, como um botão, para executar a ação quando o evento ocorrer.
 */

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?> _canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action<object?> execute, Predicate<object?> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
