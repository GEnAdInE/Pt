namespace Task2.Presentation.Model
{
    public class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public User(string name, string surname)
        {
            this.Surname = surname;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name + " | " + Surname;
        }

    }
}
