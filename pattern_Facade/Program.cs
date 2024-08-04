using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_Facade
{
    public class ProviderCommunication 
    { 
        public void Receive() {
            Console.WriteLine("Продукция получена от поставщика");
        }

        public void Payment()
        {
            Console.WriteLine("Оплата поставщику с продажи товара");
        }
    }

    public class Site {
        public void Plasement() => Console.WriteLine("Размещение на сайте");
        public void Delete() => Console.WriteLine("Удаление с сайта");
    }

    public class DataBase 
    {
        public void Insert() => Console.WriteLine("Добавление в БД");
        public void Delete() => Console.WriteLine("Удаление из БД");
    }

    public class MarketPlace {    // это Фасад!
        private ProviderCommunication ProviderCommunication;
        private Site Site;
        private DataBase DataBase;

        public MarketPlace()
        {
            ProviderCommunication = new ProviderCommunication();
            Site = new Site();
            DataBase = new DataBase();
        }

        public void ProductReceip()
        {
            ProviderCommunication.Receive();
            Site.Plasement();
            DataBase.Insert();
        }

        public void ProductSale()
        {
            ProviderCommunication.Payment();
            Site.Delete();
            DataBase.Delete();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //ProviderCommunication pc = new ProviderCommunication();
            //pc.Receive();

            //Site site= new Site();
            //site.Plasement();

            //DataBase db = new DataBase();
            //db.Insert();  чтобы не писать это все каждый раз используем фасад:

            MarketPlace marketPlace = new MarketPlace();
            marketPlace.ProductReceip();    //  Продукция получена от поставщика
                                            //  Размещение на сайте
                                            //  Добавление в БД
            Console.WriteLine("--------------------");
            marketPlace.ProductSale();  //  Оплата поставщику с продажи товара
                                        //  Удаление с сайта
                                        //  Удаление из БД
        }
    }
}
