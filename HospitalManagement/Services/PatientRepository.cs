using AutoMapper;

using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Services
{
    public class PatientRepository : IPatientRepository
    {
        private MedicalManagementContext db;

        public PatientRepository(MedicalManagementContext context)
        {
            db = context;
        }
        public void CreateAccount(Patient account)
        {
            db.Patients.Add(account);
        }

        public void DeletePerson(int id)
        {
            var person = GetPatient(id);
            DeletePerson(person);
        }
        public void DeletePerson(Patient patient)
        {
            db.Entry(patient).State = EntityState.Deleted;
        }
        public List<Patient> GetAllPatients()
        {
            return db.Patients.ToList();
        }

        public Patient GetPatient(int id)
        {
            return db.Patients.Find(id);
        }

        public Patient GetPatient(string nationalcode)
        {
            return db.Patients.FirstOrDefault<Patient>();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAccount(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
        }
    }
}
