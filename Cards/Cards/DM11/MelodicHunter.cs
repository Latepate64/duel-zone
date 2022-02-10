using Cards.StaticAbilities;

namespace Cards.Cards.DM11
{
    public class MelodicHunter : Creature
    {
        public MelodicHunter() : base("Melodic Hunter", 5, Common.Civilization.Water, 3000, Common.Subtype.Merfolk)
        {
            Abilities.Add(new BlockerAbility());
        }
    }
}
