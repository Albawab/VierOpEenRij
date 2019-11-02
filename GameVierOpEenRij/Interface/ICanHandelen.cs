// <copyright file="ICanHandelen.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// interface waar de handeler de stream gaat handelen.
    /// </summary>
    public interface ICanHandelen
    {
        /// <summary>
        /// Ontvangt de stream.
        /// gaat er over controlleren.
        /// </summary>
        /// <param name="streamk">De stream die van een persoon komt.</param>
        void StreamOntvanger(string streamk);

        /// <summary>
        /// Functie om de stream te splitsen.
        /// </summary>
        /// <param name="stream">De stream die van een persoon komt.</param>
        void SplitsDeStream(string stream);


        /// <summary>
        /// Chack of mag spelen.
        /// Als ja dan staart het spel.
        /// als Nee Wacht op andere speler.
        /// </summary>
        void HandlHetSpel();
    }
}
