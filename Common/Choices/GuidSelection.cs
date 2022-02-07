using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public abstract class GuidSelection : Choice
    {
        /// <summary>
        /// Options player can choose from.
        /// </summary>
        public List<Guid> Options { get; set; }

        public int MinimumSelection { get; set; }

        public int MaximumSelection { get; set; }

        public GuidSelection() { }

        /// <summary>
        /// Creates a selection. Note that selection (property Selected) may be already set here if there is only one legal option to choose from.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="options"></param>
        /// <param name="minimumSelection"></param>
        /// <param name="maximumSelection"></param>
        protected GuidSelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player)
        {
            Options = options.ToList();
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Options = null;
            }
        }

        public override abstract string ToString();
    }

    public class GuidDecision : Decision
    {
        public List<Guid> Decision { get; set; }

        public GuidDecision()
        {
            Decision = new List<Guid>();
        }

        public GuidDecision(IEnumerable<Guid> decision)
        {
            Decision = decision.ToList();
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
