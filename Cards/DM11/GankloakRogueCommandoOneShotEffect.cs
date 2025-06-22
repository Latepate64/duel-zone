using Engine.Abilities;
using Interfaces;

namespace Cards.DM11;

public sealed class GankloakRogueCommandoOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id);
        game.AddContinuousEffects(Ability, new GankloakRogueCommandoContinuousEffect([.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new GankloakRogueCommandoOneShotEffect();
    }

    public override string ToString()
    {
        return "Each of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
    }
}
