using Cards.StaticAbilities;

namespace Cards.Cards.DM11
{
    class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, 3000, Common.Subtype.Merfolk, Common.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
