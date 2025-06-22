using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public class KingBenthosEffect : OneShotEffect
{
    public KingBenthosEffect() : base()
    {
    }

    public KingBenthosEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Water);
        game.AddContinuousEffects(Ability, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
            new StaticAbility(new ThisCreatureCannotBeBlockedEffect()),
            [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new KingBenthosEffect(this);
    }

    public override string ToString()
    {
        return "Each of your water creatures gets \"This creature can't be blocked\" until the end of the turn.";
    }
}
