using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class CavalryGeneralCuratops : Creature
    {
        public CavalryGeneralCuratops() : base("Cavalry General Curatops", 3, Civilization.Fire, 2000, Subtype.Dragonoid)
        {
            Abilities.Add(new StaticAbilities.CanAttackUntappedCreaturesAbility());
        }
    }
}
