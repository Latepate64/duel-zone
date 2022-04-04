using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    public class RaceEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        public RaceEvolutionEffect(RaceEvolutionEffect effect) : base(effect)
        {
            Races = effect.Races;
        }

        public RaceEvolutionEffect(ICardFilter filter, params Common.Subtype[] races) : base(filter, new Durations.Indefinite())
        {
            Races = races;
        }

        public Common.Subtype[] Races { get; }

        public bool CanEvolveFrom(ICard card)
        {
            return card.Subtypes.Intersect(Races).Any();
        }

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
    }
}
