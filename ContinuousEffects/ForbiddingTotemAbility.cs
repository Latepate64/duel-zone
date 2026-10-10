using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

/// <summary>
/// Your opponent's attacking creatures attack creatures if able.
/// </summary>
public sealed class ForbiddingTotemAbility : ContinuousEffect, ICannotAttackCreaturesEffect, ICannotAttackPlayersEffect
{
    private readonly ICardFilter defendingCreatureFilter;

    public ForbiddingTotemAbility(ICardFilter defendingCreatureFilter)
    {
        this.defendingCreatureFilter = defendingCreatureFilter;
    }

    public ForbiddingTotemAbility(ForbiddingTotemAbility effect) : base(effect)
    {
        defendingCreatureFilter = effect.defendingCreatureFilter.Copy();
    }

    public bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game)
    {
        // Your opponent's attacking creatures can't attack creatures other than Mystery Totems if a Mystery Totem could
        // be attacked this way.
        if (attacker.Id == game.GetOpponent(Controller).Id)
        {
            if (!target.HasRace(Race.MysteryTotem))
            {
                return AttackableCreaturesExists(attacker, game);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CannotAttackPlayers(ICreature attacker, IGame game)
    {
        return attacker.Id == game.GetOpponent(Controller).Id && AttackableCreaturesExists(attacker, game);
    }

    public override IContinuousEffect Copy()
    {
        return new ForbiddingTotemAbility(this);
    }

    private bool AttackableCreaturesExists(ICreature attacker, IGame game)
    {
        return game.BattleZone.GetCreaturesControllerByPlayer(
            Applier, defendingCreatureFilter).Any(
                x => game.CanAttackCreature(attacker, x));
    }
}
