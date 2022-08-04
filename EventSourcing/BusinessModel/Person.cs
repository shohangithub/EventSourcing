using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    internal class Person
    {
        private int age;
        EventBroker broker;

        public Person(EventBroker broker)
        {
            this.broker = broker;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;



            void BrokerOnCommands(object sender, Command command)
            {
                var cac = command as ChangeAgeCommand;
                if (cac != null && cac.Target == this)
                {
                   if(cac.Register) broker.eventList.Add(new AgeChangedEvent(cac.Target,age,cac.Age));
                    age = cac.Age;
                }
            }

            void BrokerOnQueries(object sender, Query query)
            {
                var aq = query as AgeQuery;
                if (aq != null && aq.Target == this)
                {
                   aq.Result = age;
                }
            }


        }

        public int Id { get; set; }
    }
}
