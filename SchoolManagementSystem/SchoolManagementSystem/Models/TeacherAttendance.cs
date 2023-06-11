using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class TeacherAttendance
    {
        public long TeacherAttendance1 { get; set; }
        public long? TeacherId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? Present { get; set; }

        public virtual Teacher? Teacher { get; set; }
    }
}
