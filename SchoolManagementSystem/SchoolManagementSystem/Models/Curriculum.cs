﻿using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Curriculum
    {
        public Curriculum()
        {
            CampusCurricula = new HashSet<CampusCurriculum>();
            Classes = new HashSet<Class>();
            Students = new HashSet<Student>();
        }

        public long CurriculumId { get; set; }
        public string? CurriculumName { get; set; }

        public virtual ICollection<CampusCurriculum> CampusCurricula { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
