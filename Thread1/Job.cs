using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread1
{
    delegate void DelegatoJob(string messaggio);

    internal class Job
    {
        private string _nome;
        private Random _random;

        public event DelegatoJob OnJob;
        public event DelegatoJob EndJob;

        public Job(string nome, Random random)
        {
            this._nome = nome;
            this._random = random;
        }

        // Metodo da eseguire in parallelo al Main
        public void DoWork()
        {
            // 10 step di lavoro fake...
            for(int i=0; i < 10; i++)
            {
                OnJob(this._nome + ": " + i);
                Thread.Sleep(this._random.Next(300, 800));
            }
            EndJob(this._nome);
        }
    }
}
