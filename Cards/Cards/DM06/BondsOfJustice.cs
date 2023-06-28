using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class BondsOfJustice : Spell
    {
        public BondsOfJustice() : base("Bonds of Justice", 4, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new BondsOfJusticeEffect());
        }
    }

    class BondsOfJusticeEffect : TapAreaOfEffect
    {
        public BondsOfJusticeEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BondsOfJusticeEffect();
        }

        public override string ToString()
        {
            return "Tap all creatures in the battle zone that don't have \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.BattleZone.Creatures.Where(x => !x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
