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
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID người dùng")]
        public int UserId { get; set; }

        [MaxLength(150)]
        [DisplayName("Tên người dùng")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập!")]
        public string Username { get; set; }

        [MaxLength(500)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu!")]
        public string Password { get; set; }
    }
}
