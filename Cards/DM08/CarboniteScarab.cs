using TriggeredAbilities;

namespace Cards.DM08
{
    class CarboniteScarab : TurboRushCreature
    {
        public CarboniteScarab() : base("Carbonite Scarab", 4, 3000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddTurboRushAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
        }
    }
}
