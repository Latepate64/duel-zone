using ContinuousEffects;

namespace Cards.DM05
{
    class RuthlessSkyterror : Engine.Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Engine.Civilization.Water));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
