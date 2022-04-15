using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class EldritchPoison : Spell
    {
        public EldritchPoison() : base("Eldritch Poison", 1, Engine.Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new EldritchPoisonEffect());
        }
    }

    class EldritchPoisonEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new EldritchPoisonSacrificeEffect().Apply(game, source);
            if (cards.Any())
            {
                return new ReturnCreatureFromYourManaZoneToYourHandEffect().Apply(game, source);
            }
            return cards;
        }

        public override IOneShotEffect Copy()
        {
            return new EldritchPoisonEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your darkness creatures. If you do, return a creature from your mana zone to your hand.";
        }
    }

    class EldritchPoisonSacrificeEffect : DestroyEffect
    {
        public EldritchPoisonSacrificeEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EldritchPoisonSacrificeEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your darkness creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller, Engine.Civilization.Darkness);
        }
    }
}
