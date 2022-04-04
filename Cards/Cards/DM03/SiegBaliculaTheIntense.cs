using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class SiegBaliculaTheIntense : EvolutionCreature
    {
        public SiegBaliculaTheIntense() : base("Sieg Balicula, the Intense", 3, 5000, Subtype.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new SiegBaliculaTheIntenseEffect());
        }
    }

    class SiegBaliculaTheIntenseEffect : ContinuousEffect, IBlockerEffect
    {
        public SiegBaliculaTheIntenseEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Light), new Durations.Indefinite()) { }

        public bool Applies(Engine.ICard attacker, IGame game)
        {
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new SiegBaliculaTheIntenseEffect();
        }

        public override string ToString()
        {
            return "Each of your other light creatures in the battle zone has \"blocker.\"";
        }
    }
}
