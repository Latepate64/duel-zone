using Abilities.Triggered;
using Abilities.Triggered;

namespace Cards.Cards.DM08
{
    class BruiserDragon : Engine.Creature
    {
        public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
