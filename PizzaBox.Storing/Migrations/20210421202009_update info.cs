using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class updateinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizza_Crust_CrustEntityId",
                table: "APizza");

            migrationBuilder.DropForeignKey(
                name: "FK_APizza_Size_SizeEntityId",
                table: "APizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_APizza_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_APizza_APizzaEntityId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APizza",
                table: "APizza");

            migrationBuilder.RenameTable(
                name: "APizza",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_APizza_SizeEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_SizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_APizza_CrustEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_CrustEntityId");

            migrationBuilder.AddColumn<long>(
                name: "SizeEntityId1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId1",
                table: "Pizzas",
                column: "SizeEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId1",
                table: "Pizzas",
                column: "SizeEntityId1",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId",
                table: "Toppings",
                column: "APizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId1",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityId1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeEntityId1",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "APizza");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "APizza",
                newName: "IX_APizza_SizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "APizza",
                newName: "IX_APizza_CrustEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APizza",
                table: "APizza",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizza_Crust_CrustEntityId",
                table: "APizza",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APizza_Size_SizeEntityId",
                table: "APizza",
                column: "SizeEntityId",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_APizza_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId",
                principalTable: "APizza",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_APizza_APizzaEntityId",
                table: "Toppings",
                column: "APizzaEntityId",
                principalTable: "APizza",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
