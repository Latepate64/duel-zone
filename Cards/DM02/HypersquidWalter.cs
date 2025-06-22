using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class HypersquidWalter : Engine.Creature
    {
        public HypersquidWalter() : base("Hypersquid Walter", 3, 1000, Interfaces.Race.CyberLord, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
