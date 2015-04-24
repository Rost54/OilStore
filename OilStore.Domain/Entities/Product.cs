using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilStore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Approvals { get; set; }
        public string QualityLevel { get; set; }
        public decimal Price { get; set; }
    }
}
