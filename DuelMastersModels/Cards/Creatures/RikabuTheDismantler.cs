using DuelMastersModels.Abilities.StaticAbilities;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class RikabuTheDismantler : Creature
    {
        public RikabuTheDismantler(Guid owner) : base(owner, 3, Civilization.Fire, 1000, Race.MachineEater)
        {
            StaticAbilities.Add(new SpeedAttacker(Id, owner));
        }

        public RikabuTheDismantler(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new RikabuTheDismantler(this);
        }
    }
}
