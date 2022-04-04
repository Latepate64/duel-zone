using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class DragonEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        public DragonEvolutionEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public bool CanEvolveFrom(ICard card)
        {
            return card.IsDragon;
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
