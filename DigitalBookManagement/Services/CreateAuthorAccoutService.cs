﻿using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;

namespace DigitalBookManagement.Services
{
    public class CreateAuthorAccoutService : ICreateAuthorAccout
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public CreateAuthorAccoutService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        /// <summary>
        /// This method will create account for author
        /// </summary>
        /// <param name="author">author</param>
        /// <returns>return a  message whether the author is created or not</returns>
        public string CreateAuthor(Author author)
        {
            try
            {
                _digitalBookManagementContext.Author.Add(author);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Operation failed {ex.Message}";
            }
            return $"Author account for {author.UserName} created successfully";
        }
    }
}
