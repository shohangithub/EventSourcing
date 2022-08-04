using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public class EventBroker
    {
        // 1. Event Storage , Store All Events
        IList<Event> eventList = new List<Event>();
        // 2. Commands
        event EventHandler<Command> Commands;
        // 3. Queries
        event EventHandler<Query> Queries;

        void Command(Command c) => Commands?.Invoke(this, c);
    }
}
