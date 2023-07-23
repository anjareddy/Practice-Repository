using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton
    {
        private Singleton() 
        {
            Console.WriteLine("Constructor invoked");
        }

        public static readonly string Greetings = "Hi";
        //private static readonly Singleton _instance = new Singleton();
        //private static readonly object _instanceLock = new object();

        private static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());

        public static Singleton GetInstance()
        {

            Console.WriteLine("GetInstance invoked");
            //if (_instanceLock == null)
            //{
            //    _instance = new Singleton();
            //}
            //return _instance;

            //if (_instanceLock == null)
            //{
            //    if (_instance == null)
            //    {
            //        _instance = new Singleton();
            //    }
            //}

            //if (_instanceLock == null)
            //{
            //    if (_instance == null)
            //    {
            //        if (_instanceLock == null)
            //        {
            //            _instance = new Singleton();
            //        }
            //    }
            //}


            //return _instance;
            // return _instance ??= new Singleton();
            return _lazy.Value;

        }
    }
}
