using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class IkazTheSpydroid : Creature
    {
        public IkazTheSpydroid() : base("Ikaz, the Spydroid", 4, 4000, Race.Soltrooper, Civilization.Light)
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

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterBattleAbility(new IkazTheSpydroidUntapEffect(cards)), GetSourceAbility(game).Source, GetSourceAbility(game).Controller, true));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetSourceAbility(game).Controller);
        }
    }

    class IkazTheSpydroidUntapEffect : UntapAreaOfEffect
    {
        private readonly ICard[] _cards;

        public IkazTheSpydroidUntapEffect(params ICard[] cards) : base()
        {
            _cards = cards;
        }

        public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidUntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap {_cards} after the battle.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return _cards;
        }
    }
}
