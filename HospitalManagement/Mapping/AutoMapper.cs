using AutoMapper;
using HospitalManagement.Dto;
using HospitalManagement.Models;
using Microsoft.Graph;

namespace HospitalManagement.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreatePatientAccountDto, Patient>();
            CreateMap<CreateDoctorAccountDto, Doctor>();
            CreateMap<CreateExaminationAccountDto, Examination>();
        }
    }
}
