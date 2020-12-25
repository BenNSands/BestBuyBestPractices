using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartment);
    }
}
