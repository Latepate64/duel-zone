using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class DragonEvolutionEffect : SingleBaitEvolutionEffect
    {
        public DragonEvolutionEffect() : base()
        {
        }

        public override bool CanEvolve(IGame game, Card evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }

        public bool CanEvolveFrom(Card bait, Card evolutionCard, IGame game)
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

        protected override IEnumerable<Card> GetPossibleBaits(IGame game, Card evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }
    }
}
