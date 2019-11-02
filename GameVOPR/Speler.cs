// <copyright file="Speler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HenE.VierOPEenRij.Enum;

    /// <summary>
    /// Vraagt de speler om zet te doen.
    /// Vraag de speler om naam te geven.
    /// </summary>
    public abstract class Speler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Speler"/> class.
        /// </summary>
        /// <param name="naam">De naam van de speler.</param>
        public Speler(string naam)
        {
            this.Naam = naam;
        }

        /// <summary>
        /// Gets or sets Teken van de speler.
        /// </summary>
        public Teken GebruikTeken { get; private set; }

        /// <summary>
        /// Gets or sets het situatie van een speler.
        /// </summary>
        private Status SpelerSituatie { get; set; }

        /// <summary>
        /// Gets or sets de naam van de speler.
        /// </summary>
        private string Naam { get; set; }

        /// <summary>
        /// Verandert het situatie van een speler.
        /// </summary>
        /// <param name="status">Het nieuwe situatie.</param>
        public void ChangeStatus(Status status)
        {
            this.SpelerSituatie = status;
        }

        /// <summary>
        /// Vraag de speler om een zet te doen.
        /// </summary>
        /// <param name="vraag">De inzet.</param>
        /// <returns>Het nummer die de speler wil inzetten.</returns>
        public abstract int DoeZet(string Vraag);
    }
}
