using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
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
        public override bool CanEvolve(IGame game, Engine.Creature evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }

        public bool CanEvolveFrom(Engine.Creature bait, Engine.Creature evolutionCard, IGame game)
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

        protected override IEnumerable<Engine.Creature> GetPossibleBaits(IGame game, Engine.Creature evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }
    }
}
