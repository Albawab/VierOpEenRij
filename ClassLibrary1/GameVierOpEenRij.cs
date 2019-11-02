// <copyright file="GameVierOpEenRij.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using System.Collections.Generic;
    using HenE.VierOPEenRij.Enum;

    /// <summary>
    /// Gaat over het spel.
    /// </summary>
    public class Game
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
        /// <returns>De nieuwe speler.</returns>
        public Speler AddHumanSpeler(string naam)
        {
            Speler speler = new HumanSpeler(naam);
            this.spelers.Add(speler);
            return speler;
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

        /// <summary>
        /// Voeg een nieuwe speler toe.
        /// Verandert de situatie van een speler.
        /// </summary>
        /// <param name="naam">De naam van een nieuwe speler.</param>
        /// <param name="status">De situatie van een speler.</param>
        public void HandlSpeler(string naam, Status status)
        {
            // Voeg een speler aan het spel toe.
            Speler speler = this.AddHumanSpeler(naam);

            // Chang the status of the speler.
            speler.ChangeStatus(status);
        }

        /// <summary>
        /// Chack of de speler mag spelen.
        /// </summary>
        /// <returns>Mag spelen of niet.</returns>
        public bool KanStarten()
        {
            if (this.spelers.Count == 2)
            {
                return true;
            }

            return false;
        }
    }
}
