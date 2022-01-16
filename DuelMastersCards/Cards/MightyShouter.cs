using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 1, Civilization.Nature, 2000, Subtype.BeastFolk) //TODO: Mana cost to 3
        {
            Abilities.Add(new MightyShouterAbility());
        }
    }
}
