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
    internal class HumanSpeler : Speler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanSpeler"/> class.
        /// </summary>
        /// <param name="naam">De naam van een speler.</param>
        public HumanSpeler(string naam)
            : base(naam)
        {
        }

        /// <summary>
        /// Gets or sets de naam van de speler.
        /// </summary>
        private string Naam { get; set; }

        /// <summary>
        /// Zet een teken die de speler het gaat gebruiken.
        /// </summary>
        /// <param name="teken">De teken.</param>
        public void ZetTeken(Teken teken)
        {
            this.GebruikTeken = teken;
        }
    }
}
