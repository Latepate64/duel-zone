using Common;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class FranticChieftain : Creature
    {
        public FranticChieftain() : base("Frantic Chieftain", 2, 2000, Subtype.Merfolk, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new FranticChieftainEffect()));
        }
    }

    class FranticChieftainEffect : OneShotEffects.BounceEffect
    {
        public FranticChieftainEffect() : base(new CardFilters.OwnersBattleZoneMaxCostCreatureFilter(4), 1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FranticChieftainEffect();
        }

        public override string ToString()
        {
            return "Return one of your creatures that costs 4 or less from the battle zone to your hand.";
        }
    }
}
