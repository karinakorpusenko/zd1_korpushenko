// See https://aka.ms/new-console-template for more information


using zd1_up;
//1

Console.WriteLine( "Введите кличку");
string kl=Console.ReadLine();
Console.WriteLine("Введите vosrast");
double vos = Convert.ToDouble(Console.ReadLine());
Cat murzik = new Cat(kl,vos);
Cat barsik = new Cat("Барсег", 0);
murzik.Meow();
barsik.Meow();
barsik.Name = "Барсик";
barsik.Meow();
barsik.Name = "1234";
barsik.Meow();
barsik.Ves = -42;
barsik.Meow();

