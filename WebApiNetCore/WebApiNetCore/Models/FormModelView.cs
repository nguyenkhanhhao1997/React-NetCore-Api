using Microsoft.AspNetCore.Http;
using System;

namespace WebApiNetCore.Models
{
    public class FormModelView
    {
        public class FormCategoryView
        {
            public string Name { get; set; }
            public string SlugCategory { get; set; }
        }
        public class FormProductView
        {
            public string Title { get; set; }
            public string Body { get; set; }
            public string Slug { get; set; }
            public int idCategory { get; set; }
        }
        public class FormUserView
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
            public DateTime BirthDay { get; set; }
            public IFormFile Avatar { get; set; }
            public string Address { get; set; }
        }
    }
}
