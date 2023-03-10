﻿namespace WebApiNetCore.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public int idCategory { get; set; }
        public Category Category { get; set; }
    }

}
