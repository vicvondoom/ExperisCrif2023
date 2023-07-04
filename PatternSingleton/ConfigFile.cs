using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSingleton
{
    internal class ConfigFile
    {
        private string _username;
        private string _password;

        public ConfigFile()
        {
            // Leggo da un file i dati
            string riga = File.ReadAllText("./config.txt");
            _username = riga.Split(";")[0];
            _password = riga.Split(";")[1];
        }

        public string Username { get => _username; }
        public string Password { get => _password;  }
    }
}
