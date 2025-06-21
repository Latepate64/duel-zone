using TriggeredAbilities;

namespace Cards.DM08
{
    class BruiserDragon : Engine.Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
