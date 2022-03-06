using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class NomadHeroGigio : Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, 3000, Common.Subtype.MachineEater, Common.Civilization.Fire)
        {
            Abilities.Add(new CanAttackUntappedCreaturesAbility());
        }
    }
}
