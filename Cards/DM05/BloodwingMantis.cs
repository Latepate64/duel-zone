using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.DM05
{
    class BloodwingMantis : Creature
    {
        public BloodwingMantis() : base("Bloodwing Mantis", 5, 6000, Race.GiantInsect, Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new BloodwingMantisEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class BloodwingMantisEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public BloodwingMantisEffect() : base(2, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BloodwingMantisEffect();
        }

        public override string ToString()
        {
            return "Return 2 creatures from your mana zone to your hand.";
        }

        protected override IEnumerable<Card> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Creatures;
        }
    }
}
