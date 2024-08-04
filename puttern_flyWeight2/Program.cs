using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static puttern_flyWeight2.Program;

namespace puttern_flyWeight2
{
    class Program
    {
        public class FlyWeight
        {
            private Shared shared;

            public FlyWeight(Shared shared)
            {
                this.shared = shared;
            }

            public void Process(Unique unique)
            {
                Console.WriteLine($"Новые данные: Общие - {shared.Company}_{shared.Position}, уникальные - {unique.Name}_{unique.Passport}");

            }

            public string GetData() => shared.Position + "_" + shared.Company;
        }

        public class FlyWeightFactory
        {
            private Hashtable flyweights;
            private string GetKey(Shared shared) => shared.Company + "_" + shared.Position;
            public FlyWeightFactory(List<Shared> shareds)  // подается списк с названием компании и должности
            {
                flyweights = new Hashtable();
                foreach (var item in shareds)
                {
                    flyweights.Add(GetKey(item), new FlyWeight(item));
                }
            }

            public FlyWeight GetFlyWeight(Shared shared)
            {
                string key = GetKey(shared);
                if (!flyweights.ContainsKey(key))
                {
                    Console.WriteLine($"FlyWeightFactory: общих данных по ключу {key} не найдено");
                    flyweights.Add(key, new FlyWeight(shared));
                }
                else
                {
                    Console.WriteLine($"FlyWeightFactory: извлекаем данные из имеющихся записей по ключу {key}");
                }
                return flyweights[key] as FlyWeight;  // или  return (FlyWeight)flyweights[key];
            }
            public void ListFlyWeight()
            {
                int count = flyweights.Count;
                Console.WriteLine("Всего записей: " + count);
                foreach (FlyWeight item in flyweights.Values)
                {
                    Console.WriteLine(item.GetData());
                }
            }
        }

        public struct Shared  // здесь находятя общие черты
        {
            private string company;
            private string position;

            public Shared(string company, string position)
            {
                this.company = company;
                this.position = position;
            }
            public string Company { get => company; }
            public string Position { get => position; }
        }

        public struct Unique
        {
            private string name;
            private string passport;

            public Unique(string name, string passport)
            {
                this.name = name;
                this.passport = passport;
            }
            public string Name { get => name; }
            public string Passport { get => passport; }
        }

        static void AddSpecialistDatabase(FlyWeightFactory ff, string name, string company, string posirion, string passport)
        {
            Console.WriteLine();
            FlyWeight flyWeight = ff.GetFlyWeight(new Shared(company, posirion));
            flyWeight.Process(new Unique(name, passport));
        }

        static void Main(string[] args)
        {
            FlyWeightFactory ff = new FlyWeightFactory(new List<Shared>()
            {
                new Shared("Yandex", "Director"),
                new Shared("Valve", "Cleaner"),
                new Shared("Google", "WEB-programmer"),
                new Shared("Apple", "IOS-programmer"),
        });
            ff.ListFlyWeight();
            AddSpecialistDatabase(ff, "Ivan", "VK", "WEB-programmer", "1925 498753");
            ff.ListFlyWeight();
            AddSpecialistDatabase(ff, "Dasha", "Yandex", "Director", "1475 120553");
            ff.ListFlyWeight();
        }
    }
}

