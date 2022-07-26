using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    [Table("Department")]
    public class Department : BaseEntity
    {
        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// 
        [StringLength(255)]
        public String DepartmentName { get; set; }


    }
}
