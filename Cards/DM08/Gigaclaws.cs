using TriggeredAbilities;

namespace Cards.DM08
{
    class Gigaclaws : TurboRushCreature
    {
        public Gigaclaws() : base("Gigaclaws", 5, 2000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
