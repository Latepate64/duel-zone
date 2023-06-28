﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousRebirth : Spell
    {
        public MiraculousRebirth() : base("Miraculous Rebirth", 6, Civilization.Fire, Civilization.Nature)
        {
            AddSpellAbilities(new MiraculousRebirthEffect());
        }
    }

    class MiraculousRebirthEffect : OneShotEffect
    {
        public MiraculousRebirthEffect()
        {
        }

        public MiraculousRebirthEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var destroyed = Applier.DestroyOpponentsCreatureWithMaxPower(5000, ToString());
            if (destroyed != null)
            {
                var creature = Applier.ChooseCard(Applier.Deck.Creatures.Where(x => x.ManaCost == destroyed.ManaCost), ToString());
                Game.Move(Ability, ZoneType.Deck, ZoneType.BattleZone, creature);
                Applier.ShuffleOwnDeck();
            }
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousRebirthEffect(this);
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has power 5000 or less. When your opponent puts that creature into his graveyard, search your deck. You may take a creature from your deck that has the same cost as that creature and put it into the battle zone. Then shuffle your deck.";
        }
    }
}
