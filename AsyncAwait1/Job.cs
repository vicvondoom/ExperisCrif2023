using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait1
{
    internal class Job
    {
        private string _nome;

        public Job(string nome)
        {
            _nome = nome;
        }

        public async Task<int> DoWork()
        {
            int i = 0;
            for(i=0; i<10; i++)
            {
                Console.WriteLine(this._nome + ": " +i);
                await Task.Delay(250);
            }
            return i;
        }
    }
}
