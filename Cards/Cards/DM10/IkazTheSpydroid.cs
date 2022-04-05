using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

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
        public IkazTheSpydroidEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
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
    }

    class IkazTheSpydroidUntapEffect : UntapAreaOfEffect
    {
        public IkazTheSpydroidUntapEffect(params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards))
        {
        }

        public IkazTheSpydroidUntapEffect(IkazTheSpydroidUntapEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new IkazTheSpydroidUntapEffect();
        }

        public override string ToString()
        {
            return $"Untap {Filter} after the battle.";
        }
    }
}
