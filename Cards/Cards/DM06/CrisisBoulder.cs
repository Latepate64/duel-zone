﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class CrisisBoulder : Spell
    {
        public CrisisBoulder() : base("Crisis Boulder", 4, Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new CrisisBoulderEffect());
        }
    }

    class CrisisBoulderEffect : OneShotEffect
    {
        public override void Apply()
        {
            var cards = Applier.Opponent.ManaZone.Cards.Union(Game.BattleZone.GetCreatures(Applier.Opponent));
            var card = Applier.Opponent.ChooseCard(cards, ToString());
            if (card != null)
            {
                Game.Move(Ability, Game.GetZone(card).Type, ZoneType.Graveyard, card);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new CrisisBoulderEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone or a card in his mana zone and puts it into his graveyard.";
        }
    }
}
