using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.DM08;

sealed class MegariaEmpressOfDreadEffect : AbilityAddingEffect
{
    public MegariaEmpressOfDreadEffect() : base(new StaticAbility(new ThisCreatureHasSlayerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MegariaEmpressOfDreadEffect();
    }

    public override string ToString()
    {
        return "Each creature in the battle zone has \"slayer.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.Creatures;
    }
}
