using System;
using Microsoft.AspNetCore.Http;
 
namespace WebApiNetCore.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }

    }
}

