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
    public class KioskItem
    {
        [Key, Column(Order = 0)]
        [DisplayName("Mã sản phẩm")]
        public int ItemId { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Mã Kiosk")]
        public int KioskId { get; set; }

        // navigational properties
        public virtual Item Item { get; set; }
        public virtual Kiosk Kiosk { get; set; }

        // additional property
        [DisplayName("Số lượng sản phẩm")]
        public int StockQuantity { get; set; }

    }
}
