using Common;

namespace Cards.Cards.DM10
{
    public class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage() : base("Gonta, the Warrior Savage", 2, 4000)
        {
            Civilizations.Add(Civilization.Fire);
            Civilizations.Add(Civilization.Nature);
            Subtypes.Add(Subtype.Human);
            Subtypes.Add(Subtype.BeastFolk);
        }
    }
}
