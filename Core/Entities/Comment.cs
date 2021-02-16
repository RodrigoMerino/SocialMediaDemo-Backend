using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Comment:BaseEntity
    {
        //public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public bool IsActived { get; set; }

        public virtual Post PostIdNavigation { get; set; }
        public virtual User UserIdNavigation { get; set; }
    }
}
