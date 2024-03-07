using Microsoft.AspNetCore.Mvc;
using PRN231_Trial_PE_1.DAO;
using PRN231_Trial_PE_1.DTO;
using PRN231_Trial_PE_1.Model;
using System.Reflection;

namespace PRN231_Trial_PE_1.Controllers
{
    [Route("api/Director")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        readonly PE_PRN_Fall22B1Context _context;
        public DirectorController(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }
        private DirectorDAO directorDAO = new DirectorDAO();
        [HttpGet("GetDirectors/{nationality}/{gender}")]
        public ActionResult<List<DirectorOnlyDTO>> GetDirectors(string nationality, string gender)
        {

            return directorDAO.GetDirectors(nationality, gender.Equals("male")? true: false);
        }
        [HttpGet("GetDirector/{id}")]
        public ActionResult<DirectorDTO> GetDirector(int id)
        {
            return directorDAO.GetDirector(id);
        }
        [HttpPost("Create")]
        public ActionResult Create(Director director)
        {
            try {
                _context.Directors.Add(director);
                var totalDirectorAdd = _context.SaveChanges();
                return Ok(totalDirectorAdd);
            }
            catch (Exception ex)
            {
                return Conflict("There is an error while adding");
            }

          
        }
    }
}
