using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class DragonEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        public DragonEvolutionEffect() : base()
        {
        }

        public bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game)
        {
            return bait.IsDragon && IsSourceOfAbility(evolutionCard, game);
        }

        public override IContinuousEffect Copy()
        {
            return new DragonEvolutionEffect();
        }

        public override string ToString()
        {
            return $"Evolution - Put on one of your creatures that has Dragon in its race.";
        }
    }
}
