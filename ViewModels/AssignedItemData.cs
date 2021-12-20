using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskManagementApp.ViewModels
{
    public class AssignedItemData
    {
        public int KioskId { get; set; }
        public string KioskName { get; set; }
        public bool Assigned { get; set; }
    }
}
