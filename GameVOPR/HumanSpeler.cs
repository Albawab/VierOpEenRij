// <copyright file="HumanSpeler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using HenE.VierOPEenRij.Enum;
    using HenE.VierOPEenRij.Interface;

    /// <summary>
    /// Gaat over de Humanspeler.
    /// </summary>
    internal class HumanSpeler : Speler, IMakeContactBetweenSpelerAndGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanSpeler"/> class.
        /// </summary>
        /// <param name="naam">De naam van een speler.</param>
        public HumanSpeler(string naam)
            : base(naam)
        {
        }

        /// <inheritdoc/>
        public override int DoeZet(string vraag)
        {
            Console.WriteLine("Kies een nummer");
            string antwoord = Console.ReadLine();
            int inzet = 0;
            int.TryParse(antwoord, out inzet);
            return inzet;
        }

        /// <inheritdoc/>
        public string VraagNaam(string vraag)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public string WilStopen(string vraag)
        {
            throw new NotImplementedException();
        }

/*        /// <summary>
        /// Zet een teken die de speler het gaat gebruiken.
        /// </summary>
        /// <param name="teken">De teken.</param>
        public new void ZetTeken(Teken teken)
        {
        }*/
    }
}
