using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordcount.Contracts;

namespace Wordcount.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress ep = new EndpointAddress("http://localhost:8080/test/user");
            ChannelFactory<IWordsCount> channelFac = new ChannelFactory<IWordsCount>(
                new BasicHttpBinding(), ep);
            IWordsCount proxy = null;
            try
            {
                proxy = channelFac.CreateChannel();
                Request rq = new Request();

                Console.WriteLine("Write a short Text.");
                Console.Write("Text:");
                rq.Text = Console.ReadLine();

                Console.WriteLine("Your Text:");
                Console.WriteLine(rq.Text);
                Console.WriteLine("");
                Console.WriteLine("which word is to be counted?");

                Console.Write("Word:");
                rq.CountedWord = Console.ReadLine();
      
                Response r = proxy.countWords(rq);

               
                Console.WriteLine("Absolute Searched Word Count: " + r.AbsolutCount);
                Console.WriteLine("Relative Searched Word Count: " + r.RelativeCount + "%");
                Console.WriteLine("Total Words: " + r.TotalCount);

                Console.WriteLine("hit enter to exit");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (proxy != null)
                    ((ICommunicationObject)proxy).Abort();
            }

            Console.ReadLine();

        }
    }
}
