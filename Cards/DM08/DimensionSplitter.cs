using TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.DM08
{
    class DimensionSplitter : Creature
    {
        public DimensionSplitter() : base("Dimension Splitter", 3, 1000, Race.BrainJacker, Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DimensionSplitterEffect()));
        }
    }

    class DimensionSplitterEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            if (Controller.ChooseToTakeAction(ToString()))
            {
                game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. Controller.Graveyard.Dragons]);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new DimensionSplitterEffect();
        }

        public override string ToString()
        {
            return "You may return all creatures that have Dragon in their race from your graveyard to your hand.";
        }
    }
}
