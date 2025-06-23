using Engine.Abilities;
using Interfaces;
using OneShotEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.DM07;

sealed class FreezingIcehammerEffect : ManaFeedEffect
{
    public FreezingIcehammerEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new FreezingIcehammerEffect();
    }

    public override string ToString()
    {
        return "Choose one of your opponent's water or darkness creatures in the battle zone. Your opponent puts that creature into his mana zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(
            x => x.HasCivilization(Civilization.Water, Civilization.Darkness));
    }
}
