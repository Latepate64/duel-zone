using Engine.Abilities;

namespace Cards.DM06
{
    sealed class Sopian : Creature
    {
        public Sopian() : base("Sopian", 4, 2000, Interfaces.Race.CyberLord, Interfaces.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
