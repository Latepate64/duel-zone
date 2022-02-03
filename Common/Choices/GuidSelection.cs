using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public class GuidSelection : Choice
    {
        /// <summary>
        /// Options player can choose from.
        /// </summary>
        public IEnumerable<Guid> Options { get; private set; }

        public int MinimumSelection { get; private set; }

        public int MaximumSelection { get; private set; }

        /// <summary>
        /// Creates a selection. Note that selection (property Selected) may be already set here if there is only one legal option to choose from.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="options"></param>
        /// <param name="minimumSelection"></param>
        /// <param name="maximumSelection"></param>
        public GuidSelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player)
        {
            Options = options;
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
        }

        public GuidSelection(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection) : this(player, options.Select(x => x.Id), minimumSelection, maximumSelection) { }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Options = null;
            }
        }
    }

    public class GuidDecision : Decision
    {
        public IEnumerable<Guid> Decision { get; private set; }

        public GuidDecision(IEnumerable<Guid> decision)
        {
            Decision = decision;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Decision = null;
            }
        }
    }
}
