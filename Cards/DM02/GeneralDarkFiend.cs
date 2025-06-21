using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM02
{
    class GeneralDarkFiend : Engine.Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Interfaces.Race.DarkLord, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
