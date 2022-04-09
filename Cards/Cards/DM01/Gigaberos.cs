﻿using Cards.OneShotEffects;
using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, 8000, Subtype.Chimera, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigaberosEffect());
            AddDoubleBreakerAbility();
        }
    }

    class GigaberosEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            // Destroy 2 of your other creatures or destroy this creature.
            var creatures = game.BattleZone.GetCreatures(source.Controller);
            var thisCreature = creatures.SingleOrDefault(x => x.Id == source.Source);
            if (thisCreature == null)
            {
                return new GigaberosDestroyEffect().Apply(game, source);
            }
            else if (creatures.Where(x => x.Id != source.Source).Count() < 2)
            {
                return game.Move(ZoneType.BattleZone, ZoneType.Graveyard, thisCreature);
            }
            else
            {
                var selection = source.GetController(game).Choose(new BoundedCardSelectionInEffect(source.Controller, creatures, 1, 2, ToString()), game).Decision;
                if ((selection.Count() == 1 && selection.Single() == thisCreature.Id) || (selection.Count() == 2 && selection.All(x => x != thisCreature.Id)))
                {
                    return game.Move(ZoneType.BattleZone, ZoneType.Graveyard, selection.Select(x => game.GetCard(x)).ToArray());
                }
                else
                {
                    // Selection was illegal, try selecting again.
                    return Apply(game, source);
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

    class GigaberosDestroyEffect : DestroyEffect
    {
        public GigaberosDestroyEffect() : base(2, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GigaberosDestroyEffect();
        }

        public override string ToString()
        {
            return "Destroy 2 of your other creatures.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(source.Controller, source.Source);
        }
    }
}
