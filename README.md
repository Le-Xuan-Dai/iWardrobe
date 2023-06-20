# iWardrobe
## How to create database ?
1. Đổi mật khẩu sa sql server: 123456
2. Build project
3. Config start project to "BusinessObjects"
4. Tools -> NuGet Package Manger -> Package Manger Console -> Run script: "update-database –verbose"
5. Run script : "Add-Migration SeedData" then run script : "Update-Database"
## How to run project ?
1. Config start project to "WebApplication"
2. Ctrl + F5
## Dependences
- .NET 5
- Microsoft Sql Server (> 2014)
- Microsoft.EntityFrameworkCore.SqlServer (5.0.9)
- Microsoft.EntityFrameworkCore.Tools (5.0.9)
- Microsoft.Extensions.Configuration (5.0.0)
- Microsoft.Extensions.Configuration.Json (5.0.0)
## Lưu ý khi làm t task
- Kéo task của mình từ "To Do" -> "In Progress"
- Click vào task -> task details mở lên -> Điền vào mục "Start date" -> Chọn "Create branch" -> copy script
- Visual Studio Code -> Terminal -> checkout master -> git pull -> paste script vừa copy
- Code, commit và push code lên
- Xong thì tạo pull request
  
