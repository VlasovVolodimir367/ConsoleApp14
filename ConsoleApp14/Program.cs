using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace ConsoleApp13;
//База даних автосалону автомобілів з двигунами внутрішнього згоряння
//Database of car dealerships with internal combustion engines

[JsonDerivedType(typeof(Eclass), "eclass")]
[JsonDerivedType(typeof(Fclass), "fclass")]
[JsonDerivedType(typeof(Jclass), "jclass")]
[JsonDerivedType(typeof(Mclass), "mclass")]

abstract class GeneralCar
{
    public int Year { set; get; }
    public int Mileage { set; get; }

    public int Price { set; get; }

    public GeneralCar(int year, int mileage, int price)
    {
        Year = year;
        Mileage = mileage;
        Price = price;
    }
    public abstract string GetDescriptionBuyer();
}
//Types of cars in the European system;
//Типи автомобілів у європейській системі;

class Eclass : GeneralCar
//E: executive class cars;
//E: автомобілі представницького класу;
{
    public string Brand { set; get; }
    public string Model { set; get; }
    public string Fuel { set; get; }

    public Eclass(string brand, string model, string fuel, int year, int mileage, int price) : base(year, mileage, price)
    {
        Brand = brand;
        Model = model;
        Fuel = fuel;
    }
    public override string GetDescriptionBuyer()
    {
        return $"This is a executive class car: {Brand}, {Model}, {Fuel}, {Year}, {Mileage}, {Price}";
    }

}
class Fclass : GeneralCar
//F: premium cars;
//F: автомобілі преміум-класу;
{
    public string Brand { set; get; }
    public string Model { set; get; }
    public string Fuel { set; get; }

    public Fclass(string brand, string model, string fuel, int year, int mileage, int price) : base(year, mileage, price)
    {
        Brand = brand;
        Model = model;
        Fuel = fuel;
    }
    public override string GetDescriptionBuyer()
    {
        return $"This is a premium car: {Brand}, {Model}, {Fuel}, {Year}, {Mileage}, {Price}";
    }

}
class Jclass : GeneralCar
//J: crossovers;
//J: кросовери, позашляховики;
{
    public string Brand { set; get; }
    public string Model { set; get; }
    public string Fuel { set; get; }

    public Jclass(string brand, string model, string fuel, int year, int mileage, int price) : base(year, mileage, price)
    {
        Brand = brand;
        Model = model;
        Fuel = fuel;
    }
    public override string GetDescriptionBuyer()
    {
        return $"This is a crossover: {Brand}, {Model}, {Fuel}, {Year}, {Mileage}, {Price}";
    }

}
class Mclass : GeneralCar
//M: minibuses;
//M: багатоцільові транспортні засоби, мікроавтобуси;
{
    public string Brand { set; get; }
    public string Model { set; get; }
    public string Fuel { set; get; }

    public Mclass(string brand, string model, string fuel, int year, int mileage, int price) : base(year, mileage, price)
    {
        Brand = brand;
        Model = model;
        Fuel = fuel;
    }
    public override string GetDescriptionBuyer()
    {
        return $"This is a minibus: {Brand}, {Model}, {Fuel}, {Year}, {Mileage}, {Price}";
    }

}
class Program
//internal class Program
{
    static GeneralCar[] cars = new GeneralCar[100];
    static GeneralCar[] carss = new GeneralCar[100];
    static int carsNumber;
    static void MainMenuShow()
    {
        bool isCar = true;
        while (isCar)
        {
            Console.WriteLine("<1> - Print all cars // роздрукувати всi автомобiлi");
            Console.WriteLine("<2> - Input Car // створити картку автомобiля з клавiатури");
            Console.WriteLine("<3> - Load all cars from file // витягти базу автомобiлей з файла");
            Console.WriteLine("<4> - Remove from list // видалення из списка");
            Console.WriteLine("<5> - Edit the car // редагування автомобiля");
            Console.WriteLine("<6> - sorting cars // сортування автомобiлiв");
            Console.WriteLine("<7> - Save all cars to file // зберегти базу в файл");
            Console.WriteLine("<8> - Exit the program // вихiд з програми");
            Console.Write("Select menu: ");
            int menuItem = Convert.ToInt32(Console.ReadLine());
            switch (menuItem)
            {
                case 1:
                    {
                        PrintAllCars();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 2:
                    {
                        InputCar();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 3:
                    {
                        LoadAllCars();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 4:
                    {
                        Remove();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 5:
                    {
                        Edit();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 6:
                    {
                        Sorting();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 7:
                    {
                        SaveAllCars();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 8:
                    {
                        isCar = false;
                        Console.WriteLine("Goodbye");
                        break;

                    }

                default:
                    {
                        Console.WriteLine("There is no such command");
                        break;
                    }

            }
        }
    }
    static void Sorting()
    {
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
        bool isCar1 = true;
        while (isCar1)
        {
            Console.WriteLine("<1> - Year - increase");
            Console.WriteLine("<2> - Year - decrease");
            Console.WriteLine("<3> - Price - increase");
            Console.WriteLine("<4> - Price - decrease");
            Console.WriteLine("<5> - Price - sum");
            Console.WriteLine("<6> - Exit");
            Console.Write("Enter the serial number of the item to sort by: ");
            int menu369 = Convert.ToInt32(Console.ReadLine());

            switch (menu369)
            {
                case 1:
                    {
                        Sorting1();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 2:
                    {
                        Sorting2();
                        Console.WriteLine("Successfully");
                        break;
                    }

                case 3:
                    {
                        Sorting3();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 4:
                    {
                        Sorting4();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 5:
                    {
                        Sorting5();
                        Console.WriteLine("Successfully");
                        break;
                    }
                case 6:
                    {
                        isCar1 = false;
                        Console.WriteLine("Goodbye");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There is no such command");
                        break;
                    }
            }
        }

    }
    static void Sorting5()
    {
        int sum = 0;
        for (int i = 0; i < carsNumber; i++)
        {
            sum = sum + cars[i].Price;

        }
        Console.WriteLine($"The sum of the cost of all cars: {sum}");
    }
    static void Sorting2()
    {
        for (int i = 1; i < carsNumber; i++)
        {
            int position = 0;
            while (cars[i].Year < cars[position].Year)
            {
                position++;
            }

            if (position != i)
            {
                var tmp = cars[i];
                for (int j = i; j > position; j--)
                {
                    cars[j] = cars[j - 1];
                }
                cars[position] = tmp;
            }
        }
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }
    static void Sorting4()
    {
        for (int i = 1; i < carsNumber; i++)
        {
            int position = 0;
            while (cars[i].Price < cars[position].Price)
            {
                position++;
            }

            if (position != i)
            {
                var tmp = cars[i];
                for (int j = i; j > position; j--)
                {
                    cars[j] = cars[j - 1];
                }
                cars[position] = tmp;
            }
        }
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }
    static void Sorting1()
    {
        for (int i = 1; i < carsNumber; i++)
        {
            int position = 0;
            while (cars[i].Year > cars[position].Year)
            {
                position++;
            }

            if (position != i)
            {
                var tmp = cars[i];
                for (int j = i; j > position; j--)
                {
                    cars[j] = cars[j - 1];
                }
                cars[position] = tmp;
            }
        }
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }
    static void Sorting3()
    {
        for (int i = 1; i < carsNumber; i++)
        {
            int position = 0;
            while (cars[i].Price > cars[position].Price)
            {
                position++;
            }

            if (position != i)
            {
                var tmp = cars[i];
                for (int j = i; j > position; j--)
                {
                    cars[j] = cars[j - 1];
                }
                cars[position] = tmp;
            }
        }
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }
    static void Edit()
    {
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
        Console.Write("Enter the serial number of the element to be edited: ");
        int number368 = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < carsNumber; i++)
        {
            if (i == number368 - 1)
            {
                bool isCar1 = true;
                while (isCar1)
                {
                    Console.WriteLine("<1> - Year");
                    Console.WriteLine("<2> - Mileage");
                    Console.WriteLine("<3> - Price");
                    Console.WriteLine("<4> - Exit");
                    Console.Write(" Enter the serial number of the parameter to be edited: ");
                    int menu369 = Convert.ToInt32(Console.ReadLine());

                    switch (menu369)
                    {
                        case 1:
                            {
                                // EditeYear();
                                Console.WriteLine(cars[i].GetDescriptionBuyer());
                                Console.WriteLine("Year:");
                                int year1 = Convert.ToInt32(Console.ReadLine());
                                cars[i].Year = year1;
                                Console.WriteLine("Successfully");
                                break;
                            }
                        case 2:
                            {
                                // EditeMileage();
                                Console.WriteLine(cars[i].GetDescriptionBuyer());
                                Console.WriteLine("Mileage:");
                                int mileage1 = Convert.ToInt32(Console.ReadLine());
                                cars[i].Mileage = mileage1;
                                Console.WriteLine("Successfully");
                                break;
                            }

                        case 3:
                            {
                                //EditePrice();
                                Console.WriteLine(cars[i].GetDescriptionBuyer());
                                Console.WriteLine("Price:");
                                int price1 = Convert.ToInt32(Console.ReadLine());
                                cars[i].Price = price1;
                                Console.WriteLine("Successfully");
                                break;
                            }
                        case 4:
                            {
                                isCar1 = false;
                                Console.WriteLine("Goodbye");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("There is no such command");
                                break;
                            }
                    }
                }

            }
        }
    }
    static void Remove()
    {
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }

        Console.Write("Enter the serial number of the item to be deleted: ");
        int number367 = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < carsNumber; i++)
        {
            if (i == number367 - 1)
            {
                cars[i] = cars[i + 1];
                carsNumber--;
            }
            if (i > number367 - 1)
            {
                cars[i] = cars[i + 1];
            }
        }
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }
    static void InputCar()
    {
        bool isCar2 = true;
        while (isCar2)
        {
            Console.WriteLine("1. Eclass -executive class cars");
            Console.WriteLine("2. Fclass -premium cars");
            Console.WriteLine("3. Jclass -crossovers");
            Console.WriteLine("4. Mclass -minibuses");
            Console.WriteLine("5. Exit");
            Console.Write("Select menu class: ");
            int menuItem1 = Convert.ToInt32(Console.ReadLine());

            switch (menuItem1)
            {
                case 1:
                    {
                        InputCarE();
                        break;
                    }
                case 2:
                    {
                        InputCarF();
                        break;
                    }
                case 3:
                    {
                        InputCarJ();
                        break;
                    }
                case 4:
                    {
                        InputCarM();
                        break;
                    }
                case 5:
                    {
                        isCar2 = false;
                        Console.WriteLine("Goodbye");
                        break;

                    }
                default:
                    {
                        Console.WriteLine("There is no such command");
                        break;
                    }
            }
        }
    }

    static void InputCarE()

    {

        Console.WriteLine("Brand:");
        string brand = Console.ReadLine();

        Console.WriteLine("Model:");
        string model = Console.ReadLine();

        Console.WriteLine("Fuel:");
        string fuel = Console.ReadLine();

        Console.WriteLine("Year:");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Mileage:");
        int mileage = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Price:");
        int price = Convert.ToInt32(Console.ReadLine());


        Eclass carnew = new Eclass(brand, model, fuel, year, mileage, price);

        carss[carsNumber] = carnew;
        cars[carsNumber] = carss[carsNumber];
        carsNumber++;

        Console.WriteLine(cars[carsNumber - 1].GetDescriptionBuyer());

        Console.WriteLine("Successfully");

    }

    static void InputCarF()

    {

        Console.WriteLine("Brand:");
        string brand = Console.ReadLine();

        Console.WriteLine("Model:");
        string model = Console.ReadLine();

        Console.WriteLine("Fuel:");
        string fuel = Console.ReadLine();

        Console.WriteLine("Year:");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Mileage:");
        int mileage = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Price:");
        int price = Convert.ToInt32(Console.ReadLine());


        Fclass carnew = new Fclass(brand, model, fuel, year, mileage, price);

        carss[carsNumber] = carnew;
        cars[carsNumber] = carss[carsNumber];
        carsNumber++;

        Console.WriteLine(cars[carsNumber - 1].GetDescriptionBuyer());

        Console.WriteLine("Successfully");

    }
    static void InputCarJ()

    {

        Console.WriteLine("Brand:");
        string brand = Console.ReadLine();

        Console.WriteLine("Model:");
        string model = Console.ReadLine();

        Console.WriteLine("Fuel:");
        string fuel = Console.ReadLine();

        Console.WriteLine("Year:");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Mileage:");
        int mileage = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Price:");
        int price = Convert.ToInt32(Console.ReadLine());

        Jclass carnew = new Jclass(brand, model, fuel, year, mileage, price);
        carss[carsNumber] = carnew;
        cars[carsNumber] = carss[carsNumber];
        carsNumber++;

        Console.WriteLine(cars[carsNumber - 1].GetDescriptionBuyer());
        Console.WriteLine("Successfully");
    }
    static void InputCarM()

    {

        Console.WriteLine("Brand:");
        string brand = Console.ReadLine();

        Console.WriteLine("Model:");
        string model = Console.ReadLine();

        Console.WriteLine("Fuel:");
        string fuel = Console.ReadLine();

        Console.WriteLine("Year:");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Mileage:");
        int mileage = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Price:");
        int price = Convert.ToInt32(Console.ReadLine());


        Mclass carnew = new Mclass(brand, model, fuel, year, mileage, price);

        carss[carsNumber] = carnew;
        cars[carsNumber] = carss[carsNumber];
        carsNumber++;

        Console.WriteLine(cars[carsNumber - 1].GetDescriptionBuyer());
        Console.WriteLine("Successfully");
    }
    static void LoadAllCars()
    {
        string carsJson = File.ReadAllText("car_database.json");

        //Console.WriteLine(carsJson);
        GeneralCar[] listCar = JsonSerializer.Deserialize<GeneralCar[]>(carsJson)!;
        carsNumber = 0;
        for (int i = 0; i < listCar.Length; i++)
        {
            cars[i] = listCar[i];
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");

            Console.WriteLine(cars[i].GetDescriptionBuyer());
            carsNumber++;
        }
        return;
    }
    static void SaveAllCars()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        GeneralCar[] car1 = new GeneralCar[carsNumber];
        for (int i = 0; i < carsNumber; i++)
        {
            car1[i] = cars[i];
        }
        string carsJson = JsonSerializer.Serialize(car1, options);

        File.WriteAllText("car_database.json", carsJson);
    }
    static void PrintAllCars()
    {
        for (int i = 0; i < carsNumber; i++)
        {
            Console.Write("- ");
            Console.Write(i + 1);
            Console.Write(". ");
            Console.WriteLine(cars[i].GetDescriptionBuyer());
        }
    }

    static void Main(string[] args)
    {
        MainMenuShow();
    }
}
