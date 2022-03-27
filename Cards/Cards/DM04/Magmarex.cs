using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, 3000, Subtype.RockBeast, Civilization.Fire)
        {
            ShieldTrigger = true;
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new MagmarexEffect()));
        }
    }

    class MagmarexEffect : DestroyAreaOfEffect
    {
        public MagmarexEffect() : base(new BattleZoneExactPowerCreatureFilter(1000))
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MagmarexEffect();
        }

        public override string ToString()
        {
            return "Destroy all creatures that have power 1000.";
        }
    }
}
