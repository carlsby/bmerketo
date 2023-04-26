using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }

        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();

        public static implicit operator ContactModel(ContactEntity entity)
        {
            return new ContactModel
            {
                FullName = entity?.FullName,
                Email = entity?.Email,
                PhoneNumber = entity?.PhoneNumber,
                Company = entity?.Company,
            };
        }
    }
}
