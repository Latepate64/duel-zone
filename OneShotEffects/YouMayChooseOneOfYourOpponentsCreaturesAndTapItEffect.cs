using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect : TapChoiceEffect
{
    public YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect() : base(0, 1, true)
    {
    }

    public YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect(
        YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect(this);
    }

    public override string ToString()
    {
        return "You may choose one of your opponent's creatures in the battle zone and tap it.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
