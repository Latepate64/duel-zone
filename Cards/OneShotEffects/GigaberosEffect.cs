using Common;
using Engine;
using Engine.Abilities;
using Engine.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GigaberosEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            var otherCreatures = creatures.Where(x => x.Id != source.Source);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == source.Source);
            if (thisCreature == null)
            {
                if (otherCreatures.Count() > 2)
                {
                    var selection = game.GetPlayer(source.Owner).Choose(new GuidSelection(source.Owner, otherCreatures, 2, 2)).Decision;
                    game.Move(selection.Select(x => game.GetCard(x)), ZoneType.BattleZone, ZoneType.Graveyard);
                }
                else
                {
                    game.Move(otherCreatures, ZoneType.BattleZone, ZoneType.Graveyard);
                }
            }
            else if(otherCreatures.Count() < 2)
            {
                game.Move(thisCreature, ZoneType.BattleZone, ZoneType.Graveyard);
            }
            else
            {
                var selection = game.GetPlayer(source.Owner).Choose(new GuidSelection(source.Owner, creatures, 1, 2)).Decision;
                if ((selection.Count() == 1 && selection.Single() == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x != thisCreature.Id)))
                {
                    game.Move(selection.Select(x => game.GetCard(x)), ZoneType.BattleZone, ZoneType.Graveyard);
                }
                else
                {
                    // Selection was illegal, try selecting again.
                    Apply(game, source);
                }
            }
        }

        public override OneShotEffect Copy()
        {
            return new GigaberosEffect();
        }
    }
}
