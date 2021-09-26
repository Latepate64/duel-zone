using DuelMastersModels.Abilities.StaticAbilities;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror(Guid owner) : base(owner, 7, Civilization.Fire, 7000, Race.ArmoredWyvern)
        {
            StaticAbilities.Add(new DoubleBreaker(Id, owner));
            StaticAbilities.Add(new SpeedAttacker(Id, owner));
        }

        public TwinCannonSkyterror(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new TwinCannonSkyterror(this);
        }
    }
}
