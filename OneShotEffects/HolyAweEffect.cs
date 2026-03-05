using Interfaces;

namespace OneShotEffects;

public sealed class HolyAweEffect : TapAreaOfEffect
{
    public HolyAweEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new HolyAweEffect();
    }

    public override string ToString()
    {
        return "Tap all your opponent's creatures in the battle zone.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(game.GetOpponent(Ability.Controller.Id));
    }
}
