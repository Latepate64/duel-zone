using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect : TapChoiceEffect
{
    public ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect() : base(0, 2, true)
    {
    }

    public ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(
        ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(this);
    }

    public override string ToString()
    {
        return $"Choose up to {Maximum} of your opponent's creatures in the battle zone and tap them.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
