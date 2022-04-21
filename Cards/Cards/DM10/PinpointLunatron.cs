using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
{
    class PinpointLunatron : SilentSkillCreature
    {
        public PinpointLunatron() : base("Pinpoint Lunatron", 6, 2000, Race.CyberMoon, Civilization.Water)
        {
            AddSilentSkillAbility(new PinpointLunatronEffect());
        }
    }

    class PinpointLunatronEffect : OneShotEffects.CardSelectionEffect
    {
        public PinpointLunatronEffect() : base(1, 1, true)
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

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            foreach (var card in cards)
            {
                var sourceZone = game.BattleZone.Cards.Contains(card) ? ZoneType.BattleZone : ZoneType.ManaZone;
                game.Move(source, sourceZone, ZoneType.Hand, card);
            }
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.Players.SelectMany(x => x.ManaZone.Cards).Union(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id)).Union(game.BattleZone.GetCreatures(source.Controller));
        }
    }
}
