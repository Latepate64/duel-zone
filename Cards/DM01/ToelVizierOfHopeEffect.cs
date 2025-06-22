using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01;

public sealed class ToelVizierOfHopeEffect : ControllerMayUntapCreatureEffect
{
    public ToelVizierOfHopeEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ToelVizierOfHopeEffect();
    }

    public override string ToString()
    {
        return "You may untap all your creatures in the battle zone.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreatures(Ability.Controller.Id);
    }
}
