using Common;

namespace Cards.Cards.DM10
{
    class SporeblastErengi : SilentSkillCreature
    {
        public SporeblastErengi() : base("Sporeblast Erengi", 4, 4000, Engine.Subtype.BalloonMushroom, Civilization.Nature)
        {
            AddSilentSkillAbility(new OneShotEffects.SearchCreatureEffect());
        }
    }
}
