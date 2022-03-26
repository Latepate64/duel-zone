using Common;

namespace Cards.Cards.DM08
{
    class BruiserDragon : Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
