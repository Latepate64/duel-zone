using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM09
{
    sealed class ShockTrooperMykee : Creature
    {
        public ShockTrooperMykee() : base("Shock Trooper Mykee", 6, 1000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
