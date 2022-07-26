using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Delare

        protected IBaseService<MISAEntity> _baseService;

        #endregion

        #region Consstructor

        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        #endregion

        /// <summary>
        /// Lấy toàn bộ ds
        /// </summary>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpGet]
        public IActionResult GetAll()
        {
            var serviceResult = _baseService.GetAll();
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        /// <summary>
        /// Lấy 1 bản ghi theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpGet("{entityId}")]
        public virtual IActionResult GetById(Guid entityId)
        {
            var serviceResult = _baseService.GetById(entityId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpPost]
        public virtual IActionResult Post([FromBody] MISAEntity entity)
        {
            var serviceResult = _baseService.Add(entity);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        /// <summary>
        /// cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpPut("{entityId}")]
        public virtual IActionResult Put(Guid entityId, [FromBody] MISAEntity entity)
        {
            var serviceResult = _baseService.Update(entity, entityId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Author TrungTQ
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var serviceResult = _baseService.Delete(entityId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

    }
}
