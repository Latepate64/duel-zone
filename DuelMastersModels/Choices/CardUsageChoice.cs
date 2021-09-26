using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> Options { get; set; }

        public CardUsageChoice(Guid player, IEnumerable<IGrouping<Guid, IEnumerable<IEnumerable<Guid>>>> useableCards) : base(player)
        {
            Options = useableCards;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Options = null;
            }
        }
    }

    public class CardUsageDecision : Decision
    {
        public UseCardContainer Decision { get; private set; }

        public CardUsageDecision(UseCardContainer decision)
        {
            Decision = decision;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Decision != null)
            {
                Decision.Dispose();
                Decision = null;
            }
        }
    }

    public class UseCardContainer : IDisposable
    {
        public Guid ToUse { get; set; }
        public IEnumerable<Guid> Manas { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Manas = null;
            }
        }
    }
}
