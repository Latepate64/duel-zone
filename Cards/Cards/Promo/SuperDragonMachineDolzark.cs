using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.Promo
{
    class SuperDragonMachineDolzark : Creature
    {
        public SuperDragonMachineDolzark() : base("Super Dragon Machine Dolzark", 6, 7000, Subtype.ArmoredDragon, Subtype.EarthDragon, Civilization.Fire, Civilization.Nature)
        {
            AddTriggeredAbility(new DolzarkAbility());
            AddDoubleBreakerAbility();
        }
    }

    class DolzarkAbility : WheneverCreatureAttacksAbility
    {
        public DolzarkAbility() : base(new DolzarkEffect(), new DolzarkFilter())
        {
        }

        public DolzarkAbility(DolzarkAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new DolzarkAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever one of your other creatures that has Dragon in its race attacks, {GetEffectText()}";
        }

        protected override bool TriggersFrom(Engine.ICard card, IGame game)
        {
            return card.Owner == Controller && card.Id != Source && card.IsDragon;
        }
    }

    class DolzarkFilter : CardFilters.OwnersOtherBattleZoneCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsDragon;
        }

        public override CardFilter Copy()
        {
            return new DolzarkFilter();
        }
    }

    class DolzarkEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public DolzarkEffect() : base(new CardFilters.OpponentsBattleZoneChoosableMaxPowerCreatureFilter(5000), 0, 1, true, ZoneType.BattleZone, ZoneType.ManaZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DolzarkEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's creatures in the battle zone that has power 5000 or less and put it into his mana zone.";
        }
    }
}
