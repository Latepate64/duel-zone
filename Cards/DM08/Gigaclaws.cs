using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class Gigaclaws : TurboRushCreature
    {
        public Gigaclaws() : base("Gigaclaws", 5, 2000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
