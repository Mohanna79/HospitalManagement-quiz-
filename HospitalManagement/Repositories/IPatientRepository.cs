using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatient(string nationalcode);
        Patient GetPatient(int id);
        void CreateAccount(Patient account);
        void DeletePerson(int id);
        void DeletePerson(Patient patient);
        void UpdateAccount(Patient patient);
        void Save();

    }
}
