using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class StudentPromotion
    {
        public long StudentPromotionId { get; set; }
        public long? StudentId { get; set; }
        public long? ClassId { get; set; }
        public DateTime? PromotionDate { get; set; }
        public bool? PromotionStatus { get; set; }
        public long? SectionId { get; set; }
        public long? SessionId { get; set; }
        public long? GroupId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Session? Session { get; set; }
        public virtual Student? Student { get; set; }
    }
}
