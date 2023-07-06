using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozaiForms.Helpers
{
    public class AppendableTaskWorker
    {
        private Task _task = null;

        public event Action OnStarted;
        public event Action<Task> OnCompleted;

        public AppendableTaskWorker()
        {
        }

        internal void Run(Func<Task, Task> onRun)
        {
            Task previous;

            if (_task == null || _task.IsCompleted)
            {
                previous = Task.CompletedTask;
            }
            else
            {
                previous = _task;
            }

            Task next = onRun(previous);

            _task = next;

            OnStarted?.Invoke();

            next.GetAwaiter().OnCompleted(
                () =>
                {
                    if (ReferenceEquals(next, _task))
                    {
                        OnCompleted?.Invoke(next);
                    }
                }
            );
        }
    }
}
