using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Dto
{
    public class CreatePatientAccountDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
