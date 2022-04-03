using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.Promo
{
    class ArmoredGroblav : EvolutionCreature
    {
        public ArmoredGroblav() : base("Armored Groblav", 5, 6000, Subtype.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredGroblavEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ArmoredGroblavEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public ArmoredGroblavEffect() : base(1000, new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Fire))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredGroblavEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each other fire creature in the battle zone.";
        }
    }
}
