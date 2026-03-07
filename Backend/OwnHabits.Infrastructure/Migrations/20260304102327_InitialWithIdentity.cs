using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OwnHabits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId1",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId1",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Goals_GoalId",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Goals_GoalId1",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Users_UserId",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Users_UserId1",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Skills_SkillId",
                table: "UserToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Skills_SkillId1",
                table: "UserToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Users_UserId",
                table: "UserToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Users_UserId1",
                table: "UserToSkills");

            migrationBuilder.DropTable(
                name: "UserToRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserToSkills_SkillId1",
                table: "UserToSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserToSkills_UserId1",
                table: "UserToSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserToGoals_GoalId1",
                table: "UserToGoals");

            migrationBuilder.DropIndex(
                name: "IX_UserToGoals_UserId1",
                table: "UserToGoals");

            migrationBuilder.DropIndex(
                name: "IX_UserToCharacteristics_CharacteristicId1",
                table: "UserToCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_UserToCharacteristics_UserId1",
                table: "UserToCharacteristics");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "UserToSkills");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserToSkills");

            migrationBuilder.DropColumn(
                name: "GoalId1",
                table: "UserToGoals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserToGoals");

            migrationBuilder.DropColumn(
                name: "CharacteristicId1",
                table: "UserToCharacteristics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserToCharacteristics");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    RoleId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId1",
                table: "AspNetRoleClaims",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserId1",
                table: "AspNetUserTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId",
                table: "UserToCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId",
                table: "UserToCharacteristics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Goals_GoalId",
                table: "UserToGoals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Users_UserId",
                table: "UserToGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Skills_SkillId",
                table: "UserToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Users_UserId",
                table: "UserToSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId",
                table: "UserToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Goals_GoalId",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGoals_Users_UserId",
                table: "UserToGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Skills_SkillId",
                table: "UserToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToSkills_Users_UserId",
                table: "UserToSkills");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId1",
                table: "UserToSkills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserToSkills",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GoalId1",
                table: "UserToGoals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserToGoals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CharacteristicId1",
                table: "UserToCharacteristics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserToCharacteristics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserToRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserToRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToSkills_SkillId1",
                table: "UserToSkills",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToSkills_UserId1",
                table: "UserToSkills",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGoals_GoalId1",
                table: "UserToGoals",
                column: "GoalId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGoals_UserId1",
                table: "UserToGoals",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToCharacteristics_CharacteristicId1",
                table: "UserToCharacteristics",
                column: "CharacteristicId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToCharacteristics_UserId1",
                table: "UserToCharacteristics",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_RoleId",
                table: "UserToRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId",
                table: "UserToCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Characteristics_CharacteristicId1",
                table: "UserToCharacteristics",
                column: "CharacteristicId1",
                principalTable: "Characteristics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId",
                table: "UserToCharacteristics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToCharacteristics_Users_UserId1",
                table: "UserToCharacteristics",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Goals_GoalId",
                table: "UserToGoals",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Goals_GoalId1",
                table: "UserToGoals",
                column: "GoalId1",
                principalTable: "Goals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Users_UserId",
                table: "UserToGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGoals_Users_UserId1",
                table: "UserToGoals",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Skills_SkillId",
                table: "UserToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Skills_SkillId1",
                table: "UserToSkills",
                column: "SkillId1",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Users_UserId",
                table: "UserToSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToSkills_Users_UserId1",
                table: "UserToSkills",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
