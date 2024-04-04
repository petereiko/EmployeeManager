using EmployeeManager.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(20)]
        [Required]
        public string Phone { get; set; }

        [Display(Name ="Department")]
        [Required]
        public int? DepartmentId { get; set; }

        [Display(Name = "Grade")]
        [Required]
        public int? GradeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public virtual DepartmentViewModel Department { get; set; }

        public virtual GradeViewModel Grade { get; set; }
    }
}
