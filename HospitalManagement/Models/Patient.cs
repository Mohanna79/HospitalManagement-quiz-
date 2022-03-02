using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagement.Models
{
    public partial class Patient
    {
        //public Patient()
        //{
        //    Receptions = new HashSet<Reception>();
        //}

        public int PatientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        public virtual ICollection<Reception> Receptions { get; set; }
    }
}
