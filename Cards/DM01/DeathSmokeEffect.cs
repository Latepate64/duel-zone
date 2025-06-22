using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01;

public class DeathSmokeEffect : DestroyEffect
{
    public DeathSmokeEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new DeathSmokeEffect();
    }

    public override string ToString()
    {
        return "Destroy one of your opponent's untapped creatures.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, game.GetOpponent(
            Ability.Controller.Id));
    }
}
