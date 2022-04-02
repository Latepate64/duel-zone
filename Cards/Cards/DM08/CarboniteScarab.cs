using Common;

namespace Cards.Cards.DM08
{
    class CarboniteScarab : TurboRushCreature
    {
        public CarboniteScarab() : base("Carbonite Scarab", 4, 3000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldsEffect()));
        }
    }
}
