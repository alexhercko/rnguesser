using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RNGuesser.Core
{
    public class RelayCommandAsync : ICommandAsync
    {
        private readonly ObservableCollection<Task> _runningTasks;
        public IEnumerable<Task> RunningTasks => _runningTasks;

        private readonly Func<object, Task> _executeAsync;
        private readonly Predicate<object> _canExecute;

        private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommandAsync(Func<object, Task> executeAsync, Predicate<object> canExecute = null)
        {
            if (executeAsync == null)
            {
                throw new ArgumentNullException(nameof(executeAsync));
            }

            _executeAsync = executeAsync;
            _canExecute = canExecute;

            _runningTasks = new ObservableCollection<Task>();
            _runningTasks.CollectionChanged += OnRunningTasksChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        async void ICommand.Execute(object parameter)
        {
            Task runningTask = ExecuteAsync(parameter);
            _runningTasks.Add(runningTask);

            try
            {
                await runningTask;
            }
            finally
            {
                _runningTasks.Remove(runningTask);
            }
        }

        public Task ExecuteAsync(object parameter)
        {
            return _executeAsync(parameter);
        }
    }
}
