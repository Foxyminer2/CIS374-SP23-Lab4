

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter
        {
           
            get
            {
                return Persons[Persons.Count - 1].FirstName[0];
            }


        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        public bool IsEmpty
        {
            get
            {
                if (Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            persons.Sort();

            
            foreach(var person in persons)
            {
                person.FirstName = char.ToUpper(person.FirstName[0]) + person.FirstName.Substring(1);
                    
            }

            var personGroups = new List<PersonGroup>();
            var currentGroup = new PersonGroup();


            foreach (var person in persons)
            {
                

                if (currentGroup.IsEmpty )
                {
                    currentGroup.Persons.Add(person);
                }
                else
                {
                    if (currentGroup[0].Distance(person) < distance)
                    {
                        currentGroup.Persons.Add(person);
                    }
                    else
                    {
                        personGroups.Add(currentGroup);
                        currentGroup = new PersonGroup();
                        currentGroup.Persons.Add(person);
                    }
                }
            }

            if (currentGroup.IsEmpty == false)
            {
                personGroups.Add(currentGroup);
            }

            // This isn't correct code. 
            // It's is just a sample of how to interact with the classes.
            //var group1 = new PersonGroup();
            //var group2 = new PersonGroup();

            //foreach (var person in persons)
            //{
            //    if (person.FirstName.StartsWith("K"))
            //    {
            //        group1.Persons.Add(person);
            //    }
            //    else
            //    {
            //        group2.Persons.Add(person);
            //    }
            //}

            //personGroups.Add(group1);
            //personGroups.Add(group2);

            

            return personGroups;
        }

    }
}
