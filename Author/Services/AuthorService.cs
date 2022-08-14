﻿using Author.Models;
using Author.Repositories;

namespace Author.Services
{
    public class AuthorService : IAuthorService
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public AuthorService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        /// <summary>
        /// This method is to create a book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>Result</returns>
        public string CreateBook(Book book)
        {
            try
            {

                _digitalBookManagementContext.Books.Add(book);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Book save operation failed {ex.Message}";
            }
            return "Book saved suceessfully";
        }

        /// <summary>
        /// This method will get the all the books created by logged in author
        /// </summary>
        /// <returns>Book list</returns>
        public IEnumerable<Book> GetAllBooks(long userId)
        {
            var request = _digitalBookManagementContext.Books.Where(x => x.UserId == userId);
            return request;
        }

        /// <summary>
        /// This method will take user name and password validate the user
        /// </summary>
        /// <param name="author"></param>
        /// <returns>return a message whether the login is scuccessfull or not</returns>
        public string AuthorLogin(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
            {
                string message = string.Empty;
                var result = _digitalBookManagementContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                if (result != null)
                    message = $"Author {user.UserName} logged in successfully";
                else
                    message = "Invalid user name or password";

                return message;
            }
            return $"Please provide valid input";
        }

        /// <summary>
        /// This method will update the given book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>message whether the operation is scuccessfull or not</returns>
        public string EditBook(Book book)
        {
            try
            {
                var result = _digitalBookManagementContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();

                if (result != null)
                {
                    result.Publisher = book.Publisher;
                    result.BookTitle = book.BookTitle;
                    result.PublishDate = book.PublishDate;
                    result.ModifiedDate = DateTime.Now;
                    result.Category = book.Category;
                    result.Content = book.Content;
                    result.Active = book.Active;
                    result.Logo = book.Logo;
                    result.Price = book.Price;
                    result.User = book.User;

                    _digitalBookManagementContext.Books.Update(result);
                    _digitalBookManagementContext.SaveChanges();

                    return $"Book updated successfully";
                }
                return $"Input provided is not valid";
            }
            catch (Exception ex)
            {
                return $"Operation operation faild : {ex.Message}";
            }
        }
        /// <summary>
        /// This method will lock or unlock the book
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>return a message whether the book is locked or unlocked</returns>
        public string LockOrUnlocBook(Book book)
        {
            try
            {
                var result = _digitalBookManagementContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();

                if (result != null)
                {
                    result.Active = book.Active;
                    result.ModifiedDate = DateTime.Now;

                    _digitalBookManagementContext.Books.Update(result);
                    _digitalBookManagementContext.SaveChanges();
                    string message = result.Active == true ? $"Book {result.BookTitle}unlocked successfully" : $"Book {result.BookTitle} locked successfully";

                    return message;
                }
                return $"Input provided is not valid";
            }
            catch (Exception ex)
            {
                return $"Operation operation faild : {ex.Message}";
            }
        }
    }
}
