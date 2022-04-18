using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class SiegBaliculaTheIntense : EvolutionCreature
    {
        public SiegBaliculaTheIntense() : base("Sieg Balicula, the Intense", 3, 5000, Race.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new SiegBaliculaTheIntenseEffect());
        }
    }

    class SiegBaliculaTheIntenseEffect : ContinuousEffect, IBlockerEffect
    {
        public SiegBaliculaTheIntenseEffect() : base() { }

        public bool CanBlock(ICard blocker, ICard attacker, IGame game)
        {
            var ability = GetSourceAbility(game);
            return blocker.Owner == ability.Controller && blocker.Id != ability.Source && blocker.HasCivilization(Civilization.Light);
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
