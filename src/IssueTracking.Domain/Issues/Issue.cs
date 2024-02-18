using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace IssueTracking.Issues
{
    public class Issue : AggregateRoot<Guid>,  IHasCreationTime
    {
        public Guid RepositoryId { get; private set; }
        public string? Text { get; private set; }
        public string? Title { get; set; }
        public Guid? AssignedUserId { get; set; }
        public bool IsClosed { get; private set; }
        public bool IsLocked { get; private set; }
        public IssueCloseReason? CloseReason { get; private set; }
        public ICollection<IssueLabel> Labels { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
        public DateTime CreationTime { get; set;  }
        public DateTime? LastCommentTime{ get; set;  }

        public Issue(Guid id, Guid repositoryId, string title, string? text = null, Guid? assignedUserId = null) : base(id)
        {
            RepositoryId = repositoryId;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Text = text;
            AssignedUserId = assignedUserId;
            Labels = [];
            Comments = [];
        }

        public void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        }

        public void Close(IssueCloseReason reason)
        {
            IsClosed = true;
            CloseReason = reason;
        }

        public void ReOpen()
        {
            if (IsLocked)
            {
                throw new IssueStateException("IssueTracking:CanNotOpenLockedIssue");
            }

            IsClosed = false;
            CloseReason = null;
        }
        public void Lock()
        {
            if (!IsClosed)
            {
                throw new IssueStateException("Can not lock an open issue! Close it first.");
            }

            IsClosed = false;
            CloseReason = null;
        }

        public void Unlock()
        {
            IsLocked = false;
        }


        public void AddComment(Guid userId, string? text)
        {
            Comments.Add(new Comment { UserId = userId, Text = text, IssueId = Id });
        }

        private Issue() { }
    }
}