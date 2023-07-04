﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seed data to database
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Fullname", "BrandName", "UserName", "Password", "Address", "RoleId", "Email", "IsDeleted" , "EmailConfirmed", "PhoneNumberConfirmed", "" +
                "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
                values: new object[,]
                {
                    {"US001","doviethoang","dirtycoin","hoangdv6","abc","District 9, Ho Chi Minh",1,"hoangdv6@gmail.com",false,true,false,false,false,0},
                    {"US002","lexuandai","nike","hoangdv6","dailx","Nha Be , Ho Chi Minh",2,"dailx@gmail.com",false,true,false,false,false,0 },
                    {"US003","huuvinh","adidas","vinhn","vinh","Binh Thanh District, Ho Chi Minh",2,"vinhhn@gmail.com",false,true,false,false,false,0 },
                    {"US004","thinhphu","TeeLab","thinh","thinhp","District 9, Ho Chi Minh",2,"hoangdv6@gmail.com",false,false,false,false,false,0 },
                    {"US005","oanhvtk","Adidas","oanhvtk","oanh","Tan Binh, Ho Chi Minh",2,"oanhvtk@gmail.com",false,true,false,false,false,0 },

                }
                );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryName", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {"Short Pan" ,"US001" , false},
                    {"Shoes" ,"US002",false},
                    {"Short","US003",false },
                    {"Shirt","US003" , true},
                    {"Jacket","US002",true},
                    {"Long pan" , "US001" , false }
                }
                );
            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "VoucherName", "Code", "Value", "CreationDate", "ExpirationDate", "Quantity", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {"BacktoSchool","BTS001",30,"2023-09-30","2023-09-30",10,"US002",false},
                    {"BlackFriday","BF001",60,"2023-11-24","2023-11-24",2,"US004",false},
                    {"BigSale","BS001",35,"2023-06-30","2023-08-20",3,"US003",false},
                    {"WomanDay","WD001",25,"2023-06-30","2023-03-09",2,"US005",false},
                }
                );

            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "CategoryId", "UserId", "ProductName", "Description", "ImageUrls", "SellPrice", "RentPrice" },
            values: new object[,]
            {
                {
                    3,
                    "US002",
                    "Short Sleeve Tee shirt - \"Black No Sugar No Cream\"",
                    "Let them know how you like your coffee with this Short Sleeve Tee shirt - Black No Sugar No Cream.",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f1.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f2.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f3.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f4.jpg?raw=true",
                    350000,
                    120000,
                },
                {
                    3,
                    "US002",
                    "Low Waist Comfortable Underwear",
                    "﻿Low Waist Comfortable  Underwear will have you feeling effortlessly elegant with its body shaping style.",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f5.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f6.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/f8.jpg?raw=true]",
                    270000,
                    99000
                },
                {
                    3,
                    "US003",
                    "A House Is Not a Home Without Paw Prints- Dog - Hoodie",
                    "Got a dog? Here is the perfect unisex hoodie for all the dog-lover! A house is not a home without paw prints..",
                    "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n1.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n2.jpg?raw=true",
                    250000,
                    87000
                },
                {
                  1,
                  "US003",
                  "Sleeveless Thicken Waistcoat Jacket",
                  "This Sleeveless Thicken Waistcoat Jacket will keep you warm and make you feel cosy, and its high collar will help you keep out of any autumn chills without compromising on aesthetics. ",
                  "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n3.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n4.jpg?raw=true",
                  190000,
                  77000
                },
                 {
                 1,
                 "US002",
                 "Skeleton Oversized Jeans",
                 "Whether you love Halloween or simply like to show off your rough side - do it in our unisex oversized jeans with a skeleton print!",
                 "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n5.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n6.jpg?raw=true,https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n7.jpg?raw=true",
                 140000,
                 60000
             },
                 {
                2,
                "US002",
                "Charcoal Sweat Pant",
                "Want to lounge in style?Then try our signature, soft, warm and classic fit fleece Charcoal Sweat Pant",
                "https://github.com/tech2etc/Build-and-Deploy-Ecommerce-Website/blob/main/img/products/n8.jpg?raw=true",
                450000,
                189000
            }
            });


            /*            migrationBuilder.InsertData(
                            table: "Products",
                            columns: new[] { "CategoryId", "UserId", "ProductName", "Description", "ImageUrl", "Price", "CreationDate", "IsDeleted" },
                            values: new object[,]
                            {
                                {1,"US001","Short Pan" ,"Short Pan from Dirty Coins" ,"https://bizweb.dktcdn.net/100/369/010/products/1-e95372e6-c524-4715-a07d-791c91ebe7ea.jpg?v=1656325763640",300000,"2023-06-30",false },
                                {1,"US002","Nike AF1 Mid" ,"Short Pan from Dirty Coins" ,"https://cdn.vortexs.io/api/images/372b5357-2d66-4d6d-8b89-9bed5ea69bca/1920/w/50-giay-nike-air-force-1-mid-all-white-o-314195-113.jpeg",1600000,"2023-06-30",false },
                                {1,"US004","Short TeeLab" ,"Short Local Band Unisex Special" ,"https://bizweb.dktcdn.net/thumb/large/100/415/697/products/ta9216-11k7zwk1-1-7fw9-hinh-mat-sau-0-e7d37221-9eeb-4978-868f-9193908bee74.jpg?v=1685936039000",190000,"2023-06-30",false },
                                {1,"US003","Adidas Ultra Boots" ,"Adidas Ultra Boots Black-White" ,"https://giayxshop.vn/wp-content/uploads/2019/01/z3651678985400_f5c2a3afb17825c7244e3a4698bb798c-scaled.jpg",2500000,"2023-06-30",false },
                                {1,"US005","Adidas Jacket" ,"" ,"https://cdn.vortexs.io/api/images/a69812de-f2c5-4243-abe0-72cf736ab4d7/1920/w/ao-khoac-jacket-adidas-firebird-track-red-hot-gf0211.jpeg",300000,"2023-06-30",false },

                            }
                            );*/

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ProductId", "UserId", "Message", "IsDeleted" },
                values: new object[,]
                {
                    {1 , "US005" , "Shoes still pretty new and fix with my foots",false },
                    {2, "US001" , "The pant is quite small for me ,  but still ok",false },
                    {3 , "US002" , "Jacket look so nice , very new than the imagine",false },
                    {4 , "US004", "Shoes still pretty new and fix with my foots",false },
                }
                );

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ProductId", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {1,"US001",false },
                    {2,"US003",false },
                    {3,"US005",false },
                    {4,"US002",false },
                    {5,"US002",false },
                    {1,"US002",false },
                    {2,"US003",false },
                    {3,"US004",false },
                    {3,"US001",false }
                }
                );
            migrationBuilder.InsertData(
              table: "Orders",
              columns: new[] { "UserId", "ProductId", "DeliverMethod", "DeliverDetais", "PaymentMethod", "PaymentDetais", "OrderStatus", "Note", "IsDeleted" },
              values: new object[,]
              {
                    {"US001",1,"Grab","Nothing" , "Grab will collect on my behalf " , "Card payment" ," On the way " ,"Nothing",false },
                    {"US002",2,"Self-deliver","Nothing" , "Pay Directly" , "Card payment" ,"Preparing" ,"Nothing",false },
              }
              );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
