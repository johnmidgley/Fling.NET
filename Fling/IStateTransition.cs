using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
    interface IStateTransition
    {
        /// <summary>
        /// Apply the state transition
        /// </summary>
        Boolean Apply();

        /// <summary>
        /// Revers the transition
        /// </summary>
        Boolean Reverse();
    }
}
