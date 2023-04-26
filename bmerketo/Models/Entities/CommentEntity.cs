namespace bmerketo.Models.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime CommentCreated { get; set; }

        public int ContactsId { get; set; }
        public ContactEntity Contacts { get; set; } = null!;

        public static implicit operator CommentModel(CommentEntity entity)
        {
            return new CommentModel
            {
                Id = entity?.Id,
                Comment = entity?.Comment,
            };
        }
    }
}
