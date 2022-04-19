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
        public override void Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Controller).Count(x => x.HasCivilization(Civilization.Nature));
            new OneShotEffects.ChooseUpToCardsInYourOpponentsManaZoneAndPutThemIntoHisGraveyardEffect(amount).Apply(game, source);
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
