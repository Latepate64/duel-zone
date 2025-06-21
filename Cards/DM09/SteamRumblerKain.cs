using TriggeredAbilities;

namespace Cards.DM09
{
    class SteamRumblerKain : Engine.Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
