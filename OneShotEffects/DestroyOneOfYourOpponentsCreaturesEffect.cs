using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class DestroyOneOfYourOpponentsCreaturesEffect : DestroyEffect
{
    public DestroyOneOfYourOpponentsCreaturesEffect() : base(1, 1, true)
    {
    }

    public DestroyOneOfYourOpponentsCreaturesEffect(DestroyEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyOneOfYourOpponentsCreaturesEffect(this);
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's creatures.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
