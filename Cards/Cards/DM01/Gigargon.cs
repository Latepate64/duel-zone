using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(2));
        }
    }
}
