using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class InfernalCommandEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseOpponentsCreature(game, ToString());
        game.AddContinuousEffects(Ability, new InfernalCommandContinuousEffect(creature));
    }

    public override IOneShotEffect Copy()
    {
        return new InfernalCommandEffect();
    }

    public override string ToString()
    {
        return "Choose one of your opponent's creatures in the battle zone. It gets \"this creature attacks if able\" until the start of your next turn.";
    }
}
