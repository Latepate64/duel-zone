using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000), new TriggeredAbilities.DestroyedAbility(new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(Name)));
        }
    }
}
