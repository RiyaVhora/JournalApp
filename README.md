# 📖 Journal App

A simple and elegant journal application built with ASP.NET Core MVC, allowing you to capture your thoughts, track your mood, and organize your daily reflections.

## ✨ Features

- **📝 Journal Entries**: Create, read, update, and delete journal entries
- **😊 Mood Tracking**: Track your daily mood with emoji-based selection
- **🌤️ Weather & Location**: Add weather conditions and location to your entries
- **🏷️ Tag System**: Organize entries with custom tags
- **🔍 Search & Filter**: Find entries by mood, tags, or text content
- **📱 Responsive Design**: Beautiful, mobile-friendly interface
- **💾 SQL Server Database**: Reliable data storage with Entity Framework Core

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/RiyaVhora/JournalApp.git
   cd JournalApp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update connection string** (if needed)
   - Open `appsettings.json`
   - Update the connection string to match your SQL Server instance:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=JournalDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`
   - The application will automatically create the database and tables

## 🎯 Usage

### Creating a Journal Entry
1. Click "New Entry" on the main page
2. Fill in the title and content
3. Select your mood, weather, and location (optional)
4. Add tags separated by commas
5. Click "Save Entry"

### Searching and Filtering
- Use the search bar to find entries by title, content, or location
- Filter by mood using the dropdown
- Filter by tags using the tag filter

### Managing Entries
- **View**: Click "Read More" to see full entry details
- **Edit**: Click the edit button to modify an entry
- **Delete**: Click the delete button to remove an entry

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Icons**: Font Awesome 6
- **Validation**: jQuery Validation

## 📁 Project Structure

```
JournalApp/
├── Controllers/          # MVC Controllers
│   ├── HomeController.cs
│   └── JournalController.cs
├── Data/                # Database Context
│   └── AppDbContext.cs
├── Models/              # Data Models
│   ├── ErrorViewModel.cs
│   └── JournalEntry.cs
├── Views/               # Razor Views
│   ├── Home/
│   ├── Journal/
│   └── Shared/
├── wwwroot/             # Static Files
│   ├── css/
│   ├── js/
│   └── lib/
├── appsettings.json     # Configuration
└── Program.cs           # Application Entry Point
```

## 🗄️ Database Schema

### JournalEntry Table
- `Id` (int, Primary Key)
- `Title` (nvarchar(100), Required)
- `Content` (nvarchar(max))
- `CreatedAt` (datetime2)
- `UpdatedAt` (datetime2, Nullable)
- `Mood` (nvarchar(max), Nullable)
- `Tags` (nvarchar(max), Nullable)
- `Weather` (nvarchar(max), Nullable)
- `Location` (nvarchar(max), Nullable)

## 🔧 Configuration

### Connection String
Update the connection string in `appsettings.json` to match your SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=JournalDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### Supported SQL Server Instances
- SQL Server LocalDB (default)
- SQL Server Express
- SQL Server Developer/Standard/Enterprise


## 👩‍💻 Author

**Riya Vhora**
- GitHub: [@RiyaVhora](https://github.com/RiyaVhora)

## 🙏 Acknowledgments

- [Bootstrap](https://getbootstrap.com/) for the responsive UI framework
- [Font Awesome](https://fontawesome.com/) for the beautiful icons
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) for the robust web framework
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for the data access layer

## 📞 Support

If you have any questions or run into issues, please:
1. Check the [Issues](https://github.com/RiyaVhora/JournalApp/issues) page
2. Create a new issue with detailed information
3. Contact the author

---

**Happy Journaling! 📖✨**
