using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM09
{
    class ShockTrooperMykee : Creature
    {
        public ShockTrooperMykee() : base("Shock Trooper Mykee", 6, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
