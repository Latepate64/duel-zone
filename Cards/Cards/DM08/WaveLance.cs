using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class WaveLance : Spell
    {
        public WaveLance() : base("Wave Lance", 3, Engine.Civilization.Water)
        {
            AddSpellAbilities(new WaveLanceEffect());
        }
    }

    class WaveLanceEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creature = new OneShotEffects.ChooseCreaturesInTheBattleZoneAndReturnItToItsOwnersHandEffect().Apply(game, source);
            if (creature.Any(x => x.IsDragon))
            {
                new OneShotEffects.YouMayDrawCardsEffect(1).Apply(game, source);
            }
            return creature;
        }

        public override IOneShotEffect Copy()
        {
            return new WaveLanceEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in the battle zone and return it to its owner's hand. If it has Dragon in its race, you may draw a card.";
        }
    }
}
