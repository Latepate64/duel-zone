using Common;

namespace Cards.Cards.DM06
{
    class Sopian : Creature
    {
        public Sopian() : base("Sopian", 4, 2000, Subtype.CyberLord, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect()));
        }
    }
}
