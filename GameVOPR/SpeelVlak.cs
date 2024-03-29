﻿// <copyright file="SpeelVlak.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HenE.VierOPEenRij
{
    using System.Collections.Generic;
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
        /// Gets dimension of the speelvlak.
        /// </summary>
        public int Dimension { get; private set; }

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

            for (int columnNummer = 0; columnNummer < this.Dimension; columnNummer++)
            {
                string line = string.Empty;
                for (int doorKolom = 0; doorKolom < this.Dimension; doorKolom++)
                {
                    if (this.veldenInHetSpeelvlak[doorKolom, columnNummer] == Teken.Undefined)
                    {
                        if (doorKolom == 0)
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
                        if (doorKolom == 0)
                        {
                            teken.Append("   ");
                        }

                        teken.Append($" {this.veldenInHetSpeelvlak[doorKolom, columnNummer].ToString()} ");
                    }

                    if (columnNummer < this.Dimension)
                    {
                        teken.Append("  |   ");
                        if (doorKolom < this.Dimension)
                        {
                            line += "--------+";
                        }
                    }
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
        /// <param name="columnNummer">De nummer van de column waar de method door loopt.</param>
        /// <returns>Heeft deze column een vrij veld of niet.</returns>
        public bool MagInzetten(int columnNummer)
        {
            for (int kol = 0; kol < this.Dimension; kol++)
            {
                if (this.veldenInHetSpeelvlak[columnNummer, kol] == Teken.Undefined)
                {
                    return true;
                }

                return false;
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
        /// <param name="inzet">Waar de speler wil zetten.</param>
        /// <param name="teken">De teken van de speler.</param>
        /// <returns>Het nummer in de kolom die wordt gebruiken om teken te zetten.</returns>
        public int ZetTekenOpSpeelvlak(int inzet, Teken teken)
        {
            int inzetNummer = 0;
            for (int kolom = 0; kolom < this.Dimension; kolom++)
            {
                // als de veld vrij is.
                if (this.veldenInHetSpeelvlak[inzet, kolom] == Teken.Undefined)
                {
                    inzetNummer = kolom;
                    if (kolom == this.Dimension - 1)
                    {
                        // zet teken als de veld vrij is.
                        this.veldenInHetSpeelvlak[inzet, kolom] = teken;
                        return inzetNummer;
                    }
                }
                else
                {
                    if (this.veldenInHetSpeelvlak[inzet, inzetNummer] == Teken.Undefined)
                    {
                        this.veldenInHetSpeelvlak[inzet, inzetNummer] = teken;
                        return inzetNummer;
                    }
                }
            }

            return inzetNummer;
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
                heeftIemandGewonnen = this.ZijnErVierTekenGelijkInEenKolom(rij, teken);
                if (heeftIemandGewonnen)
                {
                    return true;
                }
            }

            // verticaal een hele rij
            for (int col = 0; col < this.Dimension && !heeftIemandGewonnen; col++)
            {
                heeftIemandGewonnen = this.ZijnErVierTekenGelijkInEenRij(col, teken);

                if (heeftIemandGewonnen)
                {
                    return true;
                }
            }

            heeftIemandGewonnen = true;

            for (int colrow = 0; colrow < this.Dimension; colrow++)
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

            // richtboven naar linksonder.
            // kolom naar rij
            int aantalTekenOpEenRij = 0;

            // Vanaf rij 3 starten.
            for (int kolom = 3; kolom < this.Dimension; kolom++)
            {
                int kolomNummer = kolom;
                int rijNummer = 0;
                for (int rij = 0; rij < kolom; rij++)
                {

                    if (this.veldenInHetSpeelvlak[kolomNummer--, rijNummer++] == teken)
                    {
                        aantalTekenOpEenRij++;
                    }
                    else
                    {
                        aantalTekenOpEenRij = 0;
                    }
                }
            }

            for (int kolom = this.Dimension - 1; kolom > 3; kolom--)
            {
                int kolomNummer = kolom;
                int rijNummer = 0;
                for (int rij = 0; rij < kolom; rij++)
                {

                    if (this.veldenInHetSpeelvlak[kolomNummer--, rijNummer++] == teken)
                    {

                    }
                }
            }

            for (int kolom = this.Dimension -3; kolom == 0; kolom--)
            {
                int kolomNummer = kolom;
                int rijNummer = 0;
                for (int rij = 0; rij < this.Dimension-1; rij++)
                {
                    if (kolomNummer == this.Dimension-1)
                    {
                        break;
                    }
                    if (this.veldenInHetSpeelvlak[kolomNummer++, rijNummer++] == teken)
                    {

                    }
                }

            }

            for (int kolom = 0; kolom < this.Dimension - 3; kolom++)
            {
                int kolomNummer = 0;
                int rijNummer = kolom;
                for (int rij = 0; rij < this.Dimension - 1; rij++)
                {
                    if (rijNummer == this.Dimension - 1)
                    {
                        break;
                    }
                    if (this.veldenInHetSpeelvlak[kolomNummer++, rijNummer++] == teken)
                    {

                    }
                }

            }

            // van links boven naar links onder.

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
        /// functie om de lijst van velden terug geven.
        /// </summary>
        /// <returns>Geeft de lijst van de velden terug.</returns>
        public Teken[,] VeldenOpSpelvlak()
        {
            return this.veldenInHetSpeelvlak;
        }

        /// <summary>
        /// controleer of de rij heeft het zelfde teken.
        /// </summary>
        /// <param name="rij">Het loopt door dezen nummer.</param>
        /// <param name="teken">teken.</param>
        /// <returns>Heeft de functie vier vilden zijn gelijk of niet.</returns>
        private bool ZijnErVierTekenGelijkInEenRij(int rij, Teken teken)
        {
            int aantalTekenInEenrij = 0;
            for (int kolomNummer = 0; kolomNummer < this.Dimension; kolomNummer++)
            {
                if (aantalTekenInEenrij <= 4)
                {
                    if (this.veldenInHetSpeelvlak[kolomNummer, rij] == teken)
                    {
                        aantalTekenInEenrij++;
                    }
                    else
                    {
                        aantalTekenInEenrij = 0;
                    }
                }
            }

            if (aantalTekenInEenrij >= 4)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Controleert of de er zijn vier teken in de kolom zijn gelijk.
        /// </summary>
        /// <param name="kolomNummer">Het nummer van de kolom.</param>
        /// <param name="teken">De teken die wordt gecontroleerd.</param>
        /// <returns>Heeft de functie vier vilden zijn gelijk of niet.</returns>
        private bool ZijnErVierTekenGelijkInEenKolom(int kolomNummer, Teken teken)
        {
            // Eigenlijk is doorKolom is de rij.
            int aantalTekenInEenrij = 0;
            for (int doorKolom = 0; doorKolom < this.Dimension; doorKolom++)
            {
                if (aantalTekenInEenrij <= 4)
                {
                    if (this.veldenInHetSpeelvlak[kolomNummer, doorKolom] == teken)
                    {
                        aantalTekenInEenrij++;
                    }
                    else
                    {
                        aantalTekenInEenrij = 0;
                    }
                }
            }

            if (aantalTekenInEenrij >= 4)
            {
                return true;
            }

            return false;
        }
    }
}
