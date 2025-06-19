using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class NecrodragonGalbazeek : Engine.Creature
    {
        public NecrodragonGalbazeek() : base("Necrodragon Galbazeek", 6, 9000, Engine.Race.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
