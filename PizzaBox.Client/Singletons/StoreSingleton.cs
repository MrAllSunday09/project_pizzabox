using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Client.Singletons
{
    public class StoreSingleton
    {
        public static List<AStore> stores = new List<AStore>
        {
            new ChicagoStore(),
            new NewYorkStore()
        };

        private static readonly StoreSingleton _instance;
        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new StoreSingleton();
                }
            return _instance;
            }
        }

        private StoreSingleton()
        {
            stores = new List<AStore>();
        }
    }
}