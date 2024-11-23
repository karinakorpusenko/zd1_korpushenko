using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_3
{
    class Shop
    {
        private Dictionary<Product, int> products;
        private decimal profit;


        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0;
        }

        public void AddProduct(Product product, int count)
        {
            if (products.ContainsKey(product))
            {
                products[product] += count; // Увеличиваем количество, если продукт уже существует
            }
            else
            {
                products.Add(product, count);
            }
        }

        public void CreateProduct(string name, decimal price, int count)
        {
            // Проверяем, существует ли продукт с таким именем
            if (FindByName(name) != null)
            {
                MessageBox.Show("Продукт с таким именем уже существует.");
                return;
            }

            AddProduct(new Product(name, price), count);
        }


        public void WriteAllProducts(ListBox listBox)
        {
            listBox.Items.Clear(); // Clear existing items
            foreach (var product in products)
            {
                listBox.Items.Add(product.Key.GetInfo() + "; Количество: " + product.Value); // Add product info to the ListBox
            }
        }
        public void Sell(Product product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    Console.WriteLine("Нет в наличии!");
                }
                else
                {
                    products[product]--;
                    profit += product.Price; // Увеличиваем прибыль
                }
               
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }

        public void Sell(string productName, int count)
        {
            Product toSell = FindByName(productName);
            if (toSell != null)
            {
                if (products[toSell] < count)
                {
                    MessageBox.Show("Недостаточно товара в наличии для продажи.");
                    return;
                }

                for (int i = 0; i < count; i++)
                {
                    Sell(toSell); // Продаем товар указанное количество раз
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }

        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) // Сравнение без учета регистра
                {
                    return product;
                }
            }
            return null;
        }
        public Dictionary<Product, int> GetProducts()
        {
            return products;
        }
        public decimal GetProfit()
        {
            return profit; // Возвращаем текущее значение прибыли
        }
    }
}
