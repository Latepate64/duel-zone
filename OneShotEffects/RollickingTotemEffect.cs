using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class RollickingTotemEffect : CardMovingChoiceEffect<ICreature>
{
    public RollickingTotemEffect() : base(1, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RollickingTotemEffect();
    }

    public override string ToString()
    {
        return "Put a creature that has Dragon in its race from your mana zone into the battle zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures.Where(x => x.IsDragon);
    }
}
