


using ConsoleUtility;

namespace ConsoleUtilityExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var listener = new TCPListener(12000);

            listener.Start();

            new Thread(() =>
            {
                listener.AcceptClientLoop();
            }).Start();


            var client = new TCPClient(12000);
            client.Connect();


            while (true)
            {
                var request = Console.ReadLine();

                client.SendRequest(request);

                Console.WriteLine($"Request: {request}");


                var response = client.RecieveResponse();

                Console.WriteLine($"Response: {response}");

            }



        }
    }
}