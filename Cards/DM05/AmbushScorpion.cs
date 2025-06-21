using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class AmbushScorpion : Engine.Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new AmbushScorpionEffect()));
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
