using Common;

namespace Cards.Cards.DM10
{
    class FlohdaniTheSpydroid : SilentSkillCreature
    {
        public FlohdaniTheSpydroid() : base("Flohdani, the Spydroid", 4, 4000, Subtype.Soltrooper, Civilization.Light)
        {
            AddSilentSkillAbility(new OneShotEffects.ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(2));
        }
    }
}
