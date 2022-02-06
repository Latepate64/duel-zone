using Cards.CardFilters;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System;

namespace Cards.StaticAbilities
{
    internal class PetrovaAbility : StaticAbility
    {
        public PetrovaAbility()
        {
            //ContinuousEffects.Add(new PowerModifyingEffect(new NoneFilter(), 4000, new Indefinite()));
            ContinuousEffects.Add(new PetrovaChannelerOfSunsEffect(new CardMovedEvent { Source = ZoneType.Anywhere, Destination = ZoneType.BattleZone }));
        }

        public PetrovaAbility(PetrovaAbility ability) : base(ability)
        {
        }

        //public override Choice Apply(Game game, Decision decision)
        //{
        //    if (decision == null)
        //    {
        //        return new EnumChoice(Owner, new List<Enum> { Common.Subtype.MechaDelSol });
        //    }
        //    else
        //    {
        //        ContinuousEffects.Single().Filters.Clear();
        //        ContinuousEffects.Single().Filters.Add(new SubtypeFilter((Subtype)(decision as EnumDecision).Decision) { Owner = Owner, Target = Source });
        //        return null;
        //    }
        //}

        public override Ability Copy()
        {
            return new PetrovaAbility(this);
        }

        //public override void Revoke()
        //{
        //    ContinuousEffects.Single().Filters.Clear();
        //    ContinuousEffects.Single().Filters.Add(new NoneFilter { Owner = Owner, Target = Source });
        //}
    }

    internal class PetrovaChannelerOfSunsEffect : ReplacementEffect
    {
        public PetrovaChannelerOfSunsEffect(GameEvent gameEvent) : base(gameEvent)
        {
        }

        public PetrovaChannelerOfSunsEffect(PetrovaChannelerOfSunsEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PetrovaChannelerOfSunsEffect(this);
        }

        public override GameEvent Apply(Game game, Engine.Player player)
        {
            throw new NotImplementedException();
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }

        public override string ToString()
        {
            return "As you put this creature into the battle zone, choose a race other than Mecha Del Sol. Each creature of that race gets +4000 power.";
        }
    }
}
