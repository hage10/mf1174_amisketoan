using CandidateTestService.Core.Entities;
using CandidateTestService.Repository;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        protected IEmployeeService _employeeService;
        protected DatabaseContext _databaseContext;
        public EmployeeController(IBaseService<Employee> baseService, IEmployeeService employeeService, DatabaseContext databaseContext) : base(baseService)
        {
            _employeeService = employeeService;
            _databaseContext = databaseContext;
        }
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpGet("NewCode")]
        public IActionResult GetNewCode()
        {
            var serviceResult = _employeeService.GetNewCode();
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("paging")]
        public IActionResult GetPagingEmployees([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string searchTerms)
        {
            pageNumber = (pageNumber - 1) * pageSize;
            var serviceResult = _employeeService.GetPagingEmployees(pageNumber, pageSize, searchTerms == null ? "" : searchTerms);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPost("aaa")]
        public IActionResult Adds([FromBody] List<Employee> employees)
        {
            _databaseContext.Employees.AddRange(employees);
            int rows = _databaseContext.SaveChanges();
            return Ok(rows);
        }


        public override IActionResult GetById(Guid entityId)
        {
            var serviceResult = _employeeService.GetEmployee(entityId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
