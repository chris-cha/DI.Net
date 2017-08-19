using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace chap1_adapter_console.HelloDI.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            //for late binding
            var typeName = ConfigurationManager.AppSettings["messageWriter"];
            var type = Type.GetType(typeName, true);
            IMessageWriter messagewriter = (IMessageWriter)Activator.CreateInstance(type);

            var salutation = new Salutation(messagewriter);
            salutation.Exclaim();
        }
    }
    public interface IMessageWriter
    {
        void Write(string message);
    }
    public class ConsoleMessageWriter:IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class Salutation
    {
        private readonly IMessageWriter _writer;
        public Salutation(IMessageWriter writer)
        {
            if(writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            this._writer = writer;
        }
        public void Exclaim()
        {
            this._writer.Write("Hello DI!");
        }
    }
}
