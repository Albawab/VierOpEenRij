// <copyright file="GameController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Doet controller op het spel.
    /// </summary>
    public class GameController
    {
        private readonly SpeelVlak speelVlak = null;
        private readonly Game gameVierOpEenRij = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="speelVlak">Het speelval van het spel.</param>
        /// <param name="dimension">Het grootte van het speelvlak.</param>
        /// <param name="gameVierOpEenRij">Game.</param>
        public GameController(SpeelVlak speelVlak, Game gameVierOpEenRij)
        {
            this.speelVlak = speelVlak;
            this.gameVierOpEenRij = gameVierOpEenRij;
        }

        /// <summary>
        /// Start het spel.
        /// </summary>
        public void GameStart()
        {
            this.gameVierOpEenRij.InitialiseerHetSpel();
            this.NieuwRonde();
        }

        /// <summary>
        /// Start een nieuw Rindje.
        /// </summary>
        public void NieuwRonde()
        {
            this.speelVlak.ResetSpeelVlak();
            string bord = this.speelVlak.TekenSpeelvlak();
            Console.WriteLine(bord);
            Speler speler = this.gameVierOpEenRij.HuidigeSpeler;
            while (!this.gameVierOpEenRij.HeeftGewonnen(this.speelVlak, speler.GebruikTeken))
            {
                int inzet;
                do
                {
                    inzet = speler.DoeZet(string.Empty, this.speelVlak, this.gameVierOpEenRij);
                }
                while (!this.speelVlak.MagInzetten(inzet));

                this.gameVierOpEenRij.TekentOpSpeelvlak(inzet, this.speelVlak, speler.GebruikTeken);
                bord = this.speelVlak.TekenSpeelvlak();
                Console.WriteLine(bord);
                speler = this.gameVierOpEenRij.TegenSpeler(speler);
            }

            // heeft gewonnen?

            /*
            this.speelVlak.TekenSpeelvlak(this.dimension);
            int z
            do
            {
                speler.Doezet();
            } while (true);
            speler.*/
        }
    }
}
