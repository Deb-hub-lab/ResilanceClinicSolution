namespace AssuranceClinic.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; }
    }
}
