﻿using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DepartmentRepo(connection);

            Console.WriteLine("Type a new Department: ");
            var newDep = Console.ReadLine();
            repo.InsertDepartment(newDep);
            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }
        }
    }
}
