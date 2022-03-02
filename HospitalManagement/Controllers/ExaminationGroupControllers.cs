using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/ ExaminationGroup")]
    [ApiController]
    public class ExaminationGroupControllers : ControllerBase
    {
        private MedicalManagementContext db = new MedicalManagementContext();
        private IExaminationGroupRepository examinationGroupRepository;
        private readonly IMapper _mapper;
        public ExaminationGroupControllers(IMapper mapper)
        {
            examinationGroupRepository = new ExaminationGroupRepository(db);
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateExaminationAccountDto accountDto)
        {
            var entity = _mapper.Map<Examination>(accountDto);
            if (ModelState.IsValid)
            {
                examinationGroupRepository.Create(entity);
                examinationGroupRepository.Save();
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAllExamination()
        {
            var examination = examinationGroupRepository.GetAllExamination();
            if (examination == null)
                return NotFound();
            return Ok(examination);
        }
        [HttpGet("{name}")]
        public IActionResult GetByExaminName(string name)
        {
            var examination = examinationGroupRepository.GetExamination(name);
            if (examination == null)
            {
                return NotFound();
            }
            return Ok(examination);
        }
        [HttpDelete]
        public ActionResult DeletePatient(int id)
        {
            examinationGroupRepository.DeleteExamination(id);
            examinationGroupRepository.Save();
            return Ok();
        }

    }
}

