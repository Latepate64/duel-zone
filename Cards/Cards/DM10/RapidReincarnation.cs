using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
{
    class RapidReincarnation : Spell
    {
        public RapidReincarnation() : base("Rapid Reincarnation", 3, Civilization.Light)
        {
            AddShieldTrigger();
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
        public YouMayDestroyOneOfYourCreaturesEffect() : base(0, 1, true)
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

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }

    class RapidReincarnationSecondEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public RapidReincarnationSecondEffect() : base(1, 1, true, ZoneType.Hand, ZoneType.BattleZone)
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

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Hand.Creatures.Where(x => x.ManaCost <= source.GetController(game).ManaZone.Cards.Count);
        }
    }
}
