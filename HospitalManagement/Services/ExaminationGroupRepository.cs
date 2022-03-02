using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class ExaminationGroupRepository : IExaminationGroupRepository
    {
        private MedicalManagementContext db;

        public ExaminationGroupRepository(MedicalManagementContext context)
        {
            db = context;
        }
        public void Create(Examination account)
        {
            db.Examinations.Add(account);
        }

        public void DeleteExamination(int id)
        {
            var person = GetExamination(id);
            DeleteExamination(person);
        }

        public void DeleteExamination(Examination examination)
        {
            db.Entry(examination).State = EntityState.Deleted;
        }

        public List<Examination> GetAllExamination()
        {
            return db.Examinations.ToList();

        }

        public Examination GetExamination(int id)
        {
            return db.Examinations.Find(id);
        }

        public Examination GetExamination(string name)
        {
            return db.Examinations.FirstOrDefault<Examination>();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateExaminatioonAccount(Examination examination)
        {
            db.Entry(examination).State = EntityState.Modified; ;
        }
    }
}
