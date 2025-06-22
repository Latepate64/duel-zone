using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public class PoisonWormEffect : DestroyEffect
{
    public PoisonWormEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PoisonWormEffect();
    }

    public override string ToString()
    {
        return "Destroy one of your creatures that has power 3000 or less.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.Power <= 3000);
    }
}
