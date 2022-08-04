using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    internal class AgeChangedEvent : Event
    {
        public Person Target;
        public int Oldvalue, NewValue;
        public AgeChangedEvent(Person target, int oldvalue, int newValue)
        {
            Target = target;
            Oldvalue = oldvalue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age Changed from {Oldvalue} to {NewValue}.";
        }
    }
}
