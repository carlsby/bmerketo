using bmerketo.Contexts;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services
{
    public class ContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateCommentAsync(ContactViewModel model)
        {
            try
            {

                var searchContact = await GetContactAsync(model.Email);
                if (searchContact != null)
                {
                    CommentEntity comments = new CommentEntity
                    {
                        Comment = model.Comment,
                        CommentCreated = DateTime.Now,
                    };

                    comments.ContactsId = searchContact.Id;
                    _context.Comments.Add(comments);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ContactEntity contactEntity = new()
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Company = model.Company,
                    };

                    CommentEntity commentEntity = new()
                    {
                        Comment = model.Comment,
                        CommentCreated = DateTime.Now,
                    };


                    _context.Contacts.Add(contactEntity);
                    await _context.SaveChangesAsync();

                    commentEntity.ContactsId = contactEntity.Id;

                    _context.Comments.Add(commentEntity);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch { return false; }
        }

        public async Task<ContactEntity> GetContactAsync(string contactEmail)
        {
            var userProfileEntity = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == contactEmail);
            return userProfileEntity!;
        }
    }
}
