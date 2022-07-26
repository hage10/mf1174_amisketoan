using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        protected IEmployeeRepository _employeeRepositoty;

        public EmployeeService(IBaseRepository<Employee> baseRepository, IEmployeeRepository employeeRepositoty) : base(baseRepository)
        {
            _employeeRepositoty = employeeRepositoty;
        }

        public ServiceResult GetEmployee(Guid id)
        {
            try
            {
                object data = _employeeRepositoty.GetEmployeeById(id);
                _serviceResult.Response = new ResponseModel(2001, "OK", data);
                _serviceResult.StatusCode = 200;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetNewCode()
        {
            try
            {
                string newCode = _employeeRepositoty.GetNewCode();
                _serviceResult.Response = new ResponseModel(2001, "OK", newCode);
                _serviceResult.StatusCode = 201;
                return _serviceResult;
            }
            catch(Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetPagingEmployees(int pageNumber, int pageSize, string searchTerms)
        {
            try
            {
                object data = _employeeRepositoty.GetPagingEmployees(pageNumber, pageSize, searchTerms);
                _serviceResult.Response = new ResponseModel(2001, "OK", data);
                _serviceResult.StatusCode = 200;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }
    }
}
