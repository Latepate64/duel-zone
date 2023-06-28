using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class HolyAwe : Spell
    {
        public HolyAwe() : base("Holy Awe", 6, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new HolyAweEffect());
        }
    }

    class HolyAweEffect : OneShotEffects.TapAreaOfEffect
    {
        public HolyAweEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new HolyAweEffect();
        }

        public override string ToString()
        {
            return "Tap all your opponent's creatures in the battle zone.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier.Opponent);
        }
    }
}
