using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM06
{
    class InnocentHunterBladeOfAll : Creature
    {
        public InnocentHunterBladeOfAll() : base("Innocent Hunter, Blade of All", 4, 1000, Race.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new InnocentHunterEffect());
        }
    }

    class InnocentHunterEffect : SingleBaitEvolutionEffect
    {
        public override bool CanEvolve(IGame game, ICreature evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }

        public bool CanEvolveFrom(ICreature bait, ICreature evolutionCard, IGame game)
        {
            return bait == Source;
        }

        public override IContinuousEffect Copy()
        {
            return new InnocentHunterEffect();
        }

        public override string ToString()
        {
            return "You can put an evolution creature of any race on this creature.";
        }

        protected override IEnumerable<ICreature> GetPossibleBaits(IGame game, ICreature evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(
                bait, evolutionCreature, game));
        }
    }
}
