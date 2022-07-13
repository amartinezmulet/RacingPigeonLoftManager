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

    public class Pigeon:Bird
    {
        public string BandIdNumber { get; set; }
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
        /// The origin of the pigeon (Bred, Gift or Purchased)
        /// </value>
        public OriginType Origin { get; set; }

        /// <summary>
        /// Gets or sets the strain identifier.
        /// </summary>
        /// <value>
        /// The strain identifier.
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
