namespace SchoolManagementSystem.ViewModel
{
    public class VmAdmission
    {
        public long StudentId { get; set; }
        public Guid? CampusId { get; set; }
        public long? SectionId { get; set; }
        public long? GroupId { get; set; }
        public long? SessionId { get; set; }
        public long? ShiftId { get; set; }
        public long? ClassId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Gender { get; set; }
        public string? RollNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? BirthCertificate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? Religion { get; set; }
        public string? Nationality { get; set; }
        public string? PreviousSchool { get; set; }
        public decimal? Gpa { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? FatherNid { get; set; }
        public string? MotherNid { get; set; }
        public string? FatherOccupation { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? FatherEmail { get; set; }
        public string? MotherOccupation { get; set; }
        public string? MotherPhoneNumber { get; set; }
        public string? MotherEmail { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? StudentBloodGroup { get; set; }
        public long? CurriculumId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FatherBloodGroup { get; set; }
        public IFormFile? FatherPhoto { get; set; }
        public string? MotherBloodGroup { get; set; }
        public IFormFile? MotherPhoto { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianRelation { get; set; }
        public IFormFile? GuardianPhoto { get; set; }
        public string? GuardianPhone { get; set; }
        public string? GuardianOccupation { get; set; }
        public string? GuardianAddress { get; set; }
        public string? GuardianEmail { get; set; }
    }
}
