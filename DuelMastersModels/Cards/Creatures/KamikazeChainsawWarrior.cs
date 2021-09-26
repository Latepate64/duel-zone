using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class KamikazeChainsawWarrior : Creature
    {
        public KamikazeChainsawWarrior(Guid owner) : base(owner, 2, Civilization.Fire, 1000, Race.Armorloid)
        {
            ShieldTrigger = true;
        }

        public KamikazeChainsawWarrior(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new KamikazeChainsawWarrior(this);
        }
    }
}
