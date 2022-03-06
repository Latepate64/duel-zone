using Common;

namespace Cards.Cards.DM08
{
    class BruiserDragon : Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            // When this creature is destroyed, choose one of your shields and put it into your graveyard.
            AddAbilities(new TriggeredAbilities.DestroyedAbility(new OneShotEffects.SelfShieldBurnEffect()));
        }
    }
}
