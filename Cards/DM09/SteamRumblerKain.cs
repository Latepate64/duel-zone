using TriggeredAbilities;

namespace Cards.DM09
{
    class SteamRumblerKain : Engine.Creature
    {
        public SteamRumblerKain() : base("Steam Rumbler Kain", 4, 5000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect()));
        }
    }
}
