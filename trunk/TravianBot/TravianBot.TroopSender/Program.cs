﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravianBot.TroopSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp(args);
            consoleApp.Parse();
            consoleApp.Process();
        }
    }
}