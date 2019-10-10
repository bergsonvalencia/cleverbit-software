using System.Collections.Generic;
using SharedKernel.CleverbitSoftware;

namespace ArticleManagement.Infrastructure.Data.Entities
{
    public class Article : AggregateRoot
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int? Year { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
