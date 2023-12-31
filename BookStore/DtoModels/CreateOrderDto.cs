﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DtoModels
{
    public class CreateOrderDto
    {
       
        [Required]
        public string  FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public List<int> BookIds { get; set; }

        
    }
}
