using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IExaminationGroupRepository
    {
        List<Examination> GetAllExamination();
        Examination GetExamination(string name);
        Examination GetExamination(int id);
        void Create(Examination account);
        void DeleteExamination(int id);
        void DeleteExamination(Examination examination);
        void UpdateExaminatioonAccount(Examination examination);
        void Save();
    }
}
