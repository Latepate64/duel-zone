using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;
using ContinuousEffects;

namespace Cards.DM01;

public class MagmaGazerEffect : CreatureSelectionEffect
{
    public MagmaGazerEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MagmaGazerEffect();
    }

    public override string ToString()
    {
        return "One of your creatures gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(
            Ability, new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
