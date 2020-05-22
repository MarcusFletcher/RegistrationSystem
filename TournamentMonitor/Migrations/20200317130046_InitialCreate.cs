using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentMonitor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Sacntionable = table.Column<bool>(nullable: false),
                    PointsValue = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    FormatID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatID);
                });

            migrationBuilder.CreateTable(
                name: "IDBankRecords",
                columns: table => new
                {
                    IDBankKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerID = table.Column<int>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    TimeUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDBankRecords", x => x.IDBankKey);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TPCLeagueId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    OrganiserID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisers", x => x.OrganiserID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRecords",
                columns: table => new
                {
                    PlayerKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<int>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRecords", x => x.PlayerKey);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Password2 = table.Column<string>(nullable: true),
                    Password3 = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationStatuses",
                columns: table => new
                {
                    StatusID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTypes",
                columns: table => new
                {
                    TournamentTypeID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTypes", x => x.TournamentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryID = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                    table.ForeignKey(
                        name: "FK_Venues_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events1",
                columns: table => new
                {
                    EventId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Banner = table.Column<byte[]>(nullable: true),
                    LeagueId = table.Column<long>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    OrganiserID = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events1", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events1_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events1_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    GameTypeId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    LeagueId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.GameTypeId);
                    table.ForeignKey(
                        name: "FK_GameTypes_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitorRecords",
                columns: table => new
                {
                    CompetitorKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    OpponentsWin = table.Column<float>(nullable: false),
                    OpponentsOpponentsWin = table.Column<float>(nullable: false),
                    PlayerKey = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitorRecords", x => x.CompetitorKey);
                    table.ForeignKey(
                        name: "FK_CompetitorRecords_PlayerRecords_PlayerKey",
                        column: x => x.PlayerKey,
                        principalTable: "PlayerRecords",
                        principalColumn: "PlayerKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries1",
                columns: table => new
                {
                    CountryId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    RegionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries1", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries1_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventID = table.Column<long>(nullable: false),
                    OrganiserID = table.Column<long>(nullable: true),
                    VenueID = table.Column<long>(nullable: true),
                    ProductID = table.Column<long>(nullable: true),
                    TournamentTypeID = table.Column<long>(nullable: true),
                    FormatID = table.Column<long>(nullable: true),
                    TournamentName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SanctionID = table.Column<int>(nullable: false),
                    RegistrationRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_Tournaments_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_Formats_FormatID",
                        column: x => x.FormatID,
                        principalTable: "Formats",
                        principalColumn: "FormatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_Organisers_OrganiserID",
                        column: x => x.OrganiserID,
                        principalTable: "Organisers",
                        principalColumn: "OrganiserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentTypes_TournamentTypeID",
                        column: x => x.TournamentTypeID,
                        principalTable: "TournamentTypes",
                        principalColumn: "TournamentTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tournaments_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentRecords",
                columns: table => new
                {
                    TournamentKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    OrganiserID = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    Event1EventId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentRecords", x => x.TournamentKey);
                    table.ForeignKey(
                        name: "FK_TournamentRecords_Events1_Event1EventId",
                        column: x => x.Event1EventId,
                        principalTable: "Events1",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameFormats",
                columns: table => new
                {
                    GameFormatId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    GameTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFormats", x => x.GameFormatId);
                    table.ForeignKey(
                        name: "FK_GameFormats_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "GameTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Provence = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    LeagueId = table.Column<long>(nullable: true),
                    PlayerKey = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries1_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries1",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_PlayerRecords_PlayerKey",
                        column: x => x.PlayerKey,
                        principalTable: "PlayerRecords",
                        principalColumn: "PlayerKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionDetails",
                columns: table => new
                {
                    DivisionID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentID = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    TotalRegistered = table.Column<int>(nullable: false),
                    EntryCost = table.Column<float>(type: "money", nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    SwissMatchPoints = table.Column<int>(nullable: false),
                    SwissRoundTime = table.Column<TimeSpan>(nullable: false),
                    EliminationMatchPoints = table.Column<int>(nullable: false),
                    EliminationRoundTime = table.Column<TimeSpan>(nullable: false),
                    RegistrationOpen = table.Column<DateTime>(nullable: false),
                    RegistrationClosed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionDetails", x => x.DivisionID);
                    table.ForeignKey(
                        name: "FK_DivisionDetails_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentRegistrations",
                columns: table => new
                {
                    TournamentID = table.Column<long>(nullable: false),
                    PlayerID = table.Column<long>(nullable: false),
                    RegistrationStatusStatusID = table.Column<long>(nullable: true),
                    PaidAmount = table.Column<float>(type: "money", nullable: false),
                    Division = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentRegistrations", x => new { x.TournamentID, x.PlayerID });
                    table.ForeignKey(
                        name: "FK_TournamentRegistrations_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentRegistrations_RegistrationStatuses_RegistrationStatusStatusID",
                        column: x => x.RegistrationStatusStatusID,
                        principalTable: "RegistrationStatuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentRegistrations_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTournaments",
                columns: table => new
                {
                    PlayerTournamentsKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerKey = table.Column<long>(nullable: true),
                    CompetitorRecordCompetitorKey = table.Column<long>(nullable: true),
                    TournamentKey = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournaments", x => x.PlayerTournamentsKey);
                    table.ForeignKey(
                        name: "FK_PlayerTournaments_CompetitorRecords_CompetitorRecordCompetitorKey",
                        column: x => x.CompetitorRecordCompetitorKey,
                        principalTable: "CompetitorRecords",
                        principalColumn: "CompetitorKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerTournaments_PlayerRecords_PlayerKey",
                        column: x => x.PlayerKey,
                        principalTable: "PlayerRecords",
                        principalColumn: "PlayerKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerTournaments_TournamentRecords_TournamentKey",
                        column: x => x.TournamentKey,
                        principalTable: "TournamentRecords",
                        principalColumn: "TournamentKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PodRecords",
                columns: table => new
                {
                    PodKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentKey = table.Column<long>(nullable: false),
                    DivisionName = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodRecords", x => x.PodKey);
                    table.ForeignKey(
                        name: "FK_PodRecords_TournamentRecords_TournamentKey",
                        column: x => x.TournamentKey,
                        principalTable: "TournamentRecords",
                        principalColumn: "TournamentKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandingRecords",
                columns: table => new
                {
                    StandingKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitorKey = table.Column<long>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Place = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    TournamentKey = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingRecords", x => x.StandingKey);
                    table.ForeignKey(
                        name: "FK_StandingRecords_CompetitorRecords_CompetitorKey",
                        column: x => x.CompetitorKey,
                        principalTable: "CompetitorRecords",
                        principalColumn: "CompetitorKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StandingRecords_TournamentRecords_TournamentKey",
                        column: x => x.TournamentKey,
                        principalTable: "TournamentRecords",
                        principalColumn: "TournamentKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundRecords",
                columns: table => new
                {
                    RoundKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PodKey = table.Column<long>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Stage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundRecords", x => x.RoundKey);
                    table.ForeignKey(
                        name: "FK_RoundRecords_PodRecords_PodKey",
                        column: x => x.PodKey,
                        principalTable: "PodRecords",
                        principalColumn: "PodKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchRecords",
                columns: table => new
                {
                    MatchKey = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundKey = table.Column<long>(nullable: false),
                    MatchOutcome = table.Column<int>(nullable: false),
                    Player1CompetitorKey = table.Column<long>(nullable: true),
                    CompetitorKey1 = table.Column<long>(nullable: false),
                    Player2CompetitorKey = table.Column<long>(nullable: true),
                    CompetitorKey2 = table.Column<long>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    TableNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRecords", x => x.MatchKey);
                    table.ForeignKey(
                        name: "FK_MatchRecords_CompetitorRecords_Player1CompetitorKey",
                        column: x => x.Player1CompetitorKey,
                        principalTable: "CompetitorRecords",
                        principalColumn: "CompetitorKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchRecords_CompetitorRecords_Player2CompetitorKey",
                        column: x => x.Player2CompetitorKey,
                        principalTable: "CompetitorRecords",
                        principalColumn: "CompetitorKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchRecords_RoundRecords_RoundKey",
                        column: x => x.RoundKey,
                        principalTable: "RoundRecords",
                        principalColumn: "RoundKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LeagueId",
                table: "Addresses",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PlayerKey",
                table: "Addresses",
                column: "PlayerKey");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitorRecords_PlayerKey",
                table: "CompetitorRecords",
                column: "PlayerKey");

            migrationBuilder.CreateIndex(
                name: "IX_Countries1_RegionId",
                table: "Countries1",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionDetails_TournamentID",
                table: "DivisionDetails",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Events1_EventTypeId",
                table: "Events1",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events1_LeagueId",
                table: "Events1",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFormats_GameTypeId",
                table: "GameFormats",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_LeagueId",
                table: "GameTypes",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_Player1CompetitorKey",
                table: "MatchRecords",
                column: "Player1CompetitorKey");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_Player2CompetitorKey",
                table: "MatchRecords",
                column: "Player2CompetitorKey");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRecords_RoundKey",
                table: "MatchRecords",
                column: "RoundKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournaments_CompetitorRecordCompetitorKey",
                table: "PlayerTournaments",
                column: "CompetitorRecordCompetitorKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournaments_PlayerKey",
                table: "PlayerTournaments",
                column: "PlayerKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournaments_TournamentKey",
                table: "PlayerTournaments",
                column: "TournamentKey");

            migrationBuilder.CreateIndex(
                name: "IX_PodRecords_TournamentKey",
                table: "PodRecords",
                column: "TournamentKey");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRecords_PodKey",
                table: "RoundRecords",
                column: "PodKey");

            migrationBuilder.CreateIndex(
                name: "IX_StandingRecords_CompetitorKey",
                table: "StandingRecords",
                column: "CompetitorKey");

            migrationBuilder.CreateIndex(
                name: "IX_StandingRecords_TournamentKey",
                table: "StandingRecords",
                column: "TournamentKey");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentRecords_Event1EventId",
                table: "TournamentRecords",
                column: "Event1EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentRegistrations_PlayerID",
                table: "TournamentRegistrations",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentRegistrations_RegistrationStatusStatusID",
                table: "TournamentRegistrations",
                column: "RegistrationStatusStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_EventID",
                table: "Tournaments",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_FormatID",
                table: "Tournaments",
                column: "FormatID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_OrganiserID",
                table: "Tournaments",
                column: "OrganiserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_ProductID",
                table: "Tournaments",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentTypeID",
                table: "Tournaments",
                column: "TournamentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_VenueID",
                table: "Tournaments",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_CountryID",
                table: "Venues",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "DivisionDetails");

            migrationBuilder.DropTable(
                name: "GameFormats");

            migrationBuilder.DropTable(
                name: "IDBankRecords");

            migrationBuilder.DropTable(
                name: "MatchRecords");

            migrationBuilder.DropTable(
                name: "PlayerTournaments");

            migrationBuilder.DropTable(
                name: "StandingRecords");

            migrationBuilder.DropTable(
                name: "TournamentRegistrations");

            migrationBuilder.DropTable(
                name: "Countries1");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "RoundRecords");

            migrationBuilder.DropTable(
                name: "CompetitorRecords");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "RegistrationStatuses");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "PodRecords");

            migrationBuilder.DropTable(
                name: "PlayerRecords");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Organisers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TournamentTypes");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "TournamentRecords");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Events1");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
