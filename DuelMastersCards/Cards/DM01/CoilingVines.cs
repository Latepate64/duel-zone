using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class CoilingVines : Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, Civilization.Nature, 3000, Subtype.TreeFolk)
        {
            // When this creature would be destroyed, put it into your mana zone instead. 
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}
