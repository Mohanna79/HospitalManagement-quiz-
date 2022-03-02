using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagement.Models
{
    public partial class Doctor
    {
        //public Doctor()
        //{
        //    Receptions = new HashSet<Reception>();
        //}

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long MedicalSystemCode { get; set; }

        public virtual ICollection<Reception> Receptions { get; set; }
    }
}
