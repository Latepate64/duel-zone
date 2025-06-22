using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM01;

public sealed class NaturalSnareEffect : ManaFeedEffect
{
    public NaturalSnareEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new NaturalSnareEffect();
    }

    public override string ToString()
    {
        return "Choose one of your opponent's creatures in the battle zone and put it into his mana zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id);
    }
}
