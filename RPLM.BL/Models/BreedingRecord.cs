using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    /// <summary>
    /// BreedingRecord.
    /// </summary>
    /// <seealso cref="RPLM.BL.BreedingPair" />
    public class BreedingRecord: BreedingPair
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The breeding year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the squabs.
        /// </summary>
        /// <value>
        /// The squabs.
        /// </value>
        public List<Pigeon> Squabs { get; set; }
    }
}
