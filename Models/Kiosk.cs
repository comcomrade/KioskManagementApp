using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskManagementApp.Models
{   [Table("Kiosk")]
    public class Kiosk
    {
        [Key]
        [DisplayName("Mã Kiosk")]
        public int KioskId { get; set; }

        [MaxLength(150)]
        [DisplayName("Tên Kiosk")]
        public string KioskName { get; set; }

        [MaxLength(150)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [MaxLength(11)]
        [DisplayName("Điện thoại")]
        public string Phone { get; set; }

        // many-to-many with Item 
        public virtual List<KioskItem> KioskItem { get; set; }

    }
}
