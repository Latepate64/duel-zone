using Common.GameEvents;
using Engine.Abilities;
using Engine.Durations;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class AbilityGrantingEffect : CharacteristicModifyingEffect
    {
        public Ability Ability { get; }

        public AbilityGrantingEffect(AbilityGrantingEffect effect) : base(effect)
        {
            Ability = effect.Ability;
        }

        public AbilityGrantingEffect(CardFilter filter, Duration duration, Ability ability) : base(filter, duration)
        {
            Ability = ability;
        }

        public override ContinuousEffect Copy()
        {
            return new AbilityGrantingEffect(this);
        }

        public override void Start(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card))))
            {
                game.AddAbility(card, Ability.Copy());
            }
        }

        public override void End(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card))))
            {
                game.RemoveAbility(card, Ability.Id);
            }
        }

        public override void Update(Game game, GameEvent e)
        {
            if (e is CardMovedEvent cme)
            {
                var card = game.GetCard(cme.CardInDestinationZone);
                if (Filter.Applies(card, game, game.GetOwner(card)))
                {
                    if (cme.Destination == Common.ZoneType.BattleZone)
                    {
                        game.AddAbility(card, Ability.Copy());
                    }
                    if (cme.Source == Common.ZoneType.BattleZone)
                    {
                        game.RemoveAbility(card, Ability.Id);
                    }
                }
            }
        }
    }
}
