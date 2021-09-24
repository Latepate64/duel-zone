using System;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class Selection<T> : Choice
    {
        /// <summary>
        /// Options player can choose from.
        /// </summary>
        public IEnumerable<T> Options { get; private set; }

        public int MinimumSelection { get; private set; }

        public int MaximumSelection { get; private set; }

        /// <summary>
        /// Creates a selection. Note that selection (property Selected) may be already set here if there is only one legal option to choose from.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="options"></param>
        /// <param name="minimumSelection"></param>
        /// <param name="maximumSelection"></param>
        internal Selection(Guid player, IEnumerable<T> options, int minimumSelection = 0, int maximumSelection = 1) : base(player)
        {
            Options = options;
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
        }
    }

    public class GuidDecision : Decision
    {
        public IEnumerable<Guid> Decision { get; private set; }

        public GuidDecision(IEnumerable<Guid> decision)
        {
            Decision = decision;
        }
    }
}
