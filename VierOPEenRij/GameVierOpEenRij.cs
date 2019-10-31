// <copyright file="GameVierOpEenRij.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HenE.VierOPEenRij.Enum;

    /// <summary>
    /// Gaat over het spel.
    /// </summary>
    public class GameVierOpEenRij
    {
        private readonly List<Speler> spelers = new List<Speler>();

        /// <summary>
        /// Gets or sets hudige speler.
        /// </summary>
        private Speler HuidigeSpeler { get; set; }

        /// <summary>
        /// Initialiseert Het Spel.
        /// change the status of the speler.
        /// </summary>
        public void InitialiseerHetSpel()
        {
            foreach (Speler speler in this.spelers)
            {
                speler.ChangeStatus(Status.Gestart);
            }
        }

        /// <summary>
        /// Voeg een nieuwe speler aan het spel toe.
        /// </summary>
        /// <param name="naam">De naam van de nieuwe speler.</param>
        public void AddHumanSpeler(string naam)
        {
            this.spelers.Add(new HumanSpeler(naam));
        }

        /// <summary>
        /// Geef de tegen huidige speler terug.
        /// </summary>
        /// <param name="huidigeSpeler">De huidige speler.</param>
        /// <returns>Tegen huidige speler.</returns>
        public Speler TegenSpeler(Speler huidigeSpeler)
        {
            if (huidigeSpeler == null)
            {
                throw new ArgumentNullException("Er zijn geen speler.");
            }

            foreach (Speler speler in this.spelers)
            {
                if (huidigeSpeler != speler)
                {
                    return speler;
                }
            }

            return null;
        }
    }
}
