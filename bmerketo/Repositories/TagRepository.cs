using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class TagRepository : Repo<TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}
