using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.Models
{
    public class Bird
    {
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
    }
}
