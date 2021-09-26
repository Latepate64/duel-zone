using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class Torcon : Creature
    {
        public Torcon(Guid owner) : base(owner, 2, Civilization.Nature, 1000, Race.BeastFolk)
        {
            ShieldTrigger = true;
        }

        public Torcon(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new Torcon(this);
            throw new NotImplementedException();
        }
    }
}
