using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnHabits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalsToSkills_Goals_GoalId",
                table: "GoalsToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalsToSkills_Skills_SkillId",
                table: "GoalsToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillToCharacteristics_Characteristics_CharacteristicId",
                table: "SkillToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillToCharacteristics_Skills_SkillId",
                table: "SkillToCharacteristics");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToRoles",
                table: "UserToRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserToRoles_UserId",
                table: "UserToRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserToRoles");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

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
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToRoles",
                table: "UserToRoles",
                columns: new[] { "UserId", "RoleId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsToSkills_Goals_GoalId",
                table: "GoalsToSkills",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsToSkills_Skills_SkillId",
                table: "GoalsToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillToCharacteristics_Characteristics_CharacteristicId",
                table: "SkillToCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillToCharacteristics_Skills_SkillId",
                table: "SkillToCharacteristics",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalsToSkills_Goals_GoalId",
                table: "GoalsToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalsToSkills_Skills_SkillId",
                table: "GoalsToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillToCharacteristics_Characteristics_CharacteristicId",
                table: "SkillToCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillToCharacteristics_Skills_SkillId",
                table: "SkillToCharacteristics");

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

            migrationBuilder.DropIndex(
                name: "IX_UserToSkills_SkillId1",
                table: "UserToSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserToSkills_UserId1",
                table: "UserToSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToRoles",
                table: "UserToRoles");

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

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserToRoles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToRoles",
                table: "UserToRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_UserId",
                table: "UserToRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsToSkills_Goals_GoalId",
                table: "GoalsToSkills",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalsToSkills_Skills_SkillId",
                table: "GoalsToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillToCharacteristics_Characteristics_CharacteristicId",
                table: "SkillToCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillToCharacteristics_Skills_SkillId",
                table: "SkillToCharacteristics",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
