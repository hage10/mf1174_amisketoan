using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        ServiceResult GetNewCode();
        ServiceResult GetPagingEmployees(int pageNumber, int pageSize, string searchTerms);

        ServiceResult GetEmployee(Guid id);
    }
}
