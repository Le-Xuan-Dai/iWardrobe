# iWardrobe
## How to create database ?
- Đổi mật khẩu sa sql server: 123456
- Clone code
- Build project (click chuột phải 'iWardrobe' solution -> Build)
- Tools -> NuGet Package Manger -> Package Manger Console -> Run script: "update-database –verbose"
- Mở SQL server -> check đã có 'IWardrobeDB' chưa
  
## How to run project ?
- Config start project to "WebApplication"
- Ctrl + F5
  
## Dependences
- .NET 5
- Microsoft Sql Server (> 2014)
- MMicrosoft.EntityFrameworkCore.Design (5.0.17)
- Microsoft.EntityFrameworkCore.SqlServer (5.0.17)
- Microsoft.EntityFrameworkCore.Tools (5.0.17)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (5.0.2)

## Lưu ý khi làm t task
- Kéo task của mình từ "To Do" -> "In Progress"
- Click vào task -> task details mở lên -> Điền vào mục "Start date" -> Chọn "Create branch" -> copy script
- Visual Studio Code -> Terminal -> checkout master -> git pull -> paste script vừa copy
- Code, commit và push code lên
- Xong thì tạo pull request
  
