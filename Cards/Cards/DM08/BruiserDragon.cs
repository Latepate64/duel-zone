using Common;

namespace Cards.Cards.DM08
{
    class BruiserDragon : Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, Civilization.Fire, 5000, Subtype.ArmoredDragon)
        {
            // When this creature is destroyed, choose one of your shields and put it into your graveyard.
            Abilities.Add(new TriggeredAbilities.DestroyedAbility(new OneShotEffects.SelfShieldBurnEffect()));
        }
    }
}
