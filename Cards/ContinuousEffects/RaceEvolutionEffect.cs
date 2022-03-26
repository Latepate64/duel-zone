using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    public class RaceEvolutionEffect : EvolutionEffect
    {
        public RaceEvolutionEffect(RaceEvolutionEffect effect) : base(effect)
        {
            Race = effect.Race;
        }

        public RaceEvolutionEffect(ICardFilter filter, Common.Subtype race) : base(filter, new Durations.Indefinite())
        {
            Race = race;
        }

        public Common.Subtype Race { get; }

        public override bool CanEvolveFrom(ICard card)
        {
            return card.Subtypes.Contains(Race);
        }

        public override ContinuousEffect Copy()
        {
            return new RaceEvolutionEffect(this);
        }

        public override string ToString()
        {
            return $"Evolution - Put on one of your {SplitByCase(Race.ToString())}s.";
        }

        private static string SplitByCase(string text)
        {
            return string.Join(' ', System.Text.RegularExpressions.Regex.Split(text, @"(?<!^)(?=[A-Z])"));
        }
    }
}
