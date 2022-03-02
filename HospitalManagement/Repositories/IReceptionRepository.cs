using HospitalManagement.Models;
using System.Collections.Generic;

namespace HospitalManagement.Repositories
{
    public interface IReceptionRepository
    {
        List<Reception> GetAllReceptions();
    }
}
