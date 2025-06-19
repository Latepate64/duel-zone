using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
{
    class IkazTheSpydroid : Creature
    {
        public IkazTheSpydroid() : base("Ikaz, the Spydroid", 4, 4000, Race.Soltrooper, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new IkazTheSpydroidEffect()));
        }
    }

    class IkazTheSpydroidEffect : CreatureSelectionEffect
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

        protected override void Apply(IGame game, IAbility source, params Engine.Creature[] cards)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(new IkazTheSpydroidUntapEffect(cards.Single()), Ability));
        }

        protected override IEnumerable<Engine.Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id);
        }
    }

    class IkazTheSpydroidUntapEffect : UntapAreaOfEffect, ICardAffectable
    {
        public IkazTheSpydroidUntapEffect(Card card) : base()
        {
            Card = card;
        }

        public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
        {
            Card = effect.Card;
        }

        public Card Card { get; }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidUntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap {Card} after the battle.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return new Card[] { Card };
        }
    }
}
