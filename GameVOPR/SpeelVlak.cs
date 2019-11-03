// <copyright file="SpeelVlak.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System.Text;
    using HenE.VierOPEenRij.Enum;

    /// <summary>
    /// Klas om speelvlak te teken.
    /// Reset het speelvlak.
    /// controleert of heeft speler gewonnen.
    /// </summary>
    public class SpeelVlak
    {
        private readonly Teken[,] veldenInHetSpeelvlak = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeelVlak"/> class.
        /// </summary>
        /// <param name="dimension">De grootte van het speelvlak.</param>
        public SpeelVlak(int dimension)
        {
            this.veldenInHetSpeelvlak = new Teken[dimension, dimension];
            this.Dimension = dimension;
        }

        /// <summary>
        /// Gets or sets dimension of the speelvlak.
        /// </summary>
        private int Dimension { get; set; }

        /// <summary>
        /// Teken het speelvlak.
        /// </summary>
        /// <param name="dimension">Hoe is het speelvlak groot is.</param>
        /// <returns>de speelvlak.</returns>
        public string TekenSpeelvlak()
        {
            StringBuilder teken = new StringBuilder();

            // Schrijft het eerste de nummer van een kolom.
            for (int columnNummer = 1; columnNummer <= this.Dimension; columnNummer++)
            {
                teken.Append($"    {columnNummer}    ");
            }

            teken.AppendLine();
            teken.AppendLine();

            for (int column = 0; column < this.Dimension; column++)
            {
                string line = string.Empty;
                for (int rij = 0; rij < this.Dimension; rij++)
                {
                    if (this.veldenInHetSpeelvlak[column, rij] == Teken.Undefined)
                    {
                        if (rij == 0)
                        {
                            teken.Append("      ");
                        }
                        else
                        {
                            teken.Append("   ");
                        }
                    }
                    else
                    {
                        teken.Append($"   {this.veldenInHetSpeelvlak[column, rij].ToString()}   ");
                    }

                    if (column != this.Dimension - 1)
                    {
                        teken.Append("  |   ");
                        if (rij != this.Dimension - 1)
                        {
                            line += "--------+";
                        }
                    }
                }

                if (column != this.Dimension - 1)
                {
                    line += "---------";
                }

                teken.AppendLine();
                teken.Append(line);
                teken.AppendLine();
            }

            return teken.ToString();
        }

        /// <summary>
        /// Reset the table.
        /// </summary>
        /// <param name="dimension">De grootte van het speelvlak waar de method loopt door.</param>
        public void ResetSpeelVlak()
        {
            for (int rij = 0; rij < this.Dimension; rij++)
            {
                for (int column = 0; column < this.Dimension; column++)
                {
                    this.ResetVeld(rij, column);
                }
            }
        }

        /// <summary>
        /// Reset one cell.
        /// </summary>
        /// <param name="rij">Het nummer  van de rij.</param>
        /// <param name="column">Het nummer van de column.</param>
        public void ResetVeld(int rij, int column)
        {
            this.veldenInHetSpeelvlak[rij, column] = Teken.Undefined;
        }

        /// <summary>
        /// Check of de column nog een vrij veld heeft of niet.
        /// </summary>
        /// <param name="column">De nummer van de column waar de method door loopt.</param>
        /// <returns>Heeft deze column een vrij veld of niet.</returns>
        public bool MagInzetten(int column)
        {
            for (int index = 0; index < this.Dimension; column++)
            {
                if (this.veldenInHetSpeelvlak[index, column] == Teken.Undefined)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check of het speelvlak vol of nog niet helemaal is.
        /// </summary>
        /// <param name="dimension">De grootte van het speelvlak.</param>
        /// <returns>Is het speelvlak vol of nog niet.</returns>
        public bool IsSpeelvlakVol(int dimension)
        {
            for (int rij = 0; rij < dimension; rij++)
            {
                for (int column = 0; column < dimension; column++)
                {
                    if (this.veldenInHetSpeelvlak[rij, column] == Teken.Undefined)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Zet de teken op het speelvlak.
        /// </summary>
        /// <param name="inzet">Waar de speler wil inzetten.</param>
        /// <param name="teken">De teken van de speler.</param>
        public void TekenInzetten(int inzet, Teken teken)
        {
            int inzetNummer = 0;
            for (int kolom = 0; kolom < this.Dimension; kolom++)
            {
                if (this.veldenInHetSpeelvlak[kolom, inzet] == Teken.Undefined)
                {
                    inzetNummer = kolom;
                }
                else
                {
                    this.veldenInHetSpeelvlak[inzetNummer, kolom] = teken;
                }
            }
        }

        /// <summary>
        /// controleert of het speelvlak heeft het zelfde teken op vier velden.
        /// </summary>
        /// <param name="teken">De teken.</param>
        /// <returns>Heeft de speler gewonnen of niet.</returns>
        public bool HeeftGewonnen(Teken teken)
        {
                bool heeftIemandGewonnen = false;

                // wanneer heeft een teken gewonnen?
                // horizontaal een hele rij
                // roep voor elke row op het bord de functie AreAllFieldsInTheRowEqual aan
                for (int rij = 0; rij < this.Dimension && !heeftIemandGewonnen; rij++)
                {
                    heeftIemandGewonnen = this.AreAllFieldsInTheRowEqualTo(rij, teken);
                    if (heeftIemandGewonnen)
                    {
                        return true;
                    }
                }

                // verticaal een hele rij
                for (int col = 0; col < this.Dimension && !heeftIemandGewonnen; col++)
                {
                    heeftIemandGewonnen = this.AreAllFieldsInTheColEqualTo(col, teken);

                    if (heeftIemandGewonnen)
                    {
                        return true;
                    }
                }

                heeftIemandGewonnen = true;

                for (short colrow = 0; colrow < this.Dimension; colrow++)
                {
                    if (this.veldenInHetSpeelvlak[colrow, colrow] != teken)
                    {
                        heeftIemandGewonnen = false;
                        break;
                    }
                }

                if (heeftIemandGewonnen)
                {
                    return heeftIemandGewonnen;
                }

                // van rechtsboven naar linksonder
                int maxDim = this.Dimension;
                maxDim--;

                heeftIemandGewonnen = true;

                for (int row = 0; row < this.Dimension; row++)
                {
                    if (this.veldenInHetSpeelvlak[maxDim--, row] != teken)
                    {
                        heeftIemandGewonnen = false;
                        break;
                    }
                }

                return heeftIemandGewonnen;
        }

        /// <summary>
        /// controleer of de row heeft het zelfde teken.
        /// </summary>
        /// <param name="rij">rij.</param>
        /// <param name="teken">teken.</param>
        /// <returns>False of true.</returns>
        private bool AreAllFieldsInTheRowEqualTo(int rij, Teken teken)
        {
            for (int col = 0; col < this.Dimension; col++)
            {
                if (this.veldenInHetSpeelvlak[col, rij] != teken)
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreAllFieldsInTheColEqualTo(int col, Teken teken)
        {
            for (int rij = 0; rij < this.Dimension; rij++)
            {
                if (this.veldenInHetSpeelvlak[col, rij] != teken)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
