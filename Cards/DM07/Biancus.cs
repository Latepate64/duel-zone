using Abilities;
using Abilities.Static;

namespace Cards.DM07
{
    sealed class Biancus : Creature
    {
        public Biancus() : base("Biancus", 6, 3000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
