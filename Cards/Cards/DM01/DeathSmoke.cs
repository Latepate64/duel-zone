using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class DeathSmoke : Spell
    {
        public DeathSmoke() : base("Death Smoke", 4, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new DeathSmokeEffect());
        }
    }

    class DeathSmokeEffect : DestroyEffect
    {
        public DeathSmokeEffect() : base(new OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DeathSmokeEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's untapped creatures.";
        }
    }
}
