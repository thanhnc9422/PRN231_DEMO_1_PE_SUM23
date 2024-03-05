using PRN231_Trial_PE_1.Model;

namespace PRN231_Trial_PE_1.DTO
{
    public class DirectorDTO
    {
        public DirectorDTO()
        {
            Movies = new HashSet<MovieDTO>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string DobString { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MovieDTO>? Movies { get; set; } = null!;
    }
}

