using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    public class RaceEvolutionEffect : SingleBaitEvolutionEffect, IMultiRaceable
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

        public bool CanEvolveFrom(ICard bait, ICard evolutionCard)
        {
            return IsSourceOfAbility(evolutionCard) && bait.Races.Intersect(Races).Any();
        }

        public override bool CanEvolve(ICard evolutionCreature)
        {
            return GetPossibleBaits(evolutionCreature).Any();
        }

        protected override IEnumerable<ICard> GetPossibleBaits(ICard evolutionCreature)
        {
            return Game.BattleZone.GetCreatures(evolutionCreature.Owner).Where(bait => CanEvolveFrom(bait, evolutionCreature));
        }
    }

    public abstract class SingleBaitEvolutionEffect : ContinuousEffect, IEvolutionEffect
    {
        protected SingleBaitEvolutionEffect()
        {
        }

        protected SingleBaitEvolutionEffect(SingleBaitEvolutionEffect effect) : base(effect)
        {
        }

        public abstract bool CanEvolve(ICard evolutionCreature);

        public void Evolve(ICard evolutionCreature)
        {
            var baits = GetPossibleBaits(evolutionCreature);
            var bait = evolutionCreature.Owner.ChooseCard(baits, "Choose a creature to evolve from.");
            Game.ProcessEvents(new EvolutionEvent(evolutionCreature.Owner, evolutionCreature, bait));
        }

        protected abstract IEnumerable<ICard> GetPossibleBaits(ICard evolutionCreature);
    }
}
