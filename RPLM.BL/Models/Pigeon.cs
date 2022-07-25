using RPLM.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    /// <summary>
    /// Pigeon
    /// </summary>
    /// <seealso cref="RPLM.BL.Bird" />

    public class Pigeon:BandInformation
    {
        /// <summary>
        /// Gets the band identifier.
        /// </summary>
        /// <value>
        /// Band numbers are in a series of letters & numbers. Ex AU2022LOU1234
        /// </value>
        public string BandId => string.Join("", BandOrganization, BandYear, BandClubCode, BandSerialNumber);

        /// <summary>
        /// Gets or sets the pigeon's color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public string Color { get; set; }
        /// <summary>
        /// Gets or sets the sex of the pigeon.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public string Sex { get; set; }

        /// <summary>
        /// Gets or sets the date that the pigeon hatched.
        /// </summary>
        /// <value>
        /// The hatch date.
        /// </value>
        public DateTime? HatchDate { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin of the pigeon (Bred in Loft, Received as gift or Purchased)
        /// </value>
        public string Origin { get; set; }

        /// <summary>
        /// Gets or sets the strain identifier.
        /// </summary>
        /// <value>
        ///  Stock line, ancestry Ex. (Janssen, Meuleman, Trenton, etc)
        /// </value>
        public string Strain { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the sire band identifier.
        /// </summary>
        /// <value>
        /// The sire band identifier.
        /// </value>
        public string SireBandId { get; set; }

        /// <summary>
        /// Gets or sets the dam band identifier.
        /// </summary>
        /// <value>
        /// The dam band identifier.
        /// </value>
        public string DamBandId { get; set; }

    }
}
