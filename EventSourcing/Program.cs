// See https://aka.ms/new-console-template for more information

using EventSourcing;

var eb = new EventBroker();
var p = new Person(eb);
eb.Command(new ChangeAgeCommand(p, 123));

foreach (var e in eb.eventList)
{
    Console.WriteLine(e);
}
int age;
age = eb.Query<int>(new AgeQuery { Target = p });
Console.WriteLine(age);

eb.UndoLast();
foreach (var e in eb.eventList)
{
    Console.WriteLine(e);
}

age = eb.Query<int>(new AgeQuery { Target = p });
Console.WriteLine(age);


Console.ReadKey();
