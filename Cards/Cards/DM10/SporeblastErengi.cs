using Common;

namespace Cards.Cards.DM10
{
    class SporeblastErengi : SilentSkillCreature
    {
        public SporeblastErengi() : base("Sporeblast Erengi", 4, 4000, Subtype.BalloonMushroom, Civilization.Nature)
        {
            AddSilentSkillAbility(new OneShotEffects.SearchCreatureEffect());
        }
    }
}
