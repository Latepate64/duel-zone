﻿using Engine;
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

        public RaceEvolutionEffect(params Common.Subtype[] races) : base()
        {
            Races = races;
        }

        public Common.Subtype[] Races { get; }

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
            return bait.Subtypes.Intersect(Races).Any() && IsSourceOfAbility(evolutionCard, game);
        }
    }
}
