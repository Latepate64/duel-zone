using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class RuthlessSkyterror : Creature
    {
        public RuthlessSkyterror() : base("Ruthless Skyterror", 4, 6000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Engine.Civilization.Water));
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
