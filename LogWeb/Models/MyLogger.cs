namespace LogWeb.Models
{
    public class MyLogger
    {
        private string _pathLog = "";
        public MyLogger(string pathLog)
        {
            _pathLog = pathLog; 
        }
        public void Write(string message)
        {
            File.AppendAllText(_pathLog, message + Environment.NewLine);
        }
    }
}
