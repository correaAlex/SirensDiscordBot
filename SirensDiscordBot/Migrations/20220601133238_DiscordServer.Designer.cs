// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SirensDiscordBot;

#nullable disable

namespace SirensDiscordBot.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220601133238_DiscordServer")]
    partial class DiscordServer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SirensDiscordBot.Models.DiscordServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("ChanelGuid")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("DiscordGuid")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RolesSerialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DiscordServers");
                });
#pragma warning restore 612, 618
        }
    }
}
