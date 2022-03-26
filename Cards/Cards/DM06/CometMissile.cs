using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class CometMissile : Spell
    {
        public CometMissile() : base("Comet Missile", 1, Common.Civilization.Fire)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new CometMissileEffect());
        }
    }

    class CometMissileEffect : DestroyEffect
    {
        public CometMissileEffect() : base(new OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(6000), 1, 1, true)
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
    }
}
