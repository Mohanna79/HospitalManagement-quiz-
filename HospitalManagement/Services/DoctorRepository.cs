using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private MedicalManagementContext db;

        public DoctorRepository(MedicalManagementContext context)
        {
            db = context;
        }
        public void CreateAccount(Doctor account)
        {
            db.Doctors.Add(account);
        }

        public void DeleteDoctor(int id)
        {
            var person = GetDoctor(id);
            DeleteDoctor(person);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Deleted;
        }

        public List<Doctor> GetAllDoctor()
        {
            return db.Doctors.ToList();
        }

        public Doctor GetDoctor(int id)
        {
            return db.Doctors.Find(id);
        }

        public Doctor GetDoctor(string name)
        {
            return db.Doctors.FirstOrDefault<Doctor>();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAccount(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
        }
    }
}
