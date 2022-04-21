using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, 8000, Race.Chimera, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigaberosEffect());
            AddDoubleBreakerAbility();
        }
    }

    class GigaberosEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(source.Controller);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == source.Source);
            if (thisCreature == null)
            {
                game.Destroy(source, game.BattleZone.GetOtherCreatures(source.Controller, source.Source).ToArray());
            }
            else if (creatures.Where(x => x.Id != source.Source).Count() < 2)
            {
                game.Move(source, ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = GetController(game).ChooseCards(creatures, 1, 2, ToString());
                if ((selection.Count() == 1 && selection.Single().Id == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x.Id != thisCreature.Id)))
                {
                    game.Move(source, ZoneType.BattleZone, ZoneType.Graveyard, selection.ToArray());
                }
                else
                {
                    // Selection was illegal, try selecting again.
                    Apply(game, source);
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new GigaberosEffect();
        }

        public override string ToString()
        {
            return "Destroy 2 of your other creatures or destroy this creature.";
        }
    }
}
