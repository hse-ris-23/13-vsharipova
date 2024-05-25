using CarLibrary;

namespace Lab13
{
    internal class Program
    {
        static Car CreateRandCar()
        {
            Random random = new Random();
            Console.WriteLine("Что создать? 1.Грузовая 2.Легковая 3.Внедорожник");
            int choice = int.Parse(Console.ReadLine());
            Car car;
            if (choice == 1)
                car = new HeavyCar();
            else if (choice == 2)
                car = new LightCar();
            else
                car = new MiddleCar();
            car.RandomInit();
            return car;
        }

        static Car CreateHandCar()
        {
            Console.WriteLine("Что создать? 1.Грузовая 2.Легковая 3.Внедорожник");
            int choice = int.Parse(Console.ReadLine());
            Car car;
            if (choice == 1)
                car = new HeavyCar();
            else if (choice == 2)
                car = new LightCar();
            else
                car = new MiddleCar();
            car.Init();
            return car;
        }


        static void Main(string[] args)
        {
            MyObservableCollection<Car> collectioFirst = new MyObservableCollection<Car>("First Collection");
            MyObservableCollection<Car> collectioSecond = new MyObservableCollection<Car>("Second Collection");

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            collectioFirst.CollectionCountChanged += journal1.CollectionCountChanged;
            collectioFirst.CollectionReferenceChanged += journal1.CollectionReferenceChanged;

            collectioFirst.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            collectioSecond.CollectionReferenceChanged += journal2.CollectionReferenceChanged;

            int action;
            do
            {
                Console.WriteLine("1.Добавить элемент");
                Console.WriteLine("2.Удалить элемент");
                Console.WriteLine("3.Изменить элемент");
                Console.WriteLine("4.Вывести журналы");
                Console.WriteLine("5.Вывести коллекции");
                Console.WriteLine("0.Выход");

                action = int.Parse(Console.ReadLine());

                if (action == 1)
                {
                    Car car = CreateRandCar();

                    Console.WriteLine("В какую коллекцию добавить? в 1 или 2");
                    int numberCollection = int.Parse(Console.ReadLine());

                    if (numberCollection == 1)
                        collectioFirst.Add(car);
                    else
                        collectioSecond.Add(car);
                }
                else if (action == 2)
                {
                    Car car = CreateHandCar();

                    Console.WriteLine("Из какой коллекции удалить? Из 1 или 2");
                    int numberCollection = int.Parse(Console.ReadLine());

                    if (numberCollection == 1)
                        collectioFirst.Remove(car);
                    else
                        collectioSecond.Remove(car);
                }
                else if (action == 3)
                {
                    Console.WriteLine("Введите данные изменяемого элемента");
                    Car car = CreateHandCar();

                    Console.WriteLine("Введите данные нового элемента");
                    Car newCar = CreateHandCar();

                    Console.WriteLine("С какой коллекцией работать? 1 или 2");
                    int numberCollection = int.Parse(Console.ReadLine());
                    if (numberCollection == 1)
                        collectioFirst[car] = newCar;
                    else
                        collectioSecond[car] = newCar;
                }
                else if (action == 4)
                {
                    Console.WriteLine("Первый журнал");
                    journal1.Show();
                    Console.WriteLine("Второй журнал");
                    journal2.Show();
                }
                else if (action == 5)
                {
                    Console.WriteLine(collectioFirst.Name);
                    foreach (var item in collectioFirst)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    Console.WriteLine(collectioSecond.Name);
                    foreach(var item in collectioSecond)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            while (action != 0);
        }
    }
}
