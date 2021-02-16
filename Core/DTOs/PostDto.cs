using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class PostDto
    {
        public PostDto(){
            Comments = new HashSet<Comment>();

}
    public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
