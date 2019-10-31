// <copyright file="IDoContactWithSpeler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Stel een vraag en ontvang antwoord van een speler.
    /// </summary>
    public interface IDoContactBetweenSpelerAndGame
    {
        /// <summary>
        /// Vraag de speler om een zet te doen.
        /// </summary>
        /// <param name="vraag">De inzet.</param>
        /// <returns>Het nummer die de speler wil inzetten.</returns>
        int Dozet(string vraag);

        /// <summary>
        /// Vraag de speler of hij wil stopen.
        /// </summary>
        /// <param name="vraag">De vraag.</param>
        /// <returns>Het antwoord.</returns>
        string WilStopen(string vraag);
    }
}
