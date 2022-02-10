using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class NomadHeroGigio : Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, Common.Civilization.Fire, 3000, Common.Subtype.MachineEater)
        {
            Abilities.Add(new CanAttackUntappedCreaturesAbility());
        }
    }
}
