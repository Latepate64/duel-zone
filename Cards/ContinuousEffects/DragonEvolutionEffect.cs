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

        public override bool CanEvolve(IGame game, ICard evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
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

        protected override IEnumerable<ICard> GetPossibleBaits(IGame game, ICard evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }
    }
}
