
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SirensDiscordBot;
using SirensDiscordBot.Commands;
using SirensDiscordBot.Models;
using System.Configuration;
using System.Net;
using System.Text.Json;

namespace SirensBot
{
    public class Program
    {
        private static Bot _bot;
        private static DiscordClient _discord;
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            try
            {
                await BotLocalication.LoadLanguages();
                _bot = new Bot();
                _bot.Alarm += OnAllarm;
                _bot.PartialAlarm += OnPartialAlarm;
                _bot.CancelAlarm += OnCanledAlarm;
                _discord = new DiscordClient(new DiscordConfiguration()
                {
                    Token = ConfigurationManager.AppSettings.Get("Token"),
                    TokenType = TokenType.Bot
                });
                _discord.UseInteractivity(new InteractivityConfiguration()
                {
                    PollBehaviour = PollBehaviour.KeepEmojis,
                    Timeout = TimeSpan.FromSeconds(30)
                }); 
                var commands = _discord.UseCommandsNext(new CommandsNextConfiguration()
                {
                    StringPrefixes = new[] { "!" }
                });
                commands.RegisterCommands<StartModule>();
                await _discord.ConnectAsync();
                _bot.Start();
                await Task.Delay(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static async void OnAllarm(string message)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var servers = await context.DiscordServers.ToListAsync();
                foreach (var server in servers)
                {
                    var discordServer = await _discord.GetGuildAsync(server.DiscordGuid);
                    var chanel = discordServer.GetChannel(server.ChanelGuid);
                    ulong roleId;
                    if (server.Roles.TryGetValue(message, out roleId))
                    {
                        await chanel.SendMessageAsync(String.Format("<@&{0}> {1}", roleId, BotLocalication.GetMessage(server.Language, "entireRegion")));
                    }
                }
            }
        }

        private static async void OnPartialAlarm(string message)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var servers = await context.DiscordServers.ToListAsync();
                foreach (var server in servers)
                {
                    var discordServer = await _discord.GetGuildAsync(server.DiscordGuid);
                    var chanel = discordServer.GetChannel(server.ChanelGuid);
                    ulong roleId;
                    if (server.Roles.TryGetValue(message, out roleId))
                    {
                        await chanel.SendMessageAsync(String.Format("<@&{0}> {1}", roleId, BotLocalication.GetMessage(server.Language, "partOfRegion")));
                    }
                }
            }
        }

        private static async void OnCanledAlarm(string message)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var servers = await context.DiscordServers.ToListAsync();
                foreach (var server in servers)
                {
                    var discordServer = await _discord.GetGuildAsync(server.DiscordGuid);
                    var chanel = discordServer.GetChannel(server.ChanelGuid);
                    ulong roleId;
                    if (server.Roles.TryGetValue(message, out roleId))
                    {
                        await chanel.SendMessageAsync(String.Format("<@&{0}> {1}", roleId, BotLocalication.GetMessage(server.Language, "noSiren")));
                    }
                }
            }
               
        }

    }

}