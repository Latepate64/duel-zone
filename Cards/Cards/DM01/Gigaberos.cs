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
            var creatures = game.BattleZone.GetCreatures(GetSourceAbility(game).Controller);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == GetSourceAbility(game).Source);
            if (thisCreature == null)
            {
                game.Destroy(GetSourceAbility(game), game.BattleZone.GetOtherCreatures(GetSourceAbility(game).Controller, GetSourceAbility(game).Source).ToArray());
            }
            else if (creatures.Where(x => x.Id != GetSourceAbility(game).Source).Count() < 2)
            {
                game.Move(GetSourceAbility(game), ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = GetController(game).ChooseCards(creatures, 1, 2, ToString());
                if ((selection.Count() == 1 && selection.Single().Id == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x.Id != thisCreature.Id)))
                {
                    game.Move(GetSourceAbility(game), ZoneType.BattleZone, ZoneType.Graveyard, selection.ToArray());
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
