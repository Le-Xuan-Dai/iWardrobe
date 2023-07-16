using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seed data to database
            migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "Fullname", "Avatar", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
            values: new object[,]
            {
                {
                    "600206da-3607-4b5a-af5b-a793c69e1be2",
                    "Admin",
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-9ilfMbF6KQupB03VPoG-gN8CEgYvgv2wgw&usqp=CAU",
                    "iwardrobefasion@gmail.com",
                    "IWARDROBEFASION@GMAIL.COM",
                    "iwardrobefasion@gmail.com",
                    "IWARDROBEFASION@GMAIL.COM",
                    false,
                    "AQAAAAEAACcQAAAAEE0wXL8eJM6N9InsdebFtyqQQQ01zOkTEwShWpiWT8cSzSYSbM82eIHnA1HzfTQE4Q==",
                    "RCFCMR2ON6W5JBXFQBA6IWTIKW5DLIT2",
                    "5dd62dc2-6572-4db8-ab25-c1a1ecbddded",
                    false,
                    false,
                    true,
                    0
                },
            }
            );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryName", "UserId" },
                values: new object[,]
                {
                    {"Short Pan" ,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"Shoes" ,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"Short","600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {"Shirt","600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"Jacket","600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"Jacket","600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"Long pan" , "600206da-3607-4b5a-af5b-a793c69e1be2" }
                }
                );
            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "VoucherName", "Code", "Value", "CreationDate", "ExpirationDate", "Quantity", "UserId" },
                values: new object[,]
                {
                    {"BacktoSchool","BTS001",30,"2023-09-30","2023-09-30",10,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"BlackFriday","BF001",60,"2023-11-24","2023-11-24",2,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"BigSale","BS001",35,"2023-06-30","2023-08-20",3,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                    {"WomanDay","WD001",25,"2023-06-30","2023-03-09",2,"600206da-3607-4b5a-af5b-a793c69e1be2"},
                }
                );

            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "CategoryId", "UserId", "ProductName", "Description", "ImageUrls", "SellPrice", "RentPrice" },
            values: new object[,]
            {
                {
                    3,
                    "600206da-3607-4b5a-af5b-a793c69e1be2",
                    "Short Sleeve Tee shirt - \"Black No Sugar No Cream\"",
                    "Let them know how you like your coffee with this Short Sleeve Tee shirt - Black No Sugar No Cream.",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f1.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f2.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f3.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f4.jpg?raw=true",
                    350000,
                    120000,
                },
                {
                    3,
                    "600206da-3607-4b5a-af5b-a793c69e1be2",
                    "Low Waist Comfortable Underwear",
                    "﻿Low Waist Comfortable  Underwear will have you feeling effortlessly elegant with its body shaping style.",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f5.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f6.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f8.jpg?raw=true]",
                    270000,
                    99000
                },
                {
                    3,
                    "600206da-3607-4b5a-af5b-a793c69e1be2",
                    "A House Is Not a Home Without Paw Prints- Dog - Hoodie",
                    "Got a dog? Here is the perfect unisex hoodie for all the dog-lover! A house is not a home without paw prints..",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n1.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n2.jpg?raw=true",
                    250000,
                    87000
                },
                {
                  1,
                  "600206da-3607-4b5a-af5b-a793c69e1be2",
                  "Sleeveless Thicken Waistcoat Jacket",
                  "This Sleeveless Thicken Waistcoat Jacket will keep you warm and make you feel cosy, and its high collar will help you keep out of any autumn chills without compromising on aesthetics. ",
                  "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n3.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n4.jpg?raw=true",
                  190000,
                  77000
                },
                 {
                 1,
                 "600206da-3607-4b5a-af5b-a793c69e1be2",
                 "Skeleton Oversized Jeans",
                 "Whether you love Halloween or simply like to show off your rough side - do it in our unisex oversized jeans with a skeleton print!",
                 "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n5.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n6.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n7.jpg?raw=true",
                 140000,
                 60000
             },
                 {
                2,
                "600206da-3607-4b5a-af5b-a793c69e1be2",
                "Charcoal Sweat Pant",
                "Want to lounge in style?Then try our signature, soft, warm and classic fit fleece Charcoal Sweat Pant",
                "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n8.jpg?raw=true",
                450000,
                189000
            }
            });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ProductId", "UserId", "Message" },
                values: new object[,]
                {
                    {1 , "600206da-3607-4b5a-af5b-a793c69e1be2" , "Shoes still pretty new and fix with my foots" },
                    {2, "600206da-3607-4b5a-af5b-a793c69e1be2" , "The pant is quite small for me ,  but still ok" },
                    {3 , "600206da-3607-4b5a-af5b-a793c69e1be2" , "Jacket look so nice , very new than the imagine" },
                    {4 , "600206da-3607-4b5a-af5b-a793c69e1be2", "Shoes still pretty new and fix with my foots" },
                }
                );

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ProductId", "UserId" },
                values: new object[,]
                {
                    {1,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {2,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {3,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {4,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {5,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {1,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {2,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {3,"600206da-3607-4b5a-af5b-a793c69e1be2" },
                    {3,"600206da-3607-4b5a-af5b-a793c69e1be2" }
                }
                );
            migrationBuilder.InsertData(
              table: "Orders",
              columns: new[] { "UserId", "ProductId", "DeliverMethod", "DeliverDetais", "PaymentMethod", "PaymentDetais", "OrderStatus", "Note" },
              values: new object[,]
              {
                    {"600206da-3607-4b5a-af5b-a793c69e1be2",1,"Grab","Nothing" , "Grab will collect on my behalf " , "Card payment" ,"PENDING" ,"Nothing" },
                    {"600206da-3607-4b5a-af5b-a793c69e1be2",2,"Self-deliver","Nothing" , "Pay Directly" , "Card payment" ,"PROCESSING" ,"Nothing" },
                     {"600206da-3607-4b5a-af5b-a793c69e1be2",3,"Grab","Nothing" , "Grab will collect on my behalf " , "Card payment" ,"SHIPPED" ,"Nothing" },
                    {"600206da-3607-4b5a-af5b-a793c69e1be2",4,"Self-deliver","Nothing" , "Pay Directly" , "Card payment" ,"DELIVERED" ,"Nothing" },
                     {"600206da-3607-4b5a-af5b-a793c69e1be2",5,"Grab","Nothing" , "Grab will collect on my behalf " , "Card payment" ,"CANCELLED" ,"Nothing" },
                    {"600206da-3607-4b5a-af5b-a793c69e1be2",6,"Self-deliver","Nothing" , "Pay Directly" , "Card payment" ,"PROCESSING" ,"Nothing" },
              }
              );

            migrationBuilder.InsertData(
             table: "Roles",
             columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
             values: new object[,]
             {
                    {"b4f710f2-66d1-4661-8a5d-598d38733828","Supplier","SUPPLIER","1713a208-ff3b-4970-897f-8ef439d29fe0"  },
                    {"be5ee07d-dd57-4421-95ad-c6b3bfaa686f","Admin","ADMIN","5dd62dc2-6572-4db8-ab25-c1a1ecbddded" },
                    {"ce2e3464-4714-4f78-b2d7-8d861ec365c3","Customer","CUSTOMER","26caa190-0f4a-434c-a2e5-70d795eacaf2" },
             }
             );

            migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "UserId", "RoleId" },
            values: new object[,]
            {
                {"600206da-3607-4b5a-af5b-a793c69e1be2","b4f710f2-66d1-4661-8a5d-598d38733828"  },
                {"600206da-3607-4b5a-af5b-a793c69e1be2","be5ee07d-dd57-4421-95ad-c6b3bfaa686f"  },
                {"600206da-3607-4b5a-af5b-a793c69e1be2","ce2e3464-4714-4f78-b2d7-8d861ec365c3"  },
            }
            );

            migrationBuilder.InsertData(
           table: "UserLogins",
           columns: new[] { "LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId" },
           values: new object[,]
           {
                {"Google","110471733882667666100", "Google", "600206da-3607-4b5a-af5b-a793c69e1be2" },
           }
           );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
