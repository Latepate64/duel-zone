using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;

namespace DuelMastersCards
{
    public static class CardFactory
    {
        static public Card Create(string name)
        {
            return _cards[name].Invoke();
        }

        static readonly private Dictionary<string, Func<Card>> _cards = new()
        {
            { AquaHulcus, () => CreateAquaHulcus() },
            { AquaSurfer, () => CreateAquaSurfer() },

            { BombazarDragonOfDestiny, () => CreateBombazarDragonOfDestiny() },
            { BronzeArmTribe, () => CreateBronzeArmTribe() },
            { BurningMane, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = BurningMane, Power = 2000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },

            { DeadlyFighterBraidClaw, () => CreateDeadlyFighterBraidClaw() },

            { Emeral, () => CreateEmeral() },
            { ExplosiveDudeJoe, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = ExplosiveDudeJoe, Power = 3000, Subtypes = new List<Subtype> { Subtype.Human } } },

            { FearFang, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = FearFang, Power = 3000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            
            { GontaTheWarriorSavage, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 2, Name = GontaTheWarriorSavage, Power = 4000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } } },
            
            { HeartyCapnPolligon, () => CreateHeartyCapnPolligon() },

            { ImmortalBaronVorg, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = ImmortalBaronVorg, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human } } },
            
            { KamikazeChainsawWarrior, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = KamikazeChainsawWarrior, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Armorloid } } },
            
            { PyrofighterMagnus, () => CreatePyrofighterMagnus() },

            { QuixoticHeroSwineSnout, () => CreateQuixoticHeroSwineSnout() },

            { RikabuTheDismantler, () => CreateRikabuTheDismantler() },

            { SniperMosquito, () => CreateSniperMosquito() },
            { Soulswap, () => CreateSoulswap() },

            { Torcon, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = Torcon, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TriHornShepherd, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 5, Name = TriHornShepherd, Power = 5000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TwinCannonSkyterror, () => CreateTwinCannonSkyterror() },

            { WindAxeTheWarriorSavage, () => CreateWindAxeTheWarriorSavage() },
        };

        public const string AquaHulcus = "Aqua Hulcus";
        public const string AquaSurfer = "Aqua Surfer";
        public const string BombazarDragonOfDestiny = "Bombazar, Dragon of Destiny";
        public const string BronzeArmTribe = "Bronze-Arm Tribe";
        public const string BurningMane = "Burning Mane";
        public const string DeadlyFighterBraidClaw = "Deadly Fighter Braid Claw";
        public const string Emeral = "Emeral";
        public const string ExplosiveDudeJoe = "Explosive Dude Joe";
        public const string FearFang = "Fear Fang";
        public const string GontaTheWarriorSavage = "Gonta, the Warrior Savage";
        public const string HeartyCapnPolligon = "Hearty Cap'n Polligon";
        public const string ImmortalBaronVorg = "Immortal Baron, Vorg";
        public const string KamikazeChainsawWarrior = "Kamikaze, Chainsaw Warrior";
        public const string QuixoticHeroSwineSnout = "Quixotic Hero Swine Snout";
        public const string PyrofighterMagnus = "Pyrofighter Magnus";
        public const string RikabuTheDismantler = "Rikabu, the Dismantler";
        public const string SniperMosquito = "Sniper Mosquito";
        public const string Soulswap = "Soulswap";
        public const string Torcon = "Torcon";
        public const string TriHornShepherd = "Tri-Horn Shepherd";
        public const string TwinCannonSkyterror = "Twin-Cannon Skyterror";
        public const string WindAxeTheWarriorSavage = "Wind Axe, the Warrior Savage";

        static Card CreateAquaHulcus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = AquaHulcus, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaHulcusResolvable()));
            return x;
        }

        static Card CreateAquaSurfer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = AquaSurfer, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable()));
            return x;
        }

        static Card CreateBombazarDragonOfDestiny()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 7, Name = BombazarDragonOfDestiny, Power = 6000, Subtypes = new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new DoubleBreakerAbility());
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyResolvable()));
            return x;
        }

        static Card CreateBronzeArmTribe()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = BronzeArmTribe, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BronzeArmTribeResolvable()));
            return x;
        }

        static Card CreateDeadlyFighterBraidClaw()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = DeadlyFighterBraidClaw, Power = 1000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new AttacksIfAbleAbility());
            return x;
        }

        static Card CreateEmeral()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = Emeral, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EmeralResolvable()));
            return x;
        }

        static Card CreateHeartyCapnPolligon()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = HeartyCapnPolligon, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
            x.Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonResolvable()));
            return x;
        }

        static Card CreateQuixoticHeroSwineSnout()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = QuixoticHeroSwineSnout, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new QuixoticHeroSwineSnoutResolvable()));
            return x;
        }

        static Card CreatePyrofighterMagnus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = PyrofighterMagnus, Power = 3000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new AtTheEndOfYourTurnAbility(new PyrofighterMagnusResolvable()));
            return x;
        }

        static Card CreateRikabuTheDismantler()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = RikabuTheDismantler, Power = 1000, Subtypes = new List<Subtype> { Subtype.MachineEater } };
            x.Abilities.Add(new SpeedAttackerAbility());
            return x;
        }

        static Card CreateSniperMosquito()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = SniperMosquito, Power = 2000, Subtypes = new List<Subtype> { Subtype.GiantInsect } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new SniperMosquitoResolvable()));
            return x;
        }

        static Card CreateSoulswap()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = Soulswap };
            x.Abilities.Add(new SpellAbility(new SoulswapResolvable()));
            return x;
        }

        static Card CreateTwinCannonSkyterror()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = TwinCannonSkyterror, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new DoubleBreakerAbility());
            return x;
        }

        static Card CreateWindAxeTheWarriorSavage()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = WindAxeTheWarriorSavage, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageResolvable()));
            return x;
        }
    }
}
