using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.ContinuousEffects;
using OneShotEffects;

namespace Cards.DM02;

public sealed class MetalwingSkyterrorEffect : DestroyEffect
{
    public MetalwingSkyterrorEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new MetalwingSkyterrorEffect();
    }

    public override string ToString()
    {
        return "You may destroy one of your opponent's creatures that has \"blocker.\"";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            card => card.GetAbilities<StaticAbility>().SelectMany(
            x => x.ContinuousEffects).OfType<IBlockerEffect>().Any());
    }
}
