using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dllGetInfomt4;
using TradingAPI.MT4Server;
namespace ClientGetInfomt4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            new Program().Run();
        }
        void Run()
        {
            try
            {
                //MainServer srv = QuoteClient.LoadSrv(
                //@"C:\Program Files (x86)\Opo group MetaTrader 43\config\OpogroupLLC-DEMO.srv");
                QuoteClient qc = new QuoteClient(6603764, "I3qcec01", "185.65.175.144", 1950);
                Console.WriteLine("Connecting...");
                qc.Connect();
                Console.WriteLine("Connected to server");
                qc.OnQuote += new QuoteEventHandler(qc_OnQuote);
                qc.Subscribe("EURUSD!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        void qc_OnQuote(object sender, QuoteEventArgs args)
        {
            Console.WriteLine(args.Symbol + " " + args.Bid + " " + args.Ask);
            Console.ReadKey();
        }

    }
}
