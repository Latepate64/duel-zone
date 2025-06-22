using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class AuraBlastEffect : OneShotEffect, IPowerable
{
    public AuraBlastEffect(int power) : base()
    {
        Power = power;
    }

    public AuraBlastEffect(AuraBlastEffect effect) : base(effect)
    {
        Power = effect.Power;
    }

    public int Power { get; }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(
            Power, [.. game.BattleZone.GetCreatures(Ability.Controller.Id)]));
    }

    public override IOneShotEffect Copy()
    {
        return new AuraBlastEffect(this);
    }

    public override string ToString()
    {
        return $"Each of your creatures in the battle zone gets \"power attacker +{Power}\" until the end of the turn.";
    }
}
