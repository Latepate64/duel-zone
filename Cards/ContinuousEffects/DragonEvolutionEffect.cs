using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class DragonEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        public DragonEvolutionEffect() : base()
        {
        }

        public bool CanEvolve(IGame game, ICard evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }

        public bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game)
        {
            return bait.IsDragon && IsSourceOfAbility(evolutionCard);
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
