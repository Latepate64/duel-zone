using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, 8000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new GigaberosEffect()), new DoubleBreakerAbility());
        }
    }

    class GigaberosEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == source.Source);
            if (thisCreature == null)
            {
                return new DestroyEffect(new CardFilters.OwnersBattleZoneCreatureFilter(), 2, 2, true).Apply(game, source);
            }
            else if (creatures.Where(x => x.Id != source.Source).Count() < 2)
            {
                return game.Move(ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = game.GetPlayer(source.Owner).Choose(new BoundedCardSelectionInEffect(source.Owner, creatures, 1, 2, ToString()), game).Decision;
                if ((selection.Count() == 1 && selection.Single() == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x != thisCreature.Id)))
                {
                    return game .Move(ZoneType.BattleZone, ZoneType.Graveyard, selection.Select(x => game.GetCard(x)).ToArray());
                }
                else
                {
                    // Selection was illegal, try selecting again.
                    return Apply(game, source);
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
