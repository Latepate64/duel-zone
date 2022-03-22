using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class CataclysmicEruption : Spell
    {
        public CataclysmicEruption() : base("Cataclysmic Eruption", 8, Civilization.Fire)
        {
            AddSpellAbilities(new CataclysmicEruptionEffect());
        }
    }

    class CataclysmicEruptionEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Owner).Where(x => x.Civilizations.Contains(Civilization.Nature)).Count();
            return new OneShotEffects.ManaBurnEffect(new CardFilters.OpponentsManaZoneCardFilter(), 0, amount, true).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new CataclysmicEruptionEffect();
        }

        public override string ToString()
        {
            return "For each nature creature you have in the battle zone, you may choose a card in your opponent's mana zone and put it into his graveyard.";
        }
    }
}
