﻿using Engine;
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
        public override void Apply(IGame game)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(Source.Controller);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == Source.Source);
            if (thisCreature == null)
            {
                game.Destroy(Source, game.BattleZone.GetOtherCreatures(Source.Controller, Source.Source).ToArray());
            }
            else if (creatures.Where(x => x.Id != Source.Source).Count() < 2)
            {
                game.Move(Source, ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = Controller.ChooseCards(creatures, 1, 2, ToString());
                if ((selection.Count() == 1 && selection.Single().Id == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x.Id != thisCreature.Id)))
                {
                    game.Move(Source, ZoneType.BattleZone, ZoneType.Graveyard, selection.ToArray());
                }
                else
                {
                    // Selection was illegal, try selecting again.
                    Apply(game);
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
