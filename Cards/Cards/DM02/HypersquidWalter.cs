using TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class HypersquidWalter : Engine.Creature
    {
        public HypersquidWalter() : base("Hypersquid Walter", 3, 1000, Engine.Race.CyberLord, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
