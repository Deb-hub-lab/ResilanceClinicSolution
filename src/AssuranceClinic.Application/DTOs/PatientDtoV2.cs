using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssuranceClinic.Application.DTOs
{
    public class PatientDtoV2
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string? Diagnosis { get; set; }
    }
}
