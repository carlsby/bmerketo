using bmerketo.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bmerketo.Services;

public class TagService
{
    private readonly TagRepository _tagRepo;

    public TagService(TagRepository tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var tags = new List<SelectListItem>();

        foreach (var item in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.TagTitle,
            });
        }
        return tags;
    }

    public async Task<List<SelectListItem>> GetTagsAsync(string[]? selectedTags = null)
    {
        var tags = new List<SelectListItem>();

        foreach (var item in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.TagTitle,
                Selected = selectedTags!.Contains(item.Id.ToString()),
            });
        }
        return tags;
    }
}
