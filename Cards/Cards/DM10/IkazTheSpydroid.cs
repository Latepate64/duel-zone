using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class IkazTheSpydroid : Creature
    {
        public IkazTheSpydroid() : base("Ikaz, the Spydroid", 4, 4000, Subtype.Soltrooper, Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new IkazTheSpydroidEffect()));
        }
    }

    class IkazTheSpydroidEffect : CardSelectionEffect
    {
        public IkazTheSpydroidEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidEffect();
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. Untap it after the battle.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterBattleAbility(new IkazTheSpydroidUntapEffect(cards)), source.Source, source.Controller, true));
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }

    class IkazTheSpydroidUntapEffect : UntapAreaOfEffect
    {
        private readonly Engine.ICard[] _cards;

        public IkazTheSpydroidUntapEffect(params Engine.ICard[] cards) : base()
        {
            _cards = cards;
        }

        public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidUntapEffect();
        }

        public override string ToString()
        {
            return $"Untap {_cards} after the battle.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return _cards;
        }
    }
}
