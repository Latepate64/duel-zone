using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility(), new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
        }
    }
}
