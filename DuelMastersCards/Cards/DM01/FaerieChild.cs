using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class FaerieChild : Creature
    {
        public FaerieChild() : base("Faerie Child", 4, Civilization.Water, 2000, Subtype.CyberVirus)
        {
            Abilities.Add(new UnblockableAbility());
        }
    }
}
