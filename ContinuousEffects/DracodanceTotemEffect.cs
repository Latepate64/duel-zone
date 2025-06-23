using Engine.GameEvents;
using System.Linq;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class DracodanceTotemEffect : ContinuousEffects.DestructionReplacementEffect
{
    public DracodanceTotemEffect() : base() 
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // game.AddReflexiveTriggeredAbility(new ReflexiveTriggeredAbility(new DracodanceTotemRecoveryEffect(), Ability));
        // return new CardMovedEvent(gameEvent as ICardMovedEvent)
        // {
        //     Destination = ZoneType.Hand
        // };
    }

    public override IContinuousEffect Copy()
    {
        return new DracodanceTotemEffect();
    }

    public override string ToString()
    {
        return "When this creature would be destroyed, if you have a creature that has Dragon in its race in your mana zone, put this creature into your mana zone instead of destroying it. Then return a creature that has Dragon in its race from your mana zone to your hand.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return IsSourceOfAbility(card) && Controller.ManaZone.Creatures.Any(x => x.IsDragon);
    }
}
