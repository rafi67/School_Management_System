using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class StudentAttendance
    {
        public long StudentAttendance1 { get; set; }
        public long? StudentId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? Present { get; set; }

        public virtual Student? Student { get; set; }
    }
}
