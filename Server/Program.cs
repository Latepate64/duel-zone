using System.Xml.Serialization;
using Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Interfaces;
using Engine;

const string path = @"..\..\..\cards.xml";
var serializer = new XmlSerializer(typeof(Cards));
using Stream reader = new FileStream(path, FileMode.Open);
var cards = serializer.Deserialize(reader);

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IEventResolver<ChooseAndMoveCardsEffect, IGameEvent>, ChooseAndMoveCardsEffectResolver>();
builder.Services.AddSingleton<IEventResolver<MoveCardEvent, IGameEvent>, MoveCardEventResolver>();
builder.Services.AddSingleton<IEventResolver<TapCardEvent, IGameEvent>, TapCardEventResolver>();
builder.Services.AddSingleton<IEventResolver<TapAllYourOpponentsCreaturesEffect, IGameEvent>, TapAllYourOpponentsCreaturesEffectResolver>();
using IHost host = builder.Build();
var game = new Game(host.Services);

Console.WriteLine("Hello world!");