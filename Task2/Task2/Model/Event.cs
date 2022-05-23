namespace Task2.Presentation.Model
{
    public abstract class Event
    {
        public State state { get; set; }
        public User user { get; set; }
        public string description { get; set; }
    }

    public class Borrowing : Event
    {
        /// <summary>
        /// Event to borrow a book
        /// </summary>
        /// <param name="state">The state of the book</param>
        /// <param name="User">The user</param>
        public Borrowing(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Borrowed";
        }

    }
   
    public class Returning : Event
    {
        /// <summary>
        /// Returning the book
        /// </summary>
        /// <param name="state">State of the book</param>
        /// <param name="User">The user</param>
        public Returning(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Returned";
        }

    }
}