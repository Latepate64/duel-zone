using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class FaerieChild : Creature
    {
        public FaerieChild() : base("Faerie Child", 4, Civilization.Water, 2000, Subtype.CyberVirus)
        {
            Abilities.Add(new UnblockableAbility());
        }
    }
}
