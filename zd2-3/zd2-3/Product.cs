using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_3
{
   class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }

        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }


        // прим. можно упростить до выражения, используя =>
        public string GetInfo()
            {
                return $"Наименование: {Name}; Цена: {Price}";
            }
        
    }
}
