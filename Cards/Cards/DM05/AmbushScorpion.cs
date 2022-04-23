using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddWhenThisCreatureIsDestroyedAbility(new AmbushScorpionEffect());
        }
    }

    class AmbushScorpionEffect : YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect
    {
        public AmbushScorpionEffect(YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect effect) : base(effect)
        {
        }

        public AmbushScorpionEffect() : base("Ambush Scorpion")
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AmbushScorpionEffect(this);
        }
    }
}
