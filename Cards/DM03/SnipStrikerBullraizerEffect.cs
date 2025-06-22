using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public class SnipStrikerBullraizerEffect : ContinuousEffect, ICannotAttackEffect
{
    public SnipStrikerBullraizerEffect() : base()
    {
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature) && game.BattleZone.GetCreatureCount(GetOpponent(game).Id) >
            game.BattleZone.GetCreatureCount(Ability.Controller.Id);
    }

    public override IContinuousEffect Copy()
    {
        return new SnipStrikerBullraizerEffect();
    }

    public override string ToString()
    {
        return "This creature can't attack while your opponent has more creatures in the battle zone than you do.";
    }
}
