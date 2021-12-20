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
    [Table("Team")]
    public class Team
    {
        [Key]
        [DisplayName("Mã nhóm")]
        public int TeamId { get; set; }

        [MaxLength(150)]
        [DisplayName("Tên nhóm")]
        public string TeamName { get; set; } 

        // many-to-one
        public List<Employee> Employees { get; set; }
    }
}
