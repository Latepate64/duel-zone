using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM10
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

        protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(new IkazTheSpydroidUntapEffect(cards.Single()), Ability));
        }

        protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id);
        }
    }

    class IkazTheSpydroidUntapEffect : UntapAreaOfEffect, ICardAffectable
    {
        public IkazTheSpydroidUntapEffect(ICard card) : base()
        {
            Card = card;
        }

        public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
        {
            Card = effect.Card;
        }

        public ICard Card { get; }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidUntapEffect(this);
        }

        public override string ToString()
        {
            return $"Untap {Card} after the battle.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return [Card];
        }
    }
}
