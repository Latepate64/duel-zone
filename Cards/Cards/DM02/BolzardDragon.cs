using Abilities.Triggered;

namespace Cards.Cards.DM02
{
    class BolzardDragon : Engine.Creature
    {
        public BolzardDragon() : base("Bolzard Dragon", 6, 5000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect()));
        }
    }
}
