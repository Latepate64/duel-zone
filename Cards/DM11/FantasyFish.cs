using Abilities.Static;

namespace Cards.DM11
{
    sealed class FantasyFish : Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, 2000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddAbilities(new BlockerAbility());
        }
    }
}
