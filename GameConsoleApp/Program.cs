using HenE.VierOPEenRij.Interface;
using System;

namespace HenE.GameVierOpEenRij
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanHandelen handler = new Handler();
            handler.StreamOntvanger("Abdul%Gestart");
            handler.StreamOntvanger("Computer%Gestart");
            Console.ReadLine();
        }
    }
}
