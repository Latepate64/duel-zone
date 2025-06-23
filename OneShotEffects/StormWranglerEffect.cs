using Engine.Abilities;
using Interfaces;
using ContinuousEffects;

namespace OneShotEffects;

public sealed class StormWranglerEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(
            game, GetOpponent(game).Id).Where(x => x.IsBlocker);
        var creature = Controller.ChooseCardOptionally(creatures, ToString()) as ICreature;
        if (creature != null)
        {
            game.AddContinuousEffects(Ability, new StormWranglerContinuousEffect(creature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new StormWranglerEffect();
    }

    public override string ToString()
    {
        return "You may choose one of your opponent's untapped creatures that has \"blocker.\" This turn, that creature blocks this creature if able and this creature can't be blocked by other creatures.";
    }
}
