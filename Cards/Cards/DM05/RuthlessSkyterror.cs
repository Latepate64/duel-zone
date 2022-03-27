using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM05
{
    class RuthlessSkyterror : Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesAbility(Civilization.Water), new ThisCreatureCannotAttackPlayersAbility());
        }
    }
}
