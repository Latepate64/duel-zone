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
            ShieldTrigger = true;
            AddAbilities(new SpellAbility(new EldritchPoisonEffect()));
        }
    }

    class EldritchPoisonEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new SacrificeEffect(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Darkness), false).Apply(game, source);
            if (cards.Any())
            {
                return new SelfManaRecoveryEffect(1, 1, true, new CardFilters.OwnersManaZoneCreatureFilter()).Apply(game, source);
            }
            return cards;
        }

        public override OneShotEffect Copy()
        {
            return new EldritchPoisonEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your darkness creatures. If you do, return a creature from your mana zone to your hand.";
        }
    }
}
