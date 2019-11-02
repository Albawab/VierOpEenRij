// <copyright file="EnumHepler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij.Enum
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// helpt de situatie.
    /// </summary>
    public class EnumHepler
    {
        /// <summary>
        /// Omzetten de situatie van string tot een situatie.
        /// </summary>
        /// <param name="value">De situatie als string.</param>
        /// <returns>Geeft de situatie terug.</returns>
        public T EnumConvert<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
