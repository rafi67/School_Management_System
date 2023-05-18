﻿using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Admin
    {
        public long AdminId { get; set; }
        public long? Teacherid { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? StudentManagement { get; set; }
        public bool? TeacherManagement { get; set; }
        public bool? StuffManagement { get; set; }
        public bool? PaymentManagement { get; set; }
        public bool? ExamManagement { get; set; }
        public bool? ClassRoutineManagement { get; set; }
        public bool? SubjectManagement { get; set; }
        public bool? ResultManagement { get; set; }

        public virtual Teacher? Teacher { get; set; }
    }
}
