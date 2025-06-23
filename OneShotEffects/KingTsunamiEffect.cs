using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;
using OneShotEffects;

namespace OneShotEffects;

public sealed class KingTsunamiEffect : BounceAreaOfEffect
{
    public KingTsunamiEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new KingTsunamiEffect();
    }

    public override string ToString()
    {
        return "Return all other creatures from the battle zone to their owners' hands.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetOtherCreatures(Ability.Source.Id);
    }
}
