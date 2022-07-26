using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace CandidateTestService.Core.Entities
{
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// 
        [StringLength(20)]
        [CheckEmployeeCode]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// 
        [StringLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// 
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Điện thoại di động
        /// </summary>
        /// 
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Khóa Ngoại
        /// </summary>
        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        /// <summary>
        /// Khóa ngoại
        /// </summary>
        // public Guid PositionId { get; set; }

        /// <summary>
        /// Điện thoại cố định
        /// </summary>
        /// 
        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        /// 
        [StringLength(25)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        /// 
        [StringLength(255)]
        public string IdentityPlace { get; set; }

        [StringLength(255)]
        public string PositionName { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// 
        [Column(TypeName = "Date")]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// 
        [StringLength(255)]
        public string Address { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 
        [StringLength(255)]
        public string BankName { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        /// 
        [StringLength(25)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// 
        [StringLength(255)]
        public string BankBranchName { get; set; }
        #endregion
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CheckEmployeeCode : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            if (!Regex.IsMatch((string)value, @"^((NV-)(\d+))$"))
                result = new ValidationResult("Mã nhân viên không hợp lệ");
            return result;
        }
    }
}
