using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class MuramasaDukeOfBladesEffect : DestroyEffect
{
    public MuramasaDukeOfBladesEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MuramasaDukeOfBladesEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your opponent's creatures that has power 2000 or less.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.Power <= 2000);
    }
}
