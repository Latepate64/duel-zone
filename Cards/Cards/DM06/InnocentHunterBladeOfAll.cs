using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class InnocentHunterBladeOfAll : Creature
    {
        public InnocentHunterBladeOfAll() : base("Innocent Hunter, Blade of All", 4, 1000, Race.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new InnocentHunterEffect());
        }
    }

    class InnocentHunterEffect : ContinuousEffect, IEvolutionEffect
    {
        public bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game)
        {
            return bait == GetSourceCard(game);
        }

        public override IContinuousEffect Copy()
        {
            return new InnocentHunterEffect();
        }

        public override string ToString()
        {
            return "You can put an evolution creature of any race on this creature.";
        }
    }
}
