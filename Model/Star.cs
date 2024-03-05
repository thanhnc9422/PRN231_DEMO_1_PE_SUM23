﻿using System;
using System.Collections.Generic;

namespace PRN231_Trial_PE_1.Model
{
    public partial class Star
    {
        public Star()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool? Male { get; set; }
        public DateTime? Dob { get; set; }
        public string? Description { get; set; }
        public string? Nationality { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
