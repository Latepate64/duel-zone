using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class Sopian : Engine.Creature
    {
        public Sopian() : base("Sopian", 4, 2000, Engine.Race.CyberLord, Engine.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
