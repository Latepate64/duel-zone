using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class RapidReincarnation : Spell
    {
        public RapidReincarnation() : base("Rapid Reincarnation", 3, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new RapidReincarnationEffect());
        }
    }

    class RapidReincarnationEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new YouMayDestroyOneOfYourCreaturesEffect().Apply(game, source);
            if (cards.Any())
            {

            }
            return cards;
        }

        public override IOneShotEffect Copy()
        {
            return new RapidReincarnationEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your creatures. If you do, choose a creature in your hand that costs the same as or less than the number of cards in your mana zone and put it into the battle zone.";
        }
    }

    class YouMayDestroyOneOfYourCreaturesEffect : OneShotEffects.DestroyEffect
    {
        public YouMayDestroyOneOfYourCreaturesEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourCreaturesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your creatures.";
        }
    }

    class RapidReincarnationSecondEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public RapidReincarnationSecondEffect() : base(new RapidReincarnationFilter(), 1, 1, true, ZoneType.Hand, ZoneType.BattleZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RapidReincarnationSecondEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in your hand that costs the same as or less than the number of cards in your mana zone and put it into the battle zone.";
        }
    }

    class RapidReincarnationFilter : CardFilters.OwnersHandCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.ManaCost <= player.ManaZone.Cards.Count;
        }

        public override CardFilter Copy()
        {
            return new RapidReincarnationFilter();
        }
    }
}
