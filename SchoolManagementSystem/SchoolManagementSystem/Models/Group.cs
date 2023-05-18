﻿using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public long GroupId { get; set; }
        public string? GroupName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
