using DuelMastersModels;
using System.Collections.Generic;

namespace DuelMastersCards.Cards
{
    public class GontaTheWarriorSavage : Creature
    {
        public GontaTheWarriorSavage() : base("Gonta, the Warrior Savage", 2, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 4000, new List<Subtype> { Subtype.Human, Subtype.BeastFolk })
        {
        }
    }
}
