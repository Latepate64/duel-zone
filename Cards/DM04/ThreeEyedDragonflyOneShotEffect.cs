using Engine.Abilities;
using Interfaces;

namespace Cards.DM04;

public sealed class ThreeEyedDragonflyOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseCardOptionally(game.BattleZone.GetOtherCreatures(
            Ability.Controller.Id, Ability.Source.Id), ToString());
        if (creature != null)
        {
            game.Destroy(Ability, creature as ICreature);
            game.AddContinuousEffects(Ability, new ThreeEyedDragonflyContinuousEffect(Ability.Source as ICreature));
        }
    }

    public override IOneShotEffect Copy()
    {
        return new ThreeEyedDragonflyOneShotEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your other creatures. If you do, this creature gets +2000 power and has \"double breaker\" until the end of the turn.";
    }
}
