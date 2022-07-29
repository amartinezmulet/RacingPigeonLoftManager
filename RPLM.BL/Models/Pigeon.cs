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

    public class Pigeon: Bird
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
        public string BandId => string.Join(string.Empty, BandOrganization, BandYear, BandClubCode, BandSerialNumber);

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


        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pigeon p = (Pigeon)obj;
                return (BandClubCode == p.BandClubCode) &&
                        (BandOrganization == p.BandOrganization) &&
                        (BandSerialNumber == p.BandSerialNumber) &&
                        (BandYear == p.BandYear) &&
                        (Color == p.Color) &&
                        (DamBandId == p.DamBandId) &&
                        (Origin == p.Origin) &&
                        (Sex == p.Sex) &&
                        (SireBandId == p.SireBandId) &&
                        (Status == p.Status) &&
                        (Strain == p.Strain);
            }
        }

        public override int GetHashCode()
        {
            var result = BandClubCode.GetHashCode();
            if (!string.IsNullOrWhiteSpace(BandOrganization))
                result ^= BandOrganization.GetHashCode();
            if (!string.IsNullOrWhiteSpace(BandOrganization))
                result ^= BandSerialNumber.GetHashCode();
            if (!string.IsNullOrWhiteSpace(BandSerialNumber))
                result ^= BandYear.GetHashCode();
            if (!string.IsNullOrWhiteSpace(BandYear))
                result ^= Color.GetHashCode();
            if (!string.IsNullOrWhiteSpace(DamBandId))
                result ^= DamBandId.GetHashCode();
            if (!string.IsNullOrWhiteSpace(Origin))
                result ^= Origin.GetHashCode();
            if (!string.IsNullOrWhiteSpace(Sex))
                result ^= Sex.GetHashCode();
            if (!string.IsNullOrWhiteSpace(SireBandId))
                result ^= SireBandId.GetHashCode();
            if (!string.IsNullOrWhiteSpace(Status))
                result ^= Status.GetHashCode();
            if (!string.IsNullOrWhiteSpace(DamBandId))
                result ^= DamBandId.GetHashCode();
            if (!string.IsNullOrWhiteSpace(Strain))
                result ^= Strain.GetHashCode();

            return result;
        }
    }
}
