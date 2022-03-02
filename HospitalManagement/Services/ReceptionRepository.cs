using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class ReceptionRepository: IReceptionRepository
    {
        private MedicalManagementContext db;
        public ReceptionRepository(MedicalManagementContext context)
        {
            db = context;
        }
        public List<Reception> GetAllReceptions()
        {
            //var result =  db.Receptions.Include(m => m.Patient).Include(m => m.Doctor).Include(m => m.ReceptionExaminations).ToList();
            var result = db.Receptions.ToList();

            return result;
        }
    }
}
