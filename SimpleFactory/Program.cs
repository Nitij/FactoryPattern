using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //This should be singleton
            ObjectFactory objectFactory = new ObjectFactory();
            Dictionary<String, Object> data = new Dictionary<string, object>();
            data.Add("ID", 1);
            Armour armour = objectFactory.Get(ObjectType.Armour, data) as Armour;
            Weapon weapon = objectFactory.Get(ObjectType.Weapon, data) as Weapon;

            Console.WriteLine(armour.GetInfo());
            Console.WriteLine(weapon.GetInfo());
            Console.ReadLine();
        }
    }

    #region Object

    interface IObject
    {
        String GetInfo();
    }

    class Armour : IObject
    {
        public Int32 Id;
        public String Name;
        public Int32 DefenceRating;
        public Int32 Weight;
        public String Type;

        public virtual String GetInfo()
        {
            return String.Format("Armour name is {0}. Defence rating is {1}. Type is {2}. Weight is {3}.", Name, DefenceRating, Type, Weight);
        }
    }

    class Weapon : IObject
    {
        public Int32 Id;
        public String Name;
        public Int32 DamageRating;
        public Int32 Weight;
        public String Type;

        public virtual String GetInfo()
        {
            return String.Format("Weapon name is {0}. Damage rating is {1}. Type is {2}. Weight is {3}.", Name, DamageRating, Type, Weight);
        }
    }

    enum ObjectType
    {
        Armour,
        Weapon
    }

    #endregion Object

    #region Object Factory

    class ObjectFactory
    {
        ObjectType _type;
        Dictionary<String, Object> _data;
        public IObject Get(ObjectType type, Dictionary<String, Object> data)
        {
            _type = type;
            _data = data;
            return GetObject();
        }

        public IObject GetObject()
        {
            IObject obj = null;
            Int32 id = Convert.ToInt32(_data["ID"]);

            //Fetch the object information based on the supplied type and id.
            switch(_type)
            {
                case ObjectType.Armour:
                    //Get the object info from either a database or from a metadata dictionary
                    obj = new Armour() { Id = id, Name = "Helmet of Ice", DefenceRating = 12, Weight = 2, Type = "Helmet" };
                    break;
                case ObjectType.Weapon:
                    //Get the object info from either a database or from a metadata dictionary
                    obj = new Weapon() { Id = id, Name = "Sword of Flames", DamageRating = 34, Weight = 9, Type = "Single-Handed Sword" };
                    break;
            }

            return obj;
        }
    }

    #endregion Object Factory
}
