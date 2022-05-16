namespace Task2.DataLayer
{
    public class State
    {
        public Catalog Book { get; }
        public bool Available = true;

        public State(Catalog book)
        {
            Book = book;
        }

        /// <summary>
        /// Change the avaibility of the book
        /// </summary>
        public void ChangeState()
        {
            if (Available)
            {
                Available = false;
            }
            else
            {
                Available = true;
            }
        }
    }
}
