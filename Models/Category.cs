using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

#nullable disable

namespace LaptopMart.Models
{
    public partial class Category
    {
        public Category()
        {
            items = new HashSet<Item>();
        }

       [ValidateNever]
        public int categoryId { get; set; }

        [Required(ErrorMessage = "Please enter category Name")]
        public string categoryName { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }

        [Required(ErrorMessage = "Please enter the categories current State")]
        public int currentState { get; set; }
        public string imageName { get; set; }
        public bool showInHomePage { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public virtual ICollection<Item> items { get; set; }
    }
}
