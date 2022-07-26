using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IBaseService<Department> baseService) : base(baseService)
        {
        }
    }
}
