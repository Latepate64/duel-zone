using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM02
{
    class Corile : Creature
    {
        public Corile() : base("Corile", 5, 2000, Race.CyberLord, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect());
        }
    }

    class CorileEffect : CardMovingChoiceEffect
    {
        public CorileEffect(CorileEffect effect) : base(effect)
        {
        }

        public CorileEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.Deck)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and put it on top of his deck.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
