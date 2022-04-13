using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public abstract class BoundedGuidSelection : GuidSelection
    {
        public int MinimumSelection { get; set; }

        public int MaximumSelection { get; set; }

        public BoundedGuidSelection() { }

        /// <summary>
        /// Creates a selection. Note that selection (property Selected) may be already set here if there is only one legal option to choose from.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="options"></param>
        /// <param name="minimumSelection"></param>
        /// <param name="maximumSelection"></param>
        protected BoundedGuidSelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player, options)
        {
            MinimumSelection = Math.Min(minimumSelection, options.Count());
            MaximumSelection = Math.Min(maximumSelection, options.Count());
        }

        public override bool IsLegal(IEnumerable<Guid> decision)
        {
            return base.IsLegal(decision) && decision.Count() >= MinimumSelection && decision.Count() <= MaximumSelection;
        }
    }

    public class GuidDecision : Decision, IGuidDecision
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

    public abstract class GuidSelection : Choice
    {
        /// <summary>
        /// Options player can choose from.
        /// </summary>
        public List<Guid> Options { get; set; }

        public GuidSelection()
        {
        }

        protected GuidSelection(Guid player, IEnumerable<Guid> options) : base(player)
        {
            Options = options.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Options = null;
            }
        }

        public override abstract string ToString();

        public virtual bool IsLegal(IEnumerable<Guid> decision)
        {
            return decision.All(i => Options.Contains(i));
        }
    }
}
