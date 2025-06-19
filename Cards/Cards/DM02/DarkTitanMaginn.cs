using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class DarkTitanMaginn : Engine.Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, 4000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
