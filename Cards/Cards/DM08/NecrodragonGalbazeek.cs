using Common;

namespace Cards.Cards.DM08
{
    class NecrodragonGalbazeek : Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, 9000, Subtype.ZombieDragon, Civilization.Darkness)
        {
            // Whenever this creature attacks, choose one of your shields and put it into your graveyard.
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SelfShieldBurnEffect()));
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
