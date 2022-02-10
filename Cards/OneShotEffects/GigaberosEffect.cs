using Common;
using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GigaberosEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == source.Source);
            if (thisCreature == null)
            {
                new DestroyEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 2, 2, true).Apply(game, source);
            }
            else if (creatures.Where(x => x.Id != source.Source).Count() < 2)
            {
                game.Move(ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = game.GetPlayer(source.Owner).Choose(new CardSelectionInEffect(source.Owner, creatures, 1, 2, ToString()), game).Decision;
                if ((selection.Count() == 1 && selection.Single() == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x != thisCreature.Id)))
                {
                    game.Move(ZoneType.BattleZone, ZoneType.Graveyard, selection.Select(x => game.GetCard(x)).ToArray());
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

        public override string ToString()
        {
            return "Destroy 2 of your other creatures or destroy this creature.";
        }
    }
}
