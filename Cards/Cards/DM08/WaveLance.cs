using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class WaveLance : Spell
    {
        public WaveLance() : base("Wave Lance", 3, Civilization.Water)
        {
            AddSpellAbilities(new WaveLanceEffect());
        }
    }

    class WaveLanceEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var creature = source.GetController(game).ChooseCard(game.BattleZone.Creatures, ToString());
            game.Move(source, ZoneType.BattleZone, ZoneType.Hand, creature);
            if (creature.IsDragon)
            {
                source.GetController(game).DrawCardsOptionally(game, source, 1);
            }
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
