using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class DimensionSplitter : Creature
    {
        public DimensionSplitter() : base("Dimension Splitter", 3, 1000, Engine.Subtype.BrainJacker, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DimensionSplitterEffect());
        }
    }

    class DimensionSplitterEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction(ToString()))
            {
                game.Move(ZoneType.Graveyard, ZoneType.Hand, source.GetController(game).Graveyard.Cards.Where(x => x.IsDragon).ToArray());
            }
            return null;
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
