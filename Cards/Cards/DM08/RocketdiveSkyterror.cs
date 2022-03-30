using Common;

namespace Cards.Cards.DM08
{
    class RocketdiveSkyterror : Creature
    {
        public RocketdiveSkyterror() : base("Rocketdive Skyterror", 4, 5000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddThisCreatureCannotBeAttackedAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddPowerAttackerAbility(1000);
        }
    }
}
