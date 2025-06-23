using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class TerradragonGamiratarEffect : CardMovingChoiceEffect<ICreature>
{
    public TerradragonGamiratarEffect() : base(0, 1, false, ZoneType.Hand, ZoneType.BattleZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new TerradragonGamiratarEffect();
    }

    public override string ToString()
    {
        return "Your opponent may choose a creature in his hand and put it into the battle zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).Hand.Creatures;
    }
}
