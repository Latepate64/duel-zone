using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class CometMissile : Spell
    {
        public CometMissile() : base("Comet Missile", 1, Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new CometMissileEffect());
        }
    }

    class CometMissileEffect : DestroyEffect
    {
        public CometMissileEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CometMissileEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker\" and power 6000 or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.GetAbilities<BlockerAbility>().Any() && x.Power <= 6000);
        }
    }
}
