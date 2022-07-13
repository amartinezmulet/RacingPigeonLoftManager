using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    /// <summary>
    /// BreedingPair
    /// </summary>
    public class BreedingPair
    {
        /// <summary>
        /// Gets or sets the box number.
        /// </summary>
        /// <value>
        /// The box number.
        /// </value>
        public int BoxNumber { get; set; }
        /// <summary>
        /// Gets or sets the pair number.
        /// </summary>
        /// <value>
        /// The pair number.
        /// </value>
        public int PairNumber { get; set; }
        /// <summary>
        /// Gets or sets the date paired.
        /// </summary>
        /// <value>
        /// The date paired.
        /// </value>
        public DateTime DatePaired{ get; set; }
        /// <summary>
        /// Gets or sets the sire band number.
        /// </summary>
        /// <value>
        /// The sire band number.
        /// </value>
        public string SireBandNumber { get; set; }
        /// <summary>
        /// Gets or sets the dam band number.
        /// </summary>
        /// <value>
        /// The dam band number.
        /// </value>
        public string DamBandNumber { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public PairStatus Status  { get; set; }
    }
}