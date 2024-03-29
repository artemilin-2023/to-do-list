﻿namespace TaskManager.Domain
{
    public class Issue
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }
        public Guid BoardId { get; private set; }
        public IssueStatus Status { get; private set; }

        public Issue(Guid id,string description, DateTime creationTime, Guid boardId, IssueStatus status)
        {
            Id = id;
            Description = description;
            CreationTime = creationTime;
            BoardId = boardId;
            Status = status;
        }

        public Issue() { }
    }
}
