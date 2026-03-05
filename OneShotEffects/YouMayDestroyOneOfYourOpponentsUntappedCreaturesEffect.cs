using Interfaces;

namespace OneShotEffects;

public sealed class YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect : DestroyEffect
{
    public YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your opponent's untapped creatures.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
