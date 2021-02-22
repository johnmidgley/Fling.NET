using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fling
{
    interface IState
    {
        /// <summary>
        /// Signals whether the state is a goal state or not.
        /// </summary>
        Boolean InGoalState { get; }

        /// <summary>
        /// Gets transitions to possible successor states.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IStateTransition> GetSuccessorTransitions();
    }
}
