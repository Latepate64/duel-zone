using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM10;

public sealed class LemikVizierOfThoughtEffect : AbilityAddingEffect
{
    public LemikVizierOfThoughtEffect() : base(new StaticAbility(new ThisCreatureHasBlockerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new LemikVizierOfThoughtEffect();
    }

    public override string ToString()
    {
        return "Each of your water creatures and nature creatures in the battle zone has \"blocker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Civilization.Water, Civilization.Nature);
    }
}
