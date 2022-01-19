using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, Civilization.Nature, 2000, Subtype.BeastFolk)
        {
            Abilities.Add(new MightyShouterAbility());
        }
    }
}
