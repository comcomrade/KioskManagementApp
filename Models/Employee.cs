using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskManagementApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DisplayName("Mã nhân viên")]
        public int EmployeeId { get; set; }

        [MaxLength(150)]
        [DisplayName("Tên nhân viên")]
        public string EmployeeName { get; set; }

        [MaxLength(10)]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [MaxLength(150)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        
        [Column(TypeName ="date")]
        [DisplayName("Năm sinh")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(11)]
        [DisplayName("Điện thoại")]
        public string Phone { get; set; }

        //one-to-many with Team
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
