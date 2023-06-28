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

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            foreach (var card in cards)
            {
                var sourceZone = Game.BattleZone.Cards.Contains(card) ? ZoneType.BattleZone : ZoneType.ManaZone;
                Game.Move(Ability, sourceZone, ZoneType.Hand, card);
            }
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.Players.SelectMany(x => x.ManaZone.Cards).Union(Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier)).Union(Game.BattleZone.GetCreatures(Applier));
        }
    }
}
