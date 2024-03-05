using System;
using System.Collections.Generic;

namespace PRN231_Trial_PE_1.Model
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
