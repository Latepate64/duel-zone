using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class GatlingSkyterror : Creature
    {
        public GatlingSkyterror() : base("Gatling Skyterror", 7, Civilization.Fire, 7000, Subtype.ArmoredWyvern)
        {
            Abilities.Add(new CanAttackUntappedCreaturesAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
