using Common;

namespace Cards.Cards.DM10
{
    class Milporo : SilentSkillCreature
    {
        public Milporo() : base("Milporo", 4, 3000, Engine.Subtype.CyberLord, Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.DrawCardsEffect(1));
        }
    }
}
