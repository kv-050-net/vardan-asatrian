﻿using System.Collections.Generic;

namespace BaseOOPBLL.Entities
{
    public class ManagerDto : EmployeeDto
    {
        public int? DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
        public List<EmployeeDto> Team { get; set; }
    }
}
