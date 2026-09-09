using System;
using System.Collections.Generic;
public class TakingTurnsQueue {
    private readonly List<Person> _people = new();
    public int Length => _people.Count;
    public void AddPerson(string name, int turns) {
        _people.Add(new Person(name, turns));
    }
    public Person GetNextPerson() {
        if (_people.Count == 0) throw new InvalidOperationException("No one in the queue.");
        Person person = _people[0];
        _people.RemoveAt(0);
        if (person.Turns > 1) {
            person.Turns--;
            _people.Add(person);
        } else if (person.Turns <= 0) {
            _people.Add(person);
        }
        return person;
    }
}
