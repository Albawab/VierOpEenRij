// <copyright file="ComputerSpeler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.GameVOPR
{
    using System;
    using HenE.VierOPEenRij;
    using HenE.VierOPEenRij.Enum;
    using HenE.VierOPEenRij.Interface;

    /// <summary>
    /// Gaat met de computer om.
    /// </summary>
    public class ComputerSpeler : Speler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputerSpeler"/> class.
        /// </summary>
        /// <param name="naam">De naam van de speler.</param>
        public ComputerSpeler(string naam)
            : base(naam)
        {
        }

        /// <inheritdoc/>
        public override int DoeZet(string vraag)
        {
            return 5;
        }

/*        /// <summary>
        /// Zet een teken die de speler het gaat gebruiken.
        /// </summary>
        /// <param name="teken">De teken.</param>
        public new void ZetTeken(Teken teken) { }*/
    }
}
