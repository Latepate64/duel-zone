using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM08;

sealed class KyrstronLairDelverEffect : CardMovingChoiceEffect<ICreature>
{
    public KyrstronLairDelverEffect() : base(0, 1, true, ZoneType.Hand, ZoneType.BattleZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new KyrstronLairDelverEffect();
    }

    public override string ToString()
    {
        return "You may put a creature that has Dragon in its race from your hand into the battle zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Hand.Dragons;
    }
}
