using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;


namespace CandidateTestService.Repository.Implement
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = (from e in _databaseContext.Employees where e.Id.Equals(id) select e).FirstOrDefault();
            var e1 = _databaseContext.Entry(employee);
            e1.Reference(e1 => e1.Department).Load();
            return employee;
        }

        public string GetNewCode()
        {

            List<Employee> employees = _databaseContext.Employees.ToList();
            int maxNumber = 0;

            for (int i = 0; i < employees.Count; i++)
            {
                Employee employee = employees[i];
                int code = Int32.Parse(employee.EmployeeCode.Replace("NV-", ""));
                maxNumber = maxNumber < code ? code : maxNumber;
            }

            return $"NV-{++maxNumber}";
        }

        public object GetPagingEmployees(int pageNumber, int pageSize, string searchTerms)
        {
            List<Employee> employees = (from e in _databaseContext.Employees
                                        where e.FullName.Contains(searchTerms)
                                        || e.EmployeeCode.Contains(searchTerms)
                                        select e).ToList();
            var data = employees.Skip(pageNumber).Take(pageSize);
            foreach (var employee in data)
            {
                var e = _databaseContext.Entry(employee);
                e.Reference(e => e.Department).Load();
            }
            return new
            {
                totalRecord = employees.Count,
                data = data
            };
        }
    }
}

