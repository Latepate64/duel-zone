using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class RuthlessSkyterror : Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Engine.Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization.Water));
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
