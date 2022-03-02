using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorControllers : ControllerBase
    {
        private MedicalManagementContext db = new MedicalManagementContext();
        private IDoctorRepository doctorRepository;
        private readonly IMapper _mapper;
        public DoctorControllers(IMapper mapper)
        {
            doctorRepository = new DoctorRepository(db);
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateDoctorAccountDto accountDto)
        {
            var entity = _mapper.Map<Doctor>(accountDto);
            if (ModelState.IsValid)
            {
                doctorRepository.CreateAccount(entity);
                doctorRepository.Save();
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var doctor = doctorRepository.GetAllDoctor();
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }
        [HttpGet("{name}")]
        public IActionResult GetByNationalCode(string name)
        {
            var doctor = doctorRepository.GetDoctor(name);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpDelete]
        public ActionResult DeletePatient(int id)
        {
            doctorRepository.DeleteDoctor(id);
            doctorRepository.Save();
            return Ok();
        }

    }
}

