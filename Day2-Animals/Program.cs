using System;
using System.Diagnostics;
public abstract class Animal 
{
    public string Name { get; }
    protected Animal(string name)
    {
        Name = name;
    }
    public abstract string MakeSound();
    public void Sleep()
    {
        Console.WriteLine($"{Name} спит...");
    }
    public void Introduce() // к слову, можно было бы и стринг использовать, так нв было бы даже лучше, не просто текст передавать, а передавать то, что животное возвращает, что оно делает....... лан
    {
        Console.WriteLine($"Привет, я {Name} и я говорю: {MakeSound()}");
    }
    public void Eat()
    {
        Console.WriteLine($"{Name} ест...");
    }
}
public class Dog : Animal 
{
    public Dog(string name) : base(name) { }
    public override string MakeSound() => "Гав-гав!";
}
public class  Cat : Animal
{
    public Cat(string name) : base(name) { }
    public override string MakeSound() => "Мяу-мяу!";
}
public class Cow : Animal 
{
    public Cow(string name) : base(name) { }
    public override string MakeSound() => "Му-му!";
}
class Program
{
    public static void Main()
    {
        var animals = new Animal[]
        {
        new Dog("Бобик"),
        new Cat("Мурка"),
        new Cow("Буренка")
        };
        foreach (var animal in animals)
        {
            animal.Introduce();
        }
        Console.WriteLine("------------");
        animals[0].Sleep();
        animals[1].Sleep();
        animals[2].Eat();
        Console.WriteLine("------------");
        IAnimal animal1 = new DogViaInterface("Шарик");
        animal1.Introduce();

    }
}