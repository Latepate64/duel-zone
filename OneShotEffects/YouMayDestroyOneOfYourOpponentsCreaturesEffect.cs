using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class YouMayDestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
{
    public YouMayDestroyOneOfYourOpponentsCreaturesEffect() : base(0, 1, true)
    {
    }

    public YouMayDestroyOneOfYourOpponentsCreaturesEffect(DestroyEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayDestroyOneOfYourOpponentsCreaturesEffect(this);
    }

    public override string ToString()
    {
        return "You may destroy one of your opponent's creatures.";
    }

    protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
