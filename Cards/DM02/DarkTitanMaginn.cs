using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02
{
    class DarkTitanMaginn : Engine.Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, 4000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
