using System.Collections.Generic;

namespace bmerketo.Models.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string? TagTitle { get; set; }

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();
    }
}