using ContinuousEffects;

namespace Cards.DM05
{
    sealed class RuthlessSkyterror : Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Interfaces.Civilization.Water));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
