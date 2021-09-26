using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus(Guid owner) : base(owner, 3, Civilization.Fire, 3000, Race.Dragonoid)
        {
            StaticAbilities.Add(new SpeedAttacker(Id, owner));
            TriggeredAbilities.Add(new PyrofighterMagnusAbility(Id, owner));
        }

        public PyrofighterMagnus(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new PyrofighterMagnus(this);
        }
    }

    public class PyrofighterMagnusAbility : AtTheEndOfYourTurn
    {
        public PyrofighterMagnusAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public PyrofighterMagnusAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public override NonStaticAbility Copy()
        {
            return new PyrofighterMagnusAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Return this creature to your hand.
            var creature = duel.GetCreature(Source);
            duel.GetOwner(creature).ReturnFromBattleZoneToHand(creature, duel);
            return null;
        }
    }
}
