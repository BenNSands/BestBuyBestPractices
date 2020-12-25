using System;
using System.Collections.Generic;
using Dapper;
using System.Data;

namespace BestBuyBestPractices
{
    class DepartmentRepo : IDepartmentRepo
    {
        private readonly IDbConnection _conn;

        public DepartmentRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        
        public IEnumerable<Department> GetAllDepartments() 
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartment)
        {
            _conn.Execute("INSERT INTO departments(Name) VALUES(@depName);", new { depName = newDepartment });
        }
    }
}
