using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    internal class EventBroker
    {
        // 1. Event Storage , Store All Events
        public IList<Event> eventList = new List<Event>();
        // 2. Commands
        public event EventHandler<Command> Commands;
        // 3. Queries
        public event EventHandler<Query> Queries;

        public void Command(Command c) => Commands?.Invoke(this, c);

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T)q.Result;
        }
        public void UndoLast()
        {
            var e = eventList.LastOrDefault();
            var ac = e as AgeChangedEvent;
            if(ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.Oldvalue) { Register = false });
                eventList.Remove(e);
            }
        }
    }
}
