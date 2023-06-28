using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System;
using System.Linq;

namespace Cards.Cards.DM11
{
    class WarpedLunatron : Creature
    {
        public WarpedLunatron() : base("Warped Lunatron", 7, 6000, Race.CyberMoon, Civilization.Water)
        {
            AddStaticAbilities(new WarpedLunatronEffect());
            AddTriggeredAbility(new WarpedLunatronAbility());
            AddDoubleBreakerAbility();
        }
    }

    class WarpedLunatronEffect : ContinuousEffect, ICreaturesDoNotUntapAtTheStartOfEachPlayersTurn
    {
        public WarpedLunatronEffect()
        {
        }

        public WarpedLunatronEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new WarpedLunatronEffect(this);
        }

        public override string ToString()
        {
            return "Creatures in the battle zone don't untap at the start of each player's turn.";
        }
    }

    class WarpedLunatronAbility : LinkedTriggeredAbility
    {
        private IPlayer _player;

        public WarpedLunatronAbility()
        {
        }

        public WarpedLunatronAbility(WarpedLunatronAbility ability) : base(ability)
        {
            _player = ability._player;
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn; //TODO: Not sure if works as is 
        }

        public override IAbility Copy()
        {
            return new WarpedLunatronAbility(this);
        }

        public override void Resolve()
        {
            var cards = _player.ChooseAnyNumberOfCards(_player.ManaZone.UntappedCards, ToString());
            var amount = cards.Count() / 2;
            var toUntap = _player.ChooseCards(Game.BattleZone.GetCreatures(_player), amount, amount, ToString());
            _player.Untap(toUntap.ToArray());
        }

        public override string ToString()
        {
            return "When each player untaps his cards at the start of his turn, he may then tap any number of cards in his mana zone. For every 2 cards he taps this way, he untaps one of his creatures in the battle zone.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
            return Copy() as ITriggeredAbility;
        }
    }
}
