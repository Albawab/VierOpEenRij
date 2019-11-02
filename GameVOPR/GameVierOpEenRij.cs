// <copyright file="GameVierOpEenRij.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using System.Collections.Generic;
    using HenE.GameVOPR;
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
        public Speler HuidigeSpeler { get; private set; }

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
        /// Voeg een nieuwe computer speler aan het spel toe.
        /// </summary>
        /// <param name="naam">De naam van de nieuwe speler.</param>
        /// <returns>De nieuwe speler.</returns>
        public Speler AddComputerSpeler(string naam)
        {
            Speler speler = new ComputerSpeler(naam);
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
            Speler speler;
            if (naam == "Computer")
            {
                speler = this.AddComputerSpeler(naam);
            }
            else
            {
                // Voeg een speler aan het spel toe.
                speler = this.AddHumanSpeler(naam);
            }

            HuidigeSpeler = speler;
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

        /// <summary>
        /// Geeft de spelers van het speler terug geven.
        /// </summary>
        /// <returns></returns>
        public List<Speler> GeefSpeler()
        {
            List<Speler> _spelers = new List<Speler>();
            foreach (Speler speler in this.spelers)
            {
                _spelers.Add(speler);
            }
            return _spelers;
        }

        /// <summary>
        /// tekent op het speelvlak het teken die de speler wil inzetten op het speelvlak.
        /// </summary>
        /// <param name="inzet">De keuze van de speler.</param>
        /// <param name="speelVlak">Het speelvalk.</param>
        /// <param name="teken">Het teken van de speler.</param>

        public void TekentOpSpeelvlak(int inzet, SpeelVlak speelVlak, Teken teken)
        {
            if (teken == Teken.Undefined)
            {
               // throw new ArgumentOutOfRangeException("Mag niet de teken Umdefined zijn of null.");
            }
            if (speelVlak == null)
            {
                throw new ArgumentNullException("mag niet het speelvlak null zijn.");
            }

            if (inzet <= 0)
            {
                throw new ArgumentOutOfRangeException("Mag niet het inzet nul of minder zijn.");
            }
            speelVlak.TekenInzetten(inzet, teken);
        }

        /// <summary>
        /// Check of de speler heeft gewonnen of niet.
        /// </summary>
        /// <param name="speelVlak">Het speelvlak</param>
        /// <param name="teken">De teken van de speler die zal nagaan.</param>
        /// <returns>Heeft vier op een rij of niet.</returns>
        public bool HeeftGewonnen(SpeelVlak speelVlak, Teken teken)
        {
            /*return speelVlak.HeeftGewonnen(teken);*/
            return false;
        }
    }
}
