using System;
using Engine.Zones;
using Interfaces;
using Interfaces.Zones;

namespace Engine;

public sealed class PlayerV2 : IPlayerV2
{
    public PlayerV2()
    {
    }

    public PlayerV2(PlayerV2 other)
    {
        Deck = other.Deck.Copy() as IDeck;
        ShieldZone = other.ShieldZone.Copy() as IShieldZone;
        Hand = other.Hand.Copy() as IHand;
        ManaZone = other.ManaZone.Copy() as IManaZone;
        Graveyard = other.Graveyard.Copy() as IGraveyard;
        Opponent = other.Opponent; // Do not copy opponent as it creates a loop
    }

    public IDeck Deck { get; } = new Deck();
    public IShieldZone ShieldZone { get; } = new ShieldZone();
    public IHand Hand { get; } = new Hand();
    public IManaZone ManaZone { get; } = new ManaZone();
    public IGraveyard Graveyard { get; } = new Graveyard();
    public IPlayerV2 Opponent { get; set; }

    public IPlayerV2 Copy()
    {
        return new PlayerV2(this);
    }

    public override bool Equals(object obj)
    {
        if (obj is not PlayerV2 player) return false;
        if (!Deck.Equals(player.Deck)) return false;
        if (!ShieldZone.Equals(player.ShieldZone)) return false;
        if (!Hand.Equals(player.Hand)) return false;
        if (!ManaZone.Equals(player.ManaZone)) return false;
        if (!Graveyard.Equals(player.Graveyard)) return false;
        // Do not check opponent as it creates a loop
        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Deck);
        hash.Add(ShieldZone);
        hash.Add(Hand);
        hash.Add(ManaZone);
        hash.Add(Graveyard);
        // Do not add opponent as it creates a loop
        return hash.ToHashCode();
    }

    public void SetOwnerForCards()
    {
        Deck.SetOwner(this);
        ShieldZone.SetOwner(this);
        Hand.SetOwner(this);
        ManaZone.SetOwner(this);
        Graveyard.SetOwner(this);
    }
}