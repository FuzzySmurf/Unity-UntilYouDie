using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuzzy.Attribute
{
    public interface IAdjustCurrent
    {
        /// <summary>
        /// Increase the Current Amount
        /// </summary>
        /// <param name="amount">The amount to Increase By</param>
        /// <returns>The remaing value</returns>
        string IncreaseCurrent(float amount);

        /// <summary>
        /// Decrease the Current Amount
        /// </summary>
        /// <param name="amount">The amount to Decrease By</param>
        /// <returns>The remaing value</returns>
        string DecreaseCurrent(float amount);
    }
}
