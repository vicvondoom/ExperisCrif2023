using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread2File
{
    internal class Job
    {
        private string _nome;
        private object _locker;

        public Job(string nome, object locker)
        {
            _nome = nome;
            _locker = locker;
        }

        public void DoWork()
        {
            // 10 step di lavoro fake...
            for (int i = 0; i < 10; i++)
            {
                lock(_locker)
                {
                    FileStream fs = new FileStream("./log.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(this._nome + " ha eseguito step " + i);
                    sw.Close();
                    fs.Close();
                }

                Thread.Sleep(200);
            }

        }
    }
}
