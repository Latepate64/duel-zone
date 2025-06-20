using ContinuousEffects;
using Engine;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects;

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

    public bool CanEvolveFrom(Creature bait, Creature evolutionCard, IGame game)
    {
        return IsSourceOfAbility(evolutionCard) && bait.Races.Intersect(Races).Any();
    }

    public override bool CanEvolve(IGame game, Creature evolutionCreature)
    {
        return GetPossibleBaits(game, evolutionCreature).Any();
    }

    protected override IEnumerable<Creature> GetPossibleBaits(IGame game, Creature evolutionCreature)
    {
        return game.BattleZone.GetCreatures(evolutionCreature.Owner.Id).Where(bait => CanEvolveFrom(bait, evolutionCreature, game));
    }
}
