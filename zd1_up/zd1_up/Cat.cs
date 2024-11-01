using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace zd1_up
{
     class Cat
    {
        private string name;
        private double ves;

        public string Name // свойство, реализуем инкапсуляцию!
        {
            // получение значения - просто возврат name
            get
            {
                return name;
            }
            // установка значения - используем проверку
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        public double Ves
        {
            get { return ves; }

            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                if (value <= 0)
                {
                    OnlyLetters = false;
                    if (value == 0)
                        ves = 4;
                    else
                        ves = 0;
                    ves -= value;
                   
                }
                if(OnlyLetters)
                    ves= value;
                else
                {
                    Console.WriteLine($"{value} - неправильное ves!!!");
                }
                value = 0;
            }
        }

                public Cat(string CatName,double CatVes)
        {
            Name = CatName;
            Ves = CatVes;
        }

        public void Meow()
        {
            Console.WriteLine($"{name},{ves}:MEOOOOOOOOOW!!!");
        }
     
    }
}
