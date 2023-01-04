using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_JobRequirementId",
                table: "Submissions",
                column: "JobRequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_JobRequirements_JobRequirementId",
                table: "Submissions",
                column: "JobRequirementId",
                principalTable: "JobRequirements",
                principalColumn: "JobRequirementId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_JobRequirements_JobRequirementId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_JobRequirementId",
                table: "Submissions");
        }
    }
}
