using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10;

public sealed class UltimateDragonBreakerEffect : CrewBreakerEffect
{
    public override IContinuousEffect Copy()
    {
        return new UltimateDragonBreakerEffect();
    }

    public override int GetAmount(IGame game, ICreature creature)
    {
        var ability = Ability;
        return IsSourceOfAbility(creature) ? game.BattleZone.GetCreatures(ability.Controller.Id).Count(
            x => x != ability.Source && x.IsDragon) : 1;
    }

    public override string ToString()
    {
        return "Crew breaker - Dragon";
    }
}
