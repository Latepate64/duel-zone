using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class CoilingVines : Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, Common.Civilization.Nature, 3000, Common.Subtype.TreeFolk)
        {
            // When this creature would be destroyed, put it into your mana zone instead. 
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
