using Common;

namespace Cards.Cards.DM09
{
    class SteamRumblerKain : Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Subtype.Armorloid, Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }
}
