using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskManagementApp.Models
{   [Table("ItemCategory")]
    public class ItemCategory
    {
        [Key]
        [DisplayName("Mã loại sản phẩm")]
        public int ItemCategoryId { get; set; }

        [MaxLength(150)]
        [DisplayName("Tên loại sản phẩm")]
        public string ItemCategoryName { get; set; }

        [MaxLength(500)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        // one-to-many
        public List<Item> Items { get; set; }
    }
}
