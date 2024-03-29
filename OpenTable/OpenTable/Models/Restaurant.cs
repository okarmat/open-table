﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}