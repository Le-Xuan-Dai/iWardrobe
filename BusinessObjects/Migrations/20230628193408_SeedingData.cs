using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seed data to database
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "FullName", "BranchName", "UserName", "Password", "Address", "RoleID", "Email", "IsDeleted" },
                values: new object[,]
                {
                    {"doviethoang","dirtycoin","hoangdv6","abc","District 9, Ho Chi Minh",2,"hoangdv6@gmail.com",1 },
                    {"lexuandai","nike","hoangdv6","dailx","Nha Be , Ho Chi Minh",2,"dailx@gmail.com",1 },
                    {"huuvinh","adidas","vinhn","vinh","Binh Thanh District, Ho Chi Minh",2,"vinhhn@gmail.com",1 },
                    {"thinhphu","TeeLab","thinh","thinhp","District 9, Ho Chi Minh",2,"hoangdv6@gmail.com",1 },
                    {"oanhvtk","Adidas","oanhvtk","oanh","Tan Binh, Ho Chi Minh",2,"oanhvtk@gmail.com",1 },

                }
                );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryName", "UserID", "IsDeleted" },
                values: new object[,]
                {
                    {"Short Pan" , 1 , 1},
                    {"Shoes" , 2,1},
                    {"Short",3,1 },
                    {"Shirt",3 , 0},
                    {"Jacket",2,0},
                    {"Long pan" , 1 , 0 }
                }
                );
            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "VoucherName", "Code", "Value", "ExpinationDate", "Quantity", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {"BacktoSchool","BTS001",30,"2023-09-30",10,2,1},
                    {"BlackFriday","BF001",60,"2023-11-24",2,4,1},
                    {"BigSale","BS001",35,"2023-08-20",3,3,1},
                    {"WomanDay","WD001",25,"2023-03-09",2,5,1},
                }
                );

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "CategoryId", "UserId", "ProductName", "Description", "ImageUrl", "Price", "CreationDate", "IsDeleted" },
                values: new object[,]
                {
                    {1,1,"Short Pan" ,"Short Pan from Dirty Coins" ,"https://bizweb.dktcdn.net/100/369/010/products/1-e95372e6-c524-4715-a07d-791c91ebe7ea.jpg?v=1656325763640",300000,"GETDATE()",1 },
                    {2,2,"Nike AF1 Mid" ,"Short Pan from Dirty Coins" ,"https://cdn.vortexs.io/api/images/372b5357-2d66-4d6d-8b89-9bed5ea69bca/1920/w/50-giay-nike-air-force-1-mid-all-white-o-314195-113.jpeg",1600000,"GETDATE()",1 },
                    {3,4,"Short TeeLab" ,"Short Local Band Unisex Special" ,"https://bizweb.dktcdn.net/thumb/large/100/415/697/products/ta9216-11k7zwk1-1-7fw9-hinh-mat-sau-0-e7d37221-9eeb-4978-868f-9193908bee74.jpg?v=1685936039000",190000,"GETDATE()",1 },
                    {2,3,"Adidas Ultra Boots" ,"Adidas Ultra Boots Black-White" ,"https://giayxshop.vn/wp-content/uploads/2019/01/z3651678985400_f5c2a3afb17825c7244e3a4698bb798c-scaled.jpg",2500000,"GETDATE()",1 },
                    {5,5,"Adidas Jacket" ,"" ,"https://cdn.vortexs.io/api/images/a69812de-f2c5-4243-abe0-72cf736ab4d7/1920/w/ao-khoac-jacket-adidas-firebird-track-red-hot-gf0211.jpeg",300000,"GETDATE()",1 },

                }
                );

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ProductId", "UserId", "Message", "IsDeleted" },
                values: new object[,]
                {
                    {2 , 5 , "Shoes still pretty new and fix with my foots",1 },
                    {2 , 1 , "The pant is quite small for me ,  but still ok",1 },
                    {5 , 2 , "Jacket look so nice , very new than the imagine",1 },
                    {4 , 4, "Shoes still pretty new and fix with my foots",1 },
                }
                );

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "ProductId", "UserId", "IsDeleted" },
                values: new object[,]
                {
                    {2,1,1 },
                    {2,3,1 },
                    {2,5,1 },
                    {3,2,1 },
                    {4,2,1 },
                    {5,3,1 },
                    {1,2,1 },
                    {1,4,1 },
                    {3,1,1 }
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
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
