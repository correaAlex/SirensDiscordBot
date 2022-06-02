using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SirensDiscordBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirensDiscordBot.Commands
{
    public class StartModule : BaseCommandModule
    {
        private readonly DiscordEmoji GreateBritainEmoji = DiscordEmoji.FromUnicode("🇬🇧");
        private readonly DiscordEmoji UkraineEmoji = DiscordEmoji.FromUnicode("🇺🇦");
        private readonly DiscordEmoji RussianEmoji = DiscordEmoji.FromUnicode("🇷🇺");

        public delegate void SelectLanguagesDelegate();
        public static event SelectLanguagesDelegate SelectLanguages;

        [Command("start")]
        public async Task StartCommnad(CommandContext command)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                DiscordServer discordServer = await context.DiscordServers.Where(e => e.DiscordGuid == command.Guild.Id).SingleOrDefaultAsync();
                if (discordServer != null)
                {
                    if (discordServer.ChanelGuid != command.Channel.Id)
                    {
                        discordServer.ChanelGuid = command.Channel.Id;
                        context.Entry(discordServer).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        await command.Channel.SendMessageAsync(BotLocalication.GetMessage(discordServer.Language, "updateChanel"));
                    }
                    else
                        await command.Channel.SendMessageAsync(BotLocalication.GetMessage(discordServer.Language, "alreadyUse"));
                }
                else 
                {
                    var message = await command.Channel.SendMessageAsync("Please select leanguage!");
                    await message.CreateReactionAsync(GreateBritainEmoji);
                    await message.CreateReactionAsync(UkraineEmoji);
                    await message.CreateReactionAsync(RussianEmoji);
                    var response = await message.WaitForReactionAsync(command.Member);
                    if (!response.TimedOut)
                    {
                        DiscordServer newServer = new DiscordServer() { DiscordGuid = command.Guild.Id, ChanelGuid = command.Channel.Id };
                        if (response.Result.Emoji == GreateBritainEmoji)
                            newServer.Language = "en";
                        else if (response.Result.Emoji == UkraineEmoji)
                            newServer.Language = "ua";
                        else if (response.Result.Emoji == RussianEmoji)
                            newServer.Language = "ru";

                        Dictionary<string, ulong> roles = new Dictionary<string, ulong>();
                        try 
                        {
                            var districts = BotLocalication.GetDistricts(newServer.Language);
                            foreach (var district in districts)
                            {
                                var role = await command.Guild.CreateRoleAsync(district.Value);
                                roles.Add(role.Name, role.Id);
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            await command.Channel.SendMessageAsync(ex.Message);
                        }
                        newServer.Roles = roles;                   
                        await context.DiscordServers.AddAsync(newServer);
                        await context.SaveChangesAsync();
                        await command.Channel.SendMessageAsync(BotLocalication.GetMessage(newServer.Language, "greetings"));
                    }
                }
            }
        }

        [Command("stop")]
        public async Task StopCommand(CommandContext command)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                DiscordServer discordServer = await context.DiscordServers.Where(e => e.DiscordGuid == command.Guild.Id).SingleOrDefaultAsync();
                if (discordServer != null)
                {
                    context.DiscordServers.Remove(discordServer);
                    await context.SaveChangesAsync();
                    await command.Channel.SendMessageAsync(BotLocalication.GetMessage(discordServer.Language, "stopBot"));
                }
            }
        }
    } 
}