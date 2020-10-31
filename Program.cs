using System;
using System.Data;

namespace _9._ПОЛИМОРФИЗМ_НА_ОСНОВЕ_ИНТЕРФЕЙСОВ
{
    public enum Proiz { Asus, Acer, HP, Apple, Huawei }
    public enum Diagonal { тринадцатидюймовый, четырнадцатидюймовый, пятнадцатидюймовый }

    class ComputerTechnology
    {
        public ComputerTechnology(int ГВ, int Ц, int СЭ)
        {
            ГодВыпуска = ГВ;
            Цена = Ц;
            СрокЭксплуатации = СЭ;
        }

        public ComputerTechnology()
        {
            ГодВыпуска = 2001;
            Цена = 1000;
            СрокЭксплуатации = 0;
        }

        public int ГодВыпуска, Цена, СрокЭксплуатации;

        public virtual string Info
        {
            get { return "Год выпуска : " + ГодВыпуска + ", Цена: " + Цена + ", Срок эксплуатации: " + СрокЭксплуатации; }
        }

        public virtual void СрокСлужбы(int СС)
        {
            int Срокcлужбы = 50;
            Срокcлужбы = СС;
            Console.WriteLine("Срок службы: ");
        }

        public void CW()
        {
            Console.WriteLine();
        }

    }

    class Server : ComputerTechnology
    {
        public Server() : base()
        {
            Производитель = Proiz.Acer;
        }

        public override void СрокСлужбы(int СС)
        {
            int Срокcлужбы = 55;
            Срокcлужбы = СС;
            Console.WriteLine("Срок службы: 50 лет,");
        }

        public Server(int ГВ, int Ц, int СЭ, Proiz П) : base(ГВ, Ц, СЭ)
        {
            Производитель = П;
        }
        public Proiz Производитель;

        public override string Info
        {
            get { return base.Info + ", Производитель: " + Производитель.ToString(); }
        }
    }

    class Laptop : ComputerTechnology
    {
        public Laptop(int ГВ, int Ц, int СЭ, Diagonal Диаг) : base(ГВ, Ц, СЭ)
        {
            Диагональ = Диаг;
        }
        public Diagonal Диагональ;

        public override string Info
        {
            get { return base.Info + ", Диагональность: " + Диагональ.ToString(); }
        }
    }

    interface Isomeinterface
    {
        void InfoObject();
    }

    class PersonalComputer : ComputerTechnology, Isomeinterface
    {
        public PersonalComputer()
        {
        }

        public PersonalComputer(int ГВ, int Ц, int СЭ) : base(ГВ, Ц, СЭ) { }

        public void InfoObject()
        {
            Console.Write("Системный блок состоит из: \n");
            Console.Write("1.Центральный процессор (CPU, ЦПУ)\n");
            Console.Write("2.Материнская плата (Motherboard)\n");
            Console.Write("3.Оперативная память (RAM, Оперативка)\n");
            Console.Write("4.Видеокарта (или видео адаптер)\n");
            Console.Write("5.Жесткий диск (HDD, винчестер, винт)\n");
            Console.Write("7.Оптически привод (CD-ROM, DVD-ROM)\n");
            Console.Write("8.Блок питания\n");
            Console.Write("9.Корпус\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Server s2 = new Server();
            ComputerTechnology s1 = new ComputerTechnology(); // Использование базового метода отличного от конструктора
            s1.CW();
            PersonalComputer s3 = new PersonalComputer();
            // Массив КомпТехники
            ComputerTechnology[] mas = new ComputerTechnology[4];

            // Заполнение массива
            mas[0] = new ComputerTechnology(2001, 5000, 19);
            mas[1] = new Server(2002, 20000, 18, Proiz.Acer);
            mas[2] = new Laptop(2003, 25000, 17, Diagonal.четырнадцатидюймовый);
            mas[3] = new PersonalComputer(2004, 100000, 16);

            // Вывод информации
            for (int i = 0; i < mas.Length; i++)
            {
                if (i == 0 || i == 2)
                {
                    Console.WriteLine("Имя класса: " + mas[i].GetType().Name);
                    Console.WriteLine(mas[i].Info);
                    s1.CW();
                }
                if (i == 3)
                {
                    Console.WriteLine("Имя класса: " + mas[i].GetType().Name);
                    Console.WriteLine(mas[i].Info);
                    s1.CW();
                    s3.InfoObject(); // Вызов метода из интерфейса!
                    s1.CW();
                }
                if (i == 1)
                {
                    Console.WriteLine("Имя класса: " + mas[i].GetType().Name);
                    s2.СрокСлужбы(1);
                    Console.WriteLine(mas[1].Info);
                    s1.CW();
                }
            }
        }
    }
}
