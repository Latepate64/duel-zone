using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class BlazeCannonBuffEffect : OneShotEffect
{
    public BlazeCannonBuffEffect() : base()
    {
    }

    public BlazeCannonBuffEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        
        game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(
            [.. game.BattleZone.GetCreatures(Ability.Controller.Id)]));
    }

    public override IOneShotEffect Copy()
    {
        return new BlazeCannonBuffEffect(this);
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
    }
}
