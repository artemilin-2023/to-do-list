namespace TaskManager.Domain
{
    public class Board
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }

        public Board(Guid id, string name, Guid userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }
    }
}
