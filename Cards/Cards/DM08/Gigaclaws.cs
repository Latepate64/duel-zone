using Common;

namespace Cards.Cards.DM08
{
    class Gigaclaws : Creature
    {
        public Gigaclaws() : base("Gigaclaws", 5, 2000, Subtype.Chimera, Civilization.Darkness)
        {
            AddTurboRushAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentDiscardsHisHandEffect()));
        }
    }
}
