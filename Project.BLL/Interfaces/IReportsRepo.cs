﻿using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IReportsRepo
    {
        IEnumerable<Student> GetStudentsByDepartment(int deptId);
        IEnumerable<int?> GetGradesByStudentId(int stdId);
    }
}