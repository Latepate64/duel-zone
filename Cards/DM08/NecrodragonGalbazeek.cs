using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM08
{
    class NecrodragonGalbazeek : Engine.Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, 9000, Interfaces.Race.ZombieDragon, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
