namespace GBCS.GB
{
    public class Log
    {
        private readonly StringWriter _writer = new();

        private readonly string _name;

        public Log(string name)
        {
            _name = name;
        }

        public void LogLn(string str, params object[] args)
        {
            _writer.WriteLine(str, args);
        }

        public void ToFile()
        {

            using StreamWriter outputFile = new(Path.Combine(Directory.GetCurrentDirectory(), _name + ".txt"));
            outputFile.Write(_writer.ToString());
            _writer.Close();
        }
    }
}