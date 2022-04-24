using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    public class RaceEvolutionEffect : ContinuousEffect, IEvolutionEffect, IMultiRaceable
    {
        public RaceEvolutionEffect(RaceEvolutionEffect effect) : base(effect)
        {
            Races = effect.Races;
        }

        public RaceEvolutionEffect(params Race[] races) : base()
        {
            Races = races;
        }

        public Race[] Races { get; }

        public override ContinuousEffect Copy()
        {
            return new RaceEvolutionEffect(this);
        }

        public override string ToString()
        {
            var raceText = string.Join(" or ", Races.Select(x => $"{SplitByCase(Races.ToString())}s"));
            return $"Evolution - Put on one of your {raceText}.";
        }

        private static string SplitByCase(string text)
        {
            return string.Join(' ', System.Text.RegularExpressions.Regex.Split(text, @"(?<!^)(?=[A-Z])"));
        }

        public bool CanEvolveFrom(ICard bait, ICard evolutionCard, IGame game)
        {
            return IsSourceOfAbility(evolutionCard) && bait.Races.Intersect(Races).Any();
        }

        public bool CanEvolve(IGame game, ICard evolutionCreature)
        {
            return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Any(bait => CanEvolveFrom(bait, evolutionCreature, game));
        }
    }
}
