namespace TaskManager.Domain
{
    public class Comment
    {   
        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public Guid UserId { get; private set; }
        public Guid BoardId { get; private set; }

        public Comment(Guid id, string message, Guid userId, Guid boardId)
        {
            Id = id;
            Message = message;
            UserId = userId;
            BoardId = boardId;
        }
    }
}
