using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class DolzarkEffect : CardMovingChoiceEffect<ICreature>
{
    public DolzarkEffect() : base(0, 1, true, ZoneType.BattleZone, ZoneType.ManaZone)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DolzarkEffect();
    }

    public override string ToString()
    {
        return "You may choose one of your opponent's creatures in the battle zone that has power 5000 or less and put it into his mana zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.Power <= 5000);
    }
}
