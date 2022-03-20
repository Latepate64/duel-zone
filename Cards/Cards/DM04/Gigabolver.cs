using Common;

namespace Cards.Cards.DM04
{
    class Gigabolver : Creature
    {
        public Gigabolver() : base("Gigabolver", 4, 3000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsAbility(Civilization.Light));
        }
    }
}
