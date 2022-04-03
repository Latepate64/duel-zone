using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class EldritchPoison : Spell
    {
        public EldritchPoison() : base("Eldritch Poison", 1, Civilization.Darkness)
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
        public EldritchPoisonSacrificeEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Darkness), 0, 1, true)
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
    }
}
