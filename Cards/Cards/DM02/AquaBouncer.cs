using Abilities.Triggered;
using Cards.OneShotEffects;
using Abilities.Triggered;
using Effects.Continuous;

namespace Cards.Cards.DM02
{
    class AquaBouncer : Engine.Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
