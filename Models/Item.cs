using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskManagementApp.Models
{   [Table("Item")]
    public class Item
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int ItemId { get; set; }

        [MaxLength(500)]
        [DisplayName("Tên sản phẩm")]
        public string ItemName { get; set; }

        [DisplayName("Giá")]
        public long Price { get; set; } //9223372036854775807L

        [MaxLength(50)]
        [DisplayName("Đơn vị")]
        public string Unit { get; set; }

        [MaxLength(500)]
        [DisplayName("Mô tả")]
        public string ItemDescription { get; set; }

        // one-to-many with Iteam Category
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }

        //many-to-many with Kiosk
        public virtual List<KioskItem> KioskItem { get; set; }
        

    }
}
