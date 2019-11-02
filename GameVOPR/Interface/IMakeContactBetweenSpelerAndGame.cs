// <copyright file="IDoContactBetweenSpelerAndGame.cs" company="PlaceholderCompany">
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
    public interface IMakeContactBetweenSpelerAndGame
    {
        /// <summary>
        /// Vraagt de speler om zijn naam te geven.
        /// </summary>
        /// <param name="vraag">De vraag.</param>
        /// <returns>De naam van de speler.</returns>
        string VraagNaam(string vraag);

        /// <summary>
        /// Vraag de speler of hij wil stopen.
        /// </summary>
        /// <param name="vraag">De vraag.</param>
        /// <returns>Het antwoord.</returns>
        string WilStopen(string vraag);
    }
}
