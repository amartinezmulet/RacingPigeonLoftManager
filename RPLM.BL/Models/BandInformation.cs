using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.Models
{
    public class BandInformation
    {
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
        public string BandYear { get; set; }
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
        /// Gets the band identifier.
        /// </summary>
        /// <value>
        /// Band numbers are in a series of letters & numbers. Ex AU2022LOU1234
        /// </value>
        public string BandId => string.Join("", BandOrganization, BandYear, BandClubCode, BandSerialNumber);
    }
}
