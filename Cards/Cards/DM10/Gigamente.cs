using Common;

namespace Cards.Cards.DM10
{
    class Gigamente : SilentSkillCreature
    {
        public Gigamente() : base("Gigamente", 4, 3000, Subtype.Chimera, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
