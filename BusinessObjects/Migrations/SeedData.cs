using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Migrations
{
    public class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seed data to database
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Name", "IsDeleted" },
                values: new object[,] {
                         {"Admin" , true }  ,
                         {"User" , true }
                        }
                    );
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Name", "PhoneNumber", "Password", "Email", "Address", "RoleId", "IsDeleted" },
                values: new object[,]
                    {
                        { "hoangdv", "0335349368", "abc", "doviethoang963@gmail.com", "Lò Lu, Long Trường, Q9, HCM", 2, false },
                        { "dailx", "0446458477", "cde", "dailx@gmail.com", "XVNT,Phường 13, Bình Thạnh, HCM", 2, false },
                        { "vinhnguyen", "0337367488", "efg", "vinhnguyen@gmail.com", "Nguyễn Xiển, Tăng Nhơn Phú, Q9, HCM", 2, false },
                        { "taipha", "0335244376", "abc", "taipha@gmail.com", "Nguyễn Oanh,Gò Vấp, HCM", 2, false },
                        { "hieudht", "0399488273", "cde", "hieu@gmail.com", "XVNT,Phường 13, Bình Thạnh, HCM", 2, false },
                        { "vynt", "0456377483", "efg", "vynt@gmail.com", "Nguyễn Xiển, Tăng Nhơn Phú, Q9, HCM", 2, false },
                     }
                );
            /* migrationBuilder.InsertData(
                 table: "Carts",
                 columns: new[] { "UserID", "IsDeleted" },
                 values: new object[,]
                 {
                     {2,false},{1,false},{3,false }
                 }
                 );*/
            migrationBuilder.InsertData(
                    table: "Vouchers",
                    columns: new[] { "VoucherName", "Code", "Value", "CreationDate", "ExpirationDate", "UserId", "Quantity", "IsDeleted" },
                    values: new object[,]
                    {
                        {"Save Money" , "SM001",5 , "2023-07-18","2023-07-18",1,50,false } ,
                        {"Free Ship" , "FS001",4 , "2023-05-20","2023-08-18",1,100,false },
                        {"Woman Day" , "WD001",15 , "2023-03-07","2023-03-10",3,20,true },
                        {"BlackFriday" , "BF001",60 , "2023-11-23","2023-11-25",1,50,false } ,

                    }
                    );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryName", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {"Shirt" , 3,false },
                    {"Short-pan" , 2,false} ,
                    {"T-Shirt",2,false},
                    {"Short-dress",3,false},
                    {"Jogger",4,false },
                    {"Dress",5,false }
                }
                );
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "CategoryId", "UserId", "ProductName", "Description", "ImageUrl", "Price", "CreationDate", "IsDeleted" },
                values: new object[,]
                {
                    {1,3,"Short for Man","Suitable for weight 70 - 85kg","https://www.chapi.vn/img/product/2019/8/13/quan-short-nam-cotton-mna-2-500x500.jpg",50.0,"2023-06-18",false },
                    {2,1,"Man T-Shirt ","Suitable for weight 70 - 85kg","https://cdn.shopify.com/s/files/1/0345/9134/2651/products/halo-cotton-t-shirt-oyster-grey-kyoto-328290_1024x1024.jpg?v=1682471391",60.0,"2023-05-15",true },
                    {2,3,"Polo Shirt","Suitable for weight 70 - 85kg","https://bizweb.dktcdn.net/thumb/1024x1024/100/399/392/products/ao-polo-nam-tay-phoi-mau-trang-den-hiddle-25112101.jpg?v=1648640187960",80.0,"2023-06-18",true },
                    {4,3,"Short Dress","Beauti,polite for gala party","https://cdn.shopify.com/s/files/1/0217/9066/products/CarminiaWhiteMiniDress-1_1024x1024.jpg?v=1660706355",50.0,"2023-06-18",false },
                    {2,1,"T-Shirt Dirty Coin","Item is pretty new cause had been bought since 3 last months","https://bizweb.dktcdn.net/100/369/010/products/1-1.jpg?v=1678347014000",60.0,"2023-05-15",true },
                    {2,3,"CoolMate Polo","Suitable for weight 70 - 85kg","https://cf.shopee.vn/file/7c25ef841730711d331822efe5c53dbb",80.0,"2023-06-18",true }
                }

            );
            migrationBuilder.InsertData(
               table: "Favorites",
               columns: new[] { "ProductId", "UserId", "IsDeleted" },
               values: new object[,]
               {
                    {1,2,false},
                    {2,1,false},
                     {2,4,false},
                    {1,3,false},
                     {1,5,false},
                    {3,1,false},
                     {5,1,false},
               }
               );
            migrationBuilder.InsertData(
                table: "CartDetails",
                columns: new[] { "UserId", "ProductId", "Quantity", "IsDeleted" },
                values: new object[,]
                {
                    { 1,2,10,false},
                    {1,3,2,false},
                    {2,2,20,false},
                    { 3,2,10,false},{5,3,2,false},{1,2,20,false}
                }
                );
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ProductId", "UserId", "Message", "IsDeleted" },
                values: new object[,]
                {
                    {2,1,"Fit with my weight, my style",false },
                    {3,1,"Fit with my weight ",false }
                }
                );
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "UserId", "ProductId", "DeliverMethod", "DeliverDetais", "PaymentMethod", "PaymentDetais", "OrderStatus", "Note", "IsDeleted" },
                values: new object[,]
                {
                    {1,2,"Grab","Nothing" , "Grab will collect on my behalf " , "Card payment" ," On the way " ,"Nothing",false },
                    {2,3,"Self-deliver","Nothing" , "Pay Directly" , "Card payment" ,"Preparing" ,"Nothing",false },
                }
                );

        }

    }
}
