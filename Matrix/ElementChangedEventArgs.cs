using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Event args for chaging matrix element.
    /// </summary>
    public class ElementChangedEventArgs: EventArgs
    {
        /// <summary>
        /// Message when changing.
        /// </summary>
        public string Message { get; set; }
    }
}
