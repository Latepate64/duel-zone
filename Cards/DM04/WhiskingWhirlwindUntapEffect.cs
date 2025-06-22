using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM04;

public sealed class WhiskingWhirlwindUntapEffect : UntapAreaOfEffect
{
    public WhiskingWhirlwindUntapEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new WhiskingWhirlwindUntapEffect();
    }

    public override string ToString()
    {
        return "Untap all your creatures in the battle zone.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
