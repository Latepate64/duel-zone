using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class GeneralDarkFiend : Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
