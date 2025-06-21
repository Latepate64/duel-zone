using TriggeredAbilities;

namespace Cards.DM02
{
    class BolzardDragon : Engine.Creature
    {
        public BolzardDragon() : base("Bolzard Dragon", 6, 5000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndPutItIntoHisGraveyardEffect()));
        }
    }
}
