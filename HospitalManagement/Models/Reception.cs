using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagement.Models
{
    public partial class Reception
    {
        //public Reception()
        //{
        //    ReceptionExaminations = new HashSet<ReceptionExamination>();
        //}

        public int ReceptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Doctor Doctor { get; set; }        
        public virtual Patient Patient { get; set; }
        public virtual ICollection<ReceptionExamination> ReceptionExaminations { get; set; }
    }
}
