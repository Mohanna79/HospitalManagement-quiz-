using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionControllers : ControllerBase
    {
        private MedicalManagementContext db = new MedicalManagementContext();
        private IReceptionRepository receptionRepository;
        private readonly IMapper _mapper;
        public ReceptionControllers(IMapper mapper)
        {
            receptionRepository = new ReceptionRepository(db);
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllReceptions()
        { 
            var receptions = receptionRepository.GetAllReceptions();
            if (receptions == null)
                return NotFound();
            return Ok(receptions);
        }
    }
}
