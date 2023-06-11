using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModel
{
    public class VmPromotionList
    {
        public string? RollNumber { get; set; }
        public string? StudentName { get; set; }
        public string? ClassName { get; set; }
        public string? PromotionDate { get; set; }
        public string? PromotionStatus { get; set; }
        public string? SectionName { get; set; }
        public string? ShiftType { get; set; }
        public string? ShiftName { get; set; }
        public string? SessionName { get; set; }
        public string? GroupName { get; set; }
        public class PromoteData
        {
            public string?[] RollNumber { get; set; }
            public string?[] StudentName { get; set; }
            public string?[] ClassName { get; set; }
            public string?[] PromotionDate { get; set; }
            public string?[] PromotionStatus { get; set; }
            public string?[] SectionName { get; set; }
            public string?[] ShiftType { get; set; }
            public string?[] ShiftName { get; set; }
            public string?[] SessionName { get; set; }
            public string?[] GroupName { get; set; }
        }
    }
}
