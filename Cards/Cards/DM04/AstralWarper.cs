using Common;

namespace Cards.Cards.DM04
{
    class AstralWarper : EvolutionCreature
    {
        public AstralWarper() : base("Astral Warper", 6, 5000, Subtype.CyberVirus, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDrawCardsEffect(3));
        }
    }
}
