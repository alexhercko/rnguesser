using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RNGuesser.Core
{
    public interface ICommandAsync : ICommand
    {
        IEnumerable<Task> RunningTasks { get; }
        Task ExecuteAsync(object parameter);
    }
}
