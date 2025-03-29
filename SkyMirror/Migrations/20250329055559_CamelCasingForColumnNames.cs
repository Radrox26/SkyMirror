using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMirror.Migrations
{
    /// <inheritdoc />
    public partial class CamelCasingForColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_UserId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Products_ProductId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Leads_LeadId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_SalesManagerId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "Users",
                newName: "userRoleId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Users",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                newName: "IX_Users_userRoleId");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserRoles",
                newName: "roleName");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "UserRoles",
                newName: "userRoleId");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Quotations",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Quotations",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "SalesManagerId",
                table: "Quotations",
                newName: "salesManagerId");

            migrationBuilder.RenameColumn(
                name: "LeadId",
                table: "Quotations",
                newName: "leadId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Quotations",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "QuotationId",
                table: "Quotations",
                newName: "quotationId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_SalesManagerId",
                table: "Quotations",
                newName: "IX_Quotations_salesManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_LeadId",
                table: "Quotations",
                newName: "IX_Quotations_leadId");

            migrationBuilder.RenameColumn(
                name: "QuotationId",
                table: "QuotationItems",
                newName: "quotationId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "QuotationItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "QuotationItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "QuotationItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "QuotationItemId",
                table: "QuotationItems",
                newName: "quotationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_quotationId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_ProductId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_productId");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "stockQuantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "PowerInWatts",
                table: "Products",
                newName: "powerInWatts");

            migrationBuilder.RenameColumn(
                name: "PanelName",
                table: "Products",
                newName: "panelName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_categoryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCategories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductCategories",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Payments",
                newName: "paymentStatus");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "paymentDate");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Payments",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "Payments",
                newName: "amountPaid");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Payments",
                newName: "paymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                newName: "IX_Payments_orderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "orderDate");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderItems",
                newName: "orderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_orderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Leads",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Leads",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "InquiryDetails",
                table: "Leads",
                newName: "inquiryDetails");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Leads",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "LeadId",
                table: "Leads",
                newName: "leadId");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_UserId",
                table: "Leads",
                newName: "IX_Leads_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_userId",
                table: "Leads",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_orderId",
                table: "OrderItems",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_orderId",
                table: "Payments",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "ProductCategories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Products_productId",
                table: "QuotationItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_quotationId",
                table: "QuotationItems",
                column: "quotationId",
                principalTable: "Quotations",
                principalColumn: "quotationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Leads_leadId",
                table: "Quotations",
                column: "leadId",
                principalTable: "Leads",
                principalColumn: "leadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_salesManagerId",
                table: "Quotations",
                column: "salesManagerId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users",
                column: "userRoleId",
                principalTable: "UserRoles",
                principalColumn: "userRoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_userId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_orderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_orderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_categoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Products_productId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_quotationId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Leads_leadId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Users_salesManagerId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_userRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userRoleId",
                table: "Users",
                newName: "UserRoleId");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userRoleId",
                table: "Users",
                newName: "IX_Users_UserRoleId");

            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "UserRoles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "userRoleId",
                table: "UserRoles",
                newName: "UserRoleId");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "Quotations",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Quotations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "salesManagerId",
                table: "Quotations",
                newName: "SalesManagerId");

            migrationBuilder.RenameColumn(
                name: "leadId",
                table: "Quotations",
                newName: "LeadId");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Quotations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "quotationId",
                table: "Quotations",
                newName: "QuotationId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_salesManagerId",
                table: "Quotations",
                newName: "IX_Quotations_SalesManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotations_leadId",
                table: "Quotations",
                newName: "IX_Quotations_LeadId");

            migrationBuilder.RenameColumn(
                name: "quotationId",
                table: "QuotationItems",
                newName: "QuotationId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "QuotationItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "QuotationItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "QuotationItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "quotationItemId",
                table: "QuotationItems",
                newName: "QuotationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_quotationId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_QuotationId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_productId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_ProductId");

            migrationBuilder.RenameColumn(
                name: "stockQuantity",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "powerInWatts",
                table: "Products",
                newName: "PowerInWatts");

            migrationBuilder.RenameColumn(
                name: "panelName",
                table: "Products",
                newName: "PanelName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Products",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "ProductCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "paymentStatus",
                table: "Payments",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "paymentDate",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Payments",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "amountPaid",
                table: "Payments",
                newName: "AmountPaid");

            migrationBuilder.RenameColumn(
                name: "paymentId",
                table: "Payments",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_orderId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "orderDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "orderItemId",
                table: "OrderItems",
                newName: "OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_productId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_orderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Leads",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Leads",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "inquiryDetails",
                table: "Leads",
                newName: "InquiryDetails");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Leads",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "leadId",
                table: "Leads",
                newName: "LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_userId",
                table: "Leads",
                newName: "IX_Leads_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_UserId",
                table: "Leads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Products_ProductId",
                table: "QuotationItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "QuotationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Leads_LeadId",
                table: "Quotations",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Users_SalesManagerId",
                table: "Quotations",
                column: "SalesManagerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
