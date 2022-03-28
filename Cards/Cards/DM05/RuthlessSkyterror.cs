using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class RuthlessSkyterror : Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization.Water));
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
