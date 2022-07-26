using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        string GetNewCode();

        object GetPagingEmployees(int pageNumber, int pageSize, string searchTerms);

        Employee GetEmployeeById(Guid id);
    }
}
