using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class DaidalosGeneralOfFury : Creature
    {
        public DaidalosGeneralOfFury() : base("Daidalos, General of Fury", 4, 11000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.SacrificeEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
