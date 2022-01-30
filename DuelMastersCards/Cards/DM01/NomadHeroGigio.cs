using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class NomadHeroGigio : Creature
    {
        public NomadHeroGigio() : base("Nomad Hero Gigio", 5, Civilization.Fire, 3000, Subtype.MachineEater)
        {
            Abilities.Add(new CanAttackUntappedCreaturesAbility());
        }
    }
}
