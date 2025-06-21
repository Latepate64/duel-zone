using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.Cards.DM09
{
    class ShockTrooperMykee : Engine.Creature
    {
        public ShockTrooperMykee() : base("Shock Trooper Mykee", 6, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
