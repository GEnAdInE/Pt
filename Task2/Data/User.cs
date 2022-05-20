namespace Task2.DataLayer
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
