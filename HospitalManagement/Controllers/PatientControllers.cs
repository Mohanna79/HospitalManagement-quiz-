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
    [Route("api/Patient")]
    [ApiController]
    public class PatientControllers : ControllerBase
    {
        private MedicalManagementContext db = new MedicalManagementContext();
        private IPatientRepository patientRepository;
        private readonly IMapper _mapper;
        public PatientControllers(IMapper mapper)
        {
            patientRepository = new PatientRepository(db);
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateAccount(CreatePatientAccountDto accountDto)
        {
            var entity = _mapper.Map<Patient>(accountDto);
            if (ModelState.IsValid)
            {
                patientRepository.CreateAccount(entity);
                patientRepository.Save();
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = patientRepository.GetAllPatients();
            if (patients == null)
                return NotFound();
            return Ok(patients);
        }
        [HttpGet("{nationalcode}")]
        public IActionResult GetByNationalCode(string nationalCode)
        {
            var patient = patientRepository.GetPatient(nationalCode);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpDelete]
        public ActionResult DeletePatient(int id)
        {
            patientRepository.DeletePerson(id);
            patientRepository.Save();
            return Ok();
        }

    }
}
