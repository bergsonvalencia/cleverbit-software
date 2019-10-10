using System;
using System.Collections.Generic;

namespace CleverbitSoftware.WebApi.Integration.Dtos
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int? Year { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
