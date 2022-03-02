

using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAllDoctor();
        Doctor GetDoctor(string name);
        Doctor GetDoctor(int id);
        void CreateAccount(Doctor account);
        void DeleteDoctor(int id);
        void DeleteDoctor(Doctor doctor);
        void UpdateAccount(Doctor doctor);
        void Save();
    }
}
