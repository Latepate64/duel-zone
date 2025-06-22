using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM04;

public sealed class ChainsOfSacrificeEffect : DestroyEffect
{
    public ChainsOfSacrificeEffect() : base(0, 2, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ChainsOfSacrificeEffect();
    }

    public override string ToString()
    {
        return "Destroy up to 2 of your opponent's creatures.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
