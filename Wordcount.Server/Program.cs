using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordcount.Contracts;

namespace Wordcount.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(Wordcount));
                host.AddServiceEndpoint(typeof(IWordsCount), new BasicHttpBinding(), new Uri("http://localhost:8080/test/user"));
                host.Open();
                Console.WriteLine("hit enter to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (host != null)
                    host.Close();
            }
        }
    }
}