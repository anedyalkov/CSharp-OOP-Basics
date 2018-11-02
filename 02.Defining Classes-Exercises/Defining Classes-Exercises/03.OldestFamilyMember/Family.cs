using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> persons;

        public List<Person> Persons
        {
            get { return this.persons; }
            set { this.persons = value; }
        }

        public Family()
        {
            this.Persons = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.Persons.Add(member);
        }

        public Person GetOldestMember()
        {
           var person = Persons.OrderByDescending(p => p.Age).FirstOrDefault();

            return person;
        }


    }
}
