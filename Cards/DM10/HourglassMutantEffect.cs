using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM10;

public sealed class HourglassMutantEffect : AbilityAddingEffect
{
    public HourglassMutantEffect() : base(new StaticAbility(new ThisCreatureHasSlayerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new HourglassMutantEffect();
    }

    public override string ToString()
    {
        return "Each of your water creatures and fire creatures in the battle zone has \"slayer.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Civilization.Water, Civilization.Fire);
    }
}
