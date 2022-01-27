using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class SilverFist : Creature
    {
        public SilverFist() : base("Silver Fist", 4, Civilization.Nature, 3000, Subtype.BeastFolk)
        {
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(2000));
        }
    }
}
