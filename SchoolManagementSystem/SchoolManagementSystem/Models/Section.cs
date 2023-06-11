using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Section
    {
        public Section()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
            StudentPromotions = new HashSet<StudentPromotion>();
            Students = new HashSet<Student>();
        }

        public long SectionId { get; set; }
        public string? SectionName { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<StudentPromotion> StudentPromotions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
