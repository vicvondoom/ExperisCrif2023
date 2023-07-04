using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSingleton
{
    internal class SingletonConfig
    {
        // variabile che rappresenta la classe stessa
        private static SingletonConfig _instance = null;
        // Rendo utile questo Singleton
        private string _username;
        private string _password;

        // Il costruttore è privato (non è abstract)!
        private SingletonConfig()
        { 
        
        }

        public static SingletonConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Il costruttore è privato, ma dalla classe posso fare la new!
                    _instance = new SingletonConfig();
                    string riga = File.ReadAllText("./config.txt");
                    _instance._username = riga.Split(";")[0];
                    _instance._password = riga.Split(";")[1];
                }
                return _instance;
            }
        }

        public string Username { get => _instance._username;  }
        public string Password { get => _instance._password;  }
    }
}
