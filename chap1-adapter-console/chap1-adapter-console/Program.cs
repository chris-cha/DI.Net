using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chap1_adapter_console
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageWriter messagewriter = new ConsoleMessageWriter();
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
