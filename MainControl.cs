
using System;

namespace deee
{
    class MainControl
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Worldff!");
            Initialize();
            RunLoop();
            
        }

        static void Initialize()
        {
            WorldController.Initialize();
        }

        static void RunLoop()
        {
            while (true)
            {
                WorldController.Loop();
                Drawer.Loop();
            }
        }
    }
}
