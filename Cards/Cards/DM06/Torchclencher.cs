using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM06
{
    class Torchclencher : Creature
    {
        public Torchclencher() : base("Torchclencher", 3, 2000, Race.Dragonoid, Civilization.Fire)
        {
            AddStaticAbilities(new TorchclencherEffect());
        }
    }

    class TorchclencherEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public TorchclencherEffect()
        {
        }

        public TorchclencherEffect(TorchclencherEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            var creature = Source;
            if (game.BattleZone.GetOtherCreatures(Applier.Id, creature.Id, Civilization.Fire).Any())
            {
                creature.AddGrantedAbility(new PowerAttackerAbility(3000));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new TorchclencherEffect(this);
        }

        public override string ToString()
        {
            return "While you have at least one other fire creature in the battle zone, this creature has \"Power attacker +3000.\"";
        }
    }
}
