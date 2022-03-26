using Common;

namespace Cards.Cards.DM09
{
    class SteamRumblerKain : Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
