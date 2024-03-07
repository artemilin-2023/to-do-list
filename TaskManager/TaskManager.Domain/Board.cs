namespace TaskManager.Domain
{
    public class Board
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid UserId { get; private set; }

        public Board(Guid id, string name, Guid userId)
        {
            Id = id;
            Title = name;
            UserId = userId;
        }

        public Board() { }
    }
}
