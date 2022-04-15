using Common;

namespace Cards.Cards.DM06
{
    class Sopian : Creature
    {
        public Sopian() : base("Sopian", 4, 2000, Engine.Subtype.CyberLord, Civilization.Water)
        {
            AddTapAbility(new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect());
        }
    }
}
