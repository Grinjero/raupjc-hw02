using OperationAnswers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadOperations;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() =>  Operations.LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
    }
}
