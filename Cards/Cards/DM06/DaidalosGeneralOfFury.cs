using Cards.TriggeredAbilities;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class DaidalosGeneralOfFury : Engine.Creature
    {
        public DaidalosGeneralOfFury() : base("Daidalos, General of Fury", 4, 11000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SacrificeEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
