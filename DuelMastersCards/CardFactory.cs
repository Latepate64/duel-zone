using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards
{
    public static class CardFactory
    {
        static public Card Create(string name)
        {
            return _cards[name].Invoke();
        }

        static public IEnumerable<Card> CreateAll()
        {
            return _cards.Select(x => x.Value.Invoke());
        }

        #region Card names
        const string AquaBouncer = "Aqua Bouncer";
        const string AquaHulcus = "Aqua Hulcus";
        const string AquaShooter = "Aqua Shooter";
        const string AquaSurfer = "Aqua Surfer";

        const string BalzaSeekerOfHyperpearls = "Balza, Seeker of Hyperpearls";
        const string BatteryCluster = "Battery Cluster";
        const string BlizzardOfSpears = "Blizzard of Spears";
        const string BombazarDragonOfDestiny = "Bombazar, Dragon of Destiny";
        const string BronzeArmTribe = "Bronze-Arm Tribe";
        const string BurningMane = "Burning Mane";
        const string BurstShot = "Burst Shot";

        const string Corile = "Corile";
        const string CraniumClamp = "Cranium Clamp";
        const string CrimsonHammer = "Crimson Hammer";

        const string DarkRavenShadowOfGrief = "Dark Raven, Shadow of Grief";
        const string DeadlyFighterBraidClaw = "Deadly Fighter Braid Claw";
        const string DiaNorkMoonlightGuardian = "Dia Nork, Moonlight Guardian";

        const string Emeral = "Emeral";
        const string EmeraldGrass = "Emerald Grass";
        const string EngbeltTheSpydroid = "Engbelt, the Spydroid";
        const string ExplosiveDudeJoe = "Explosive Dude Joe";

        const string FantasyFish = "Fantasy Fish";
        const string FearFang = "Fear Fang";
        const string FerrosaturnSpectralKnight = "Ferrosaturn, Spectral Knight";

        const string GhostTouch = "Ghost Touch";
        const string Gigabalza = "Gigabalza";
        const string GontaTheWarriorSavage = "Gonta, the Warrior Savage";
        const string GranGureSpaceGuardian = "Gran Gure, Space Guardian";
        const string GrayBalloonShadowOfGreed = "Gray Balloon, Shadow of Greed";

        const string HazardCrawler = "Hazard Crawler";
        const string HeartyCapnPolligon = "Hearty Cap'n Polligon";
        const string HolyAwe = "Holy Awe";
        const string HorridWorm = "Horrid Worm";
        const string HunterCluster = "Hunter Cluster";
        const string HunterFish = "Hunter Fish";

        const string ImmortalBaronVorg = "Immortal Baron, Vorg";

        const string KamikazeChainsawWarrior = "Kamikaze, Chainsaw Warrior";
        const string KanesillTheExplorer = "Kanesill, the Explorer";
        const string KingCoral = "King Coral";

        const string Locomotiver = "Locomotiver";
        const string LaUraGigaSkyGuardian = "La Ura Giga, Sky Guardian";

        const string MadrillonFish = "Madrillon Fish";
        const string Magmarex = "Magmarex";
        const string MagrisVizierOfMagnetism = "Magris, Vizier of Magnetism";
        const string MarineFlower = "Marine Flower";
        const string MelodicHunter = "Melodic Hunter";
        const string MikayRattlingDoll = "Mikay, Rattling Doll";
        const string MistRiasSonicGuardian = "Mist Rias, Sonic Guardian";

        const string NaturalSnare = "Natural Snare";
        const string NightMasterShadowOfDecay = "Night Master, Shadow of Decay";

        const string QuixoticHeroSwineSnout = "Quixotic Hero Swine Snout";

        const string PalaOlesisMorningGuardian = "Pala Olesis, Morning Guardian";
        const string PhantomDragonsFlame = "Phantom Dragon's Flame";
        const string PhantomFish = "Phantom Fish";
        const string PoltalesterTheSpydroid = "Poltalester, the Spydroid";
        const string ProwlingElephish = "Prowling Elephish";
        const string PyrofighterMagnus = "Pyrofighter Magnus";

        const string RevolverFish = "Revolver Fish";
        const string RikabuTheDismantler = "Rikabu, the Dismantler";

        const string SariusVizierOfSuppression = "Sarius, Vizier of Suppression";
        const string Seamine = "Seamine";
        const string SenatineJadeTree = "Senatine Jade Tree";
        const string SniperMosquito = "Sniper Mosquito";
        const string Soulswap = "Soulswap";
        const string SpasticMissile = "Spastic Missile";
        const string SupersonicJetPack = "Supersonic Jet Pack";
        const string SzubsKinTwilightGuardian = "Szubs Kin, Twilight Guardian";

        const string TenTonCrunch = "Ten-Ton Crunch";
        const string TerrorPit = "Terror Pit";
        const string TidePatroller = "Tide Patroller";
        const string Torcon = "Torcon";
        const string TornadoFlame = "Tornado Flame";
        const string TriHornShepherd = "Tri-Horn Shepherd";
        const string TwinCannonSkyterror = "Twin-Cannon Skyterror";

        const string ValkyerStarstormElemental = "Valkyer, Starstorm Elemental";
        const string VessTheOracle = "Vess, the Oracle";
        const string VolcanoCharger = "Volcano Charger";

        const string WanderingBraineater = "Wandering Braineater";
        const string WindAxeTheWarriorSavage = "Wind Axe, the Warrior Savage";
        const string WindmillMutant = "Windmill Mutant";

        const string Zepimeteus = "Zepimeteus";
        #endregion Card names

        static readonly private Dictionary<string, Func<Card>> _cards = new()
        {
            { AquaBouncer, () => CreateAquaBouncer() },
            { AquaHulcus, () => CreateAquaHulcus() },
            { AquaShooter, () => CreateAquaShooter() },
            { AquaSurfer, () => CreateAquaSurfer() },

            { BalzaSeekerOfHyperpearls, () => CreateBalzaSeekerOfHyperpearls() },
            { BatteryCluster, () => CreateBatteryCluster() },
            { BlizzardOfSpears, () => CreateBlizzardOfSpears() },
            { BombazarDragonOfDestiny, () => CreateBombazarDragonOfDestiny() },
            { BronzeArmTribe, () => CreateBronzeArmTribe() },
            { BurningMane, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = BurningMane, Power = 2000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { BurstShot, () => CreateBurstShot() },

            { Corile, () => CreateCorile() },
            { CraniumClamp, () => CreateCraniumClamp() },
            { CrimsonHammer, () => CreateCrimsonHammer() },

            { DarkRavenShadowOfGrief, () => CreateDarkRavenShadowOfGrief() },
            { DeadlyFighterBraidClaw, () => CreateDeadlyFighterBraidClaw() },
            { DiaNorkMoonlightGuardian, () => CreateDiaNorkMoonlightGuardian() },

            { Emeral, () => CreateEmeral() },
            { EmeraldGrass, () => CreateEmeraldGrass() },
            { EngbeltTheSpydroid, () => CreateEngbeltTheSpydroid() },
            { ExplosiveDudeJoe, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = ExplosiveDudeJoe, Power = 3000, Subtypes = new List<Subtype> { Subtype.Human } } },

            { FantasyFish, () => CreateFantasyFish() },
            { FearFang, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = FearFang, Power = 3000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { FerrosaturnSpectralKnight, () => CreateFerrosaturnSpectralKnight() },

            { GhostTouch, () => CreateGhostTouch() },
            { Gigabalza, () => CreateGigabalza() },
            { GontaTheWarriorSavage, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 2, Name = GontaTheWarriorSavage, Power = 4000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } } },
            { GranGureSpaceGuardian, () => CreateGranGureSpaceGuardian() },
            { GrayBalloonShadowOfGreed, () => CreateGrayBalloonShadowOfGreed() },

            { HazardCrawler, () => CreateHazardCrawler() },
            { HeartyCapnPolligon, () => CreateHeartyCapnPolligon() },
            { HolyAwe, () => CreateHolyAwe() },
            { HorridWorm, () => CreateHorridWorm() },
            { HunterCluster, () => CreateHunterCluster() },
            { HunterFish, () => CreateHunterFish() },

            { ImmortalBaronVorg, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = ImmortalBaronVorg, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human } } },
            
            { KamikazeChainsawWarrior, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = KamikazeChainsawWarrior, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Armorloid } } },
            { KanesillTheExplorer, () => CreateKanesillTheExplorer() },
            { KingCoral, () => CreateKingCoral() },

            { LaUraGigaSkyGuardian, () => CreateLaUraGigaSkyGuardian() },
            { Locomotiver, () => CreateLocomotiver() },

            { MadrillonFish, () => CreateMadrillonFish() },
            { Magmarex, () => CreateMagmarex() },
            { MagrisVizierOfMagnetism, () => CreateMagrisVizierOfMagnetism() },
            { MarineFlower, () => CreateMarineFlower() },
            { MelodicHunter, () => CreateMelodicHunter() },
            { MikayRattlingDoll, () => CreateMikayRattlingDoll() },
            { MistRiasSonicGuardian, () => CreateMistRiasSonicGuardian() },

            { NaturalSnare, () => CreateNaturalSnare() },
            { NightMasterShadowOfDecay, () => CreateNightMasterShadowOfDecay() },

            { PalaOlesisMorningGuardian, () => CreatePalaOlesisMorningGuardian() },
            { PhantomDragonsFlame, () => CreatePhantomDragonsFlame() },
            { PhantomFish, () => CreatePhantomFish() },
            { PoltalesterTheSpydroid, () => CreatePoltalesterTheSpydroid() },
            { ProwlingElephish, () => CreateProwlingElephish() },
            { PyrofighterMagnus, () => CreatePyrofighterMagnus() },

            { QuixoticHeroSwineSnout, () => CreateQuixoticHeroSwineSnout() },

            { RevolverFish, () => CreateRevolverFish() },
            { RikabuTheDismantler, () => CreateRikabuTheDismantler() },

            { SariusVizierOfSuppression, () => CreateSariusVizierOfSuppression() },
            { Seamine, () => CreateSeamine() },
            { SenatineJadeTree, () => CreateSenatineJadeTree() },
            { SniperMosquito, () => CreateSniperMosquito() },
            { Soulswap, () => CreateSoulswap() },
            { SpasticMissile, () => CreateSpasticMissile() },
            { SupersonicJetPack, () => CreateSupersonicJetPack() },
            { SzubsKinTwilightGuardian, () => CreateSzubsKinTwilightGuardian() },

            { TenTonCrunch, () => CreateTenTonCrunch() },
            { TerrorPit, () => CreateTerrorPit() },
            { TidePatroller, () => CreateTidePatroller() },
            { Torcon, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = Torcon, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TornadoFlame, () => CreateTornadoFlame() },
            { TriHornShepherd, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 5, Name = TriHornShepherd, Power = 5000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TwinCannonSkyterror, () => CreateTwinCannonSkyterror() },

            { ValkyerStarstormElemental, () => CreateValkyerStarstormElemental() },
            { VessTheOracle, () => CreateVessTheOracle() },
            { VolcanoCharger, () => CreateVolcanoCharger() },

            { WanderingBraineater, () => CreateWanderingBraineater() },
            { WindAxeTheWarriorSavage, () => CreateWindAxeTheWarriorSavage() },
            { WindmillMutant, () => CreateWindmillMutant() },

            { Zepimeteus, () => CreateZepimeteus() },
        };

        static Card CreateAquaBouncer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = AquaBouncer, Power = 1000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable()));
            return x;
        }

        static Card CreateAquaHulcus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = AquaHulcus, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateAquaShooter()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 4, Name = AquaShooter, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateAquaSurfer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = AquaSurfer, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable()));
            return x;
        }

        static Card CreateBalzaSeekerOfHyperpearls()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 8, Name = BalzaSeekerOfHyperpearls, Power = 4000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.MechaThunder } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateBatteryCluster()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = BatteryCluster, Power = 3000, Subtypes = new List<Subtype> { Subtype.CyberCluster } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateBlizzardOfSpears()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 6, Name = BlizzardOfSpears };
            x.Abilities.Add(new SpellAbility(new DestroyCreaturesResolvable(new CreaturesWithMaxPowerFilter(4000))));
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

        static Card CreateBurstShot()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 6, Name = BurstShot, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new DestroyCreaturesResolvable(new CreaturesWithMaxPowerFilter(2000))));
            return x;
        }

        static Card CreateCorile()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 5, Name = Corile, Power = 2000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileResolvable()));
            return x;
        }

        static Card CreateCraniumClamp()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = CraniumClamp };
            x.Abilities.Add(new SpellAbility(new CraniumClampResolvable()));
            return x;
        }

        static Card CreateCrimsonHammer()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = CrimsonHammer };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(2000))));
            return x;
        }

        static Card CreateDarkRavenShadowOfGrief()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = DarkRavenShadowOfGrief, Power = 1000, Subtypes = new List<Subtype> { Subtype.Ghost } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateDeadlyFighterBraidClaw()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = DeadlyFighterBraidClaw, Power = 1000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new AttacksIfAbleAbility());
            return x;
        }

        static Card CreateDiaNorkMoonlightGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 4, Name = DiaNorkMoonlightGuardian, Power = 5000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateEmeral()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = Emeral, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EmeralResolvable()));
            return x;
        }

        static Card CreateEmeraldGrass()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 2, Name = EmeraldGrass, Power = 3000, Subtypes = new List<Subtype> { Subtype.StarlightTree } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateEngbeltTheSpydroid()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 4, Name = EngbeltTheSpydroid, Power = 5500, Subtypes = new List<Subtype> { Subtype.Soltrooper } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateFantasyFish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 7, Name = FantasyFish, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.GelFish } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateFerrosaturnSpectralKnight()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 1, Name = FerrosaturnSpectralKnight, Power = 2000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateGhostTouch()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 2, Name = GhostTouch, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateGigabalza()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = Gigabalza, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Chimera } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateGrayBalloonShadowOfGreed()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 3, Name = GrayBalloonShadowOfGreed, Power = 3000, Subtypes = new List<Subtype> { Subtype.Ghost } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateGranGureSpaceGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 6, Name = GranGureSpaceGuardian, Power = 9000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateHazardCrawler()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 5, Name = HazardCrawler, Power = 6000, Subtypes = new List<Subtype> { Subtype.EarthEater } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateHeartyCapnPolligon()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = HeartyCapnPolligon, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
            x.Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonResolvable()));
            return x;
        }

        static Card CreateHolyAwe()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 6, Name = HolyAwe, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new HolyAweResolvable()));
            return x;
        }

        static Card CreateHorridWorm()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 3, Name = HorridWorm, Power = 2000, Subtypes = new List<Subtype> { Subtype.ParasiteWorm } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateHunterCluster()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 4, Name = HunterCluster, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.CyberCluster } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateHunterFish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = HunterFish, Power = 3000, Subtypes = new List<Subtype> { Subtype.Fish } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateKanesillTheExplorer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 3, Name = KanesillTheExplorer, Power = 4000, Subtypes = new List<Subtype> { Subtype.Gladiator } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateKingCoral()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = KingCoral, Power = 1000, Subtypes = new List<Subtype> { Subtype.Leviathan } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateLaUraGigaSkyGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 1, Name = LaUraGigaSkyGuardian, Power = 2000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateLocomotiver()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = Locomotiver, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Hedrian } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateMadrillonFish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = MadrillonFish, Power = 3000, Subtypes = new List<Subtype> { Subtype.GelFish } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateMagmarex()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 5, Name = Magmarex, Power = 3000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.RockBeast } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesResolvable(new CreaturesWithPowerFilter(1000))));
            return x;
        }

        static Card CreateMagrisVizierOfMagnetism()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 4, Name = MagrisVizierOfMagnetism, Power = 3000, Subtypes = new List<Subtype> { Subtype.Initiate } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateMarineFlower()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 1, Name = MarineFlower, Power = 2000, Subtypes = new List<Subtype> { Subtype.CyberVirus } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateMelodicHunter()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 5, Name = MelodicHunter, Power = 3000, Subtypes = new List<Subtype> { Subtype.Merfolk } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateMikayRattlingDoll()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 2, Name = MikayRattlingDoll, Power = 2000, Subtypes = new List<Subtype> { Subtype.DeathPuppet } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateMistRiasSonicGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 5, Name = MistRiasSonicGuardian, Power = 2000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateNaturalSnare()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 6, Name = NaturalSnare, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new NaturalSnareResolvable()));
            return x;
        }

        static Card CreateNightMasterShadowOfDecay()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 6, Name = NightMasterShadowOfDecay, Power = 3000, Subtypes = new List<Subtype> { Subtype.Ghost } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateQuixoticHeroSwineSnout()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = QuixoticHeroSwineSnout, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new QuixoticHeroSwineSnoutResolvable()));
            return x;
        }

        static Card CreatePalaOlesisMorningGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 3, Name = PalaOlesisMorningGuardian, Power = 2500, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new PalaOlesisAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreatePhantomDragonsFlame()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = PhantomDragonsFlame, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(2000))));
            return x;
        }

        static Card CreatePhantomFish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = PhantomFish, Power = 4000, Subtypes = new List<Subtype> { Subtype.GelFish } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreatePoltalesterTheSpydroid()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 5, Name = PoltalesterTheSpydroid, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Soltrooper } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateProwlingElephish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 4, Name = ProwlingElephish, Power = 2000, Subtypes = new List<Subtype> { Subtype.GelFish } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreatePyrofighterMagnus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = PyrofighterMagnus, Power = 3000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new AtTheEndOfYourTurnAbility(new PyrofighterMagnusResolvable()));
            return x;
        }

        static Card CreateRevolverFish()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 4, Name = RevolverFish, Power = 5000, Subtypes = new List<Subtype> { Subtype.GelFish } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateRikabuTheDismantler()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = RikabuTheDismantler, Power = 1000, Subtypes = new List<Subtype> { Subtype.MachineEater } };
            x.Abilities.Add(new SpeedAttackerAbility());
            return x;
        }

        static Card CreateSariusVizierOfSuppression()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 2, Name = SariusVizierOfSuppression, Power = 3000, Subtypes = new List<Subtype> { Subtype.Initiate } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateSeamine()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = Seamine, Power = 4000, Subtypes = new List<Subtype> { Subtype.Fish } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateSenatineJadeTree()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 3, Name = SenatineJadeTree, Power = 4000, Subtypes = new List<Subtype> { Subtype.StarlightTree } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
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
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = Soulswap, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new SoulswapResolvable()));
            return x;
        }

        static Card CreateSpasticMissile()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = SpasticMissile };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(3000))));
            return x;
        }

        static Card CreateSupersonicJetPack()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = SupersonicJetPack };
            x.Abilities.Add(new SpellAbility(new SupersonicJetPackResolvable()));
            return x;
        }

        static Card CreateSzubsKinTwilightGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 5, Name = SzubsKinTwilightGuardian, Power = 6000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateTenTonCrunch()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 4, Name = TenTonCrunch, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(3000))));
            return x;
        }

        static Card CreateTerrorPit()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 6, Name = TerrorPit, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new AnyFilter())));
            return x;
        }

        static Card CreateTidePatroller()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 4, Name = TidePatroller, Power = 2000, Subtypes = new List<Subtype> { Subtype.Merfolk } };
            x.Abilities.Add(new BlockerAbility());
            return x;
        }

        static Card CreateTornadoFlame()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 5, Name = TornadoFlame, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(4000))));
            return x;
        }

        static Card CreateTwinCannonSkyterror()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = TwinCannonSkyterror, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new DoubleBreakerAbility());
            return x;
        }

        static Card CreateValkyerStarstormElemental()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 5, Name = ValkyerStarstormElemental, Power = 7000, Subtypes = new List<Subtype> { Subtype.AngelCommand } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateVessTheOracle()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 1, Name = VessTheOracle, Power = 2000, Subtypes = new List<Subtype> { Subtype.LightBringer } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateVolcanoCharger()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = VolcanoCharger };
            x.Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(2000))));
            x.Abilities.Add(new ChargerAbility());
            return x;
        }

        static Card CreateWanderingBraineater()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 2, Name = WanderingBraineater, Power = 2000, Subtypes = new List<Subtype> { Subtype.LivingDead } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }

        static Card CreateWindAxeTheWarriorSavage()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = WindAxeTheWarriorSavage, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageResolvable()));
            return x;
        }

        static Card CreateWindmillMutant()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 3, Name = WindmillMutant, Power = 2000, Subtypes = new List<Subtype> { Subtype.Hedrian } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateZepimeteus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 1, Name = Zepimeteus, Power = 2000, Subtypes = new List<Subtype> { Subtype.SeaHacker } };
            x.Abilities.Add(new BlockerAbility());
            x.Abilities.Add(new CannotAttackCreaturesAbility());
            x.Abilities.Add(new CannotAttackPlayersAbility());
            return x;
        }
    }
}
