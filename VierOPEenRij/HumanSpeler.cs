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
        /// Gets or sets Teken van de speler.
        /// </summary>
        private Teken GebruikTeken { get; set; }

        /// <summary>
        /// Gets or sets het situatie van een speler.
        /// </summary>
        private Status SpelerSituatie { get; set; }

        /// <summary>
        /// Verandert het situatie van een speler.
        /// </summary>
        /// <param name="status">Het nieuwe situatie.</param>
        public void ChangeStatus(Status status)
        {
            this.SpelerSituatie = status;
        }

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
