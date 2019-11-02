using HenE.VierOPEenRij;
using HenE.VierOPEenRij.Interface;
using System;

namespace HenE.GameVOPR
{
    public class ComputerSpeler : Speler
    {
        public ComputerSpeler(String naam) : base(naam)
        {
        }

        public override int DoeZet(string Vraag)
        {
            return 5;
        }
    }
}
