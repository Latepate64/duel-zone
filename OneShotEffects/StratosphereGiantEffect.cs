using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class StratosphereGiantEffect : CardMovingChoiceEffect<ICreature>
{
    public StratosphereGiantEffect() : base(0, 2, false, ZoneType.Hand, ZoneType.BattleZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new StratosphereGiantEffect();
    }

    public override string ToString()
    {
        return "Your opponent chooses up to 2 creatures in his hand and puts them into the battle zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).Hand.Creatures;
    }
}
