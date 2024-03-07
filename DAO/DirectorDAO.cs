using Microsoft.EntityFrameworkCore;
using PRN231_Trial_PE_1.DTO;
using PRN231_Trial_PE_1.Model;

namespace PRN231_Trial_PE_1.DAO
{
    public class DirectorDAO
    {
        readonly PE_PRN_Fall22B1Context _context = new PE_PRN_Fall22B1Context();
        public DirectorDAO() { }
        public DirectorDAO(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }
        public List<DirectorOnlyDTO> GetDirectors(string nationality, bool gender)
        {
            return _context.Directors.Where(x => x.Nationality.Equals(nationality) && x.Male == gender).Select(x => new DirectorOnlyDTO { Id = x.Id, FullName = x.FullName, Gender = x.Male? "Male":"Female", Dob = x.Dob, DobString = x.Dob.ToString("MM/dd/yyyy"),Nationality = x.Nationality, Description = x.Description}).ToList();
        }
        public DirectorDTO GetDirector(int id)
        {
            Director data = _context.Directors.Include(x => x.Movies).ThenInclude(x => x.Producer).FirstOrDefault(x => x.Id == id);
            DirectorDTO director = new DirectorDTO() {
                Id = data.Id,
                FullName = data.FullName,
                Gender = data.Male? "Male" : "Female",
                Dob = data.Dob,
                DobString = data.Dob.ToString("MM/dd/yyyy"),
                Nationality = data.Nationality,
                Description = data.Description,
                Movies = data.Movies.Select(x => new MovieDTO { 
                    Id = x.Id,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    ReleaseYear = x.ReleaseDate?.Year.ToString(),
                    Description = x.Description,
                    Language = x.Language,
                    ProducerId = x.ProducerId,
                    DirectorId = data.Id,
                    ProducerName = x.Producer.Name,
                    DirectorName = x.Director.FullName,
                    Genres = x.Genres,
                    Stars = x.Stars
                }).ToList()
            };
            return director;
        }
        public void Create(Director newDirector)
        {
            _context.Directors.Add(newDirector);
            _context.SaveChanges();
        }
    }
}
