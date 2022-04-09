using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
{
    class PinpointLunatron : SilentSkillCreature
    {
        public PinpointLunatron() : base("Pinpoint Lunatron", 6, 2000, Subtype.CyberMoon, Civilization.Water)
        {
            AddSilentSkillAbility(new PinpointLunatronEffect());
        }
    }

    class PinpointLunatronEffect : OneShotEffects.CardSelectionEffect
    {
        public PinpointLunatronEffect() : base(new PinpointLunatronFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PinpointLunatronEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in the battle zone or a card in either player's mana zone and return it to its owner's hand.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            foreach (var card in cards)
            {
                var sourceZone = game.BattleZone.Cards.Contains(card) ? ZoneType.BattleZone : ZoneType.ManaZone;
                game.Move(sourceZone, ZoneType.Hand, card);
            }
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.Players.SelectMany(x => x.ManaZone.Cards).Union(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id)).Union(game.BattleZone.GetCreatures(source.Controller));
        }
    }

    class PinpointLunatronFilter : CardFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return new CardFilters.BattleZoneChoosableCreatureFilter().Applies(card, game, player) || new CardFilters.ManaZoneCardFilter().Applies(card, game, player);
        }

        public override ICardFilter Copy()
        {
            return new PinpointLunatronFilter();
        }
    }
}
