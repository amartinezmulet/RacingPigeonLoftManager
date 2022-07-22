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

    public class Pigeon
    {
        /// <summary>
        /// Gets the band identifier.
        /// </summary>
        /// <value>
        /// Band numbers are in a series of letters & numbers. Ex AU2022LOU1234
        /// </value>
        public string BandId => string.Join("", BandOrganization, BandYear, BandClubCode, BandSerialNumber);
        /// <summary>
        /// Gets or sets the band organization. Is the national organization that has registered the pigeon.
        /// </summary>
        /// <value>
        /// Initials of the organization. Ex. AU (American Racing Pigeon Union, Inc.)
        /// </value>
        public string BandOrganization { get; set; }
        /// <summary>
        /// Gets or sets the band year.
        /// </summary>
        /// <value>
        ///  Is the year the bird was hatched and banded/registered. Ex. 2022
        /// </value>
        public int BandYear { get; set; }
        /// <summary>
        /// Gets or sets the band club code.
        /// </summary>
        /// <value>
        ///  One, two or three lettersletters representing the pigeon club the band is registered to. Ex. LOU (Louisville)
        /// </value>
        public string BandClubCode { get; set; }
        /// <summary>
        /// Gets or sets the band serial number.
        /// </summary>
        /// <value>
        /// A one-up number unique to each pigeon based on the club letters. Ex. 1234
        /// </value>
        public string BandSerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the pigeon's color identifier.
        /// </summary>
        /// <value>
        /// The color identifier.
        /// </value>
        public int ColorId { get; set; }
        /// <summary>
        /// Gets or sets the sex of the pigeon.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public SexIdentification Sex { get; set; }

        /// <summary>
        /// Gets or sets the date that the pigeon hatched.
        /// </summary>
        /// <value>
        /// The hatch date.
        /// </value>
        public DateTime HatchDate { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin of the pigeon (Bred in Loft, Received as gift or Purchased)
        /// </value>
        public OriginType Origin { get; set; }

        /// <summary>
        /// Gets or sets the strain identifier.
        /// </summary>
        /// <value>
        ///  Stock line, ancestry Ex. (Janssen, Meuleman, Trenton, etc)
        /// </value>
        public int StrainId { get; set; }

        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public PigeonStatus Status { get; set; }

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
