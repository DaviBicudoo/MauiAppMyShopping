# My Shopping List 📝

## Overview
My Shopping List is a .NET MAUI application designed to help users manage their shopping wishlist efficiently. Built following the MVVM architecture, this project demonstrates best practices in mobile application development.

## 🚀 Key Features
- Cross-platform mobile application using .NET MAUI
- Clean and maintainable MVVM architecture
- Persistent product list management
- Intuitive user interface
- SQLite database integration

## 🔧 System Requirements
- Operating System: Windows 10/11 or macOS
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Version 17.3 or later)
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- .NET MAUI development workload

## 📦 Setup and Installation

### Prerequisites
1. Install Visual Studio 2022
2. Add .NET MAUI Workload during installation
3. Ensure .NET 9.0 SDK is installed

### Installation Steps
```bash
# Clone the repository
git clone https://github.com/DaviBicudoo/MauiAppMyShopping.git

# Navigate to project directory
cd MauiAppMyShopping

# Restore NuGet packages
dotnet restore

# Build the project
dotnet build
```

## 🏗️ Project Structure
```
MauiAppMyShopping/
│
├── Models/             # Data models and entities
│   └── Product.cs      # Product data model
│
├── Views/              # User interface components
│   ├── EditProduct.xaml
│   ├── EditProduct.xaml.cs
│   ├── NewProduct.xaml
│   ├── NewProduct.xaml.cs
│   ├── ProductList.xaml
│   └── ProductList.xaml.cs
│
├── ViewModels/         # Application logic
│   └── ProductViewModel.cs
│
├── Services/           # Data and business logic services
│   └── DatabaseService.cs
│
├── Helpers/            # Utility classes
│   └── SQLiteDatabaseHelper.cs
│
├── Resources/          # Static resources and assets
│
└── Platforms/          # Platform-specific configurations
```

## 🔍 MVVM Architecture
The application implements the Model-View-ViewModel (MVVM) design pattern:

### Architecture Components
- **Model**: Represents data structures and business entities
- **View**: Defines the user interface using XAML
- **ViewModel**: Manages application logic and data binding

### Code Example
```csharp
// Model
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// ViewModel
public class ProductViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Product> _products;
    public ObservableCollection<Product> Products 
    {
        get => _products;
        set 
        {
            _products = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddProductCommand { get; }

    public ProductViewModel()
    {
        Products = new ObservableCollection<Product>();
        AddProductCommand = new Command(AddProduct);
    }

    private void AddProduct()
    {
        // Add product logic
    }

    // INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

## 🛠 Technologies Used
- .NET MAUI
- C# 
- SQLite
- MVVM Pattern
- Dependency Injection
- Data Binding

## 🧩 Flowchart

### Project Flowchart


| Screen Name | Description | 
|-------------|-------------|
| Home Screen | Main shopping list view | 
| Add Product | Interface for adding new products |
| Edit Product | Screen for editing product details | 

## 🤝 Contributing
1. Fork the repository
2. Create a feature branch 
   ```bash
   git checkout -b feature/AmazingFeature
   ```
3. Commit your changes 
   ```bash
   git commit -m 'Add some Amazing Feature'
   ```
4. Push to the branch 
   ```bash
   git push origin feature/AmazingFeature
   ```
5. Open a Pull Request

### Contribution Guidelines
- Follow C# coding conventions
- Write clean, maintainable code
- Include unit tests for new features
- Update documentation accordingly

## 🐛 Known Issues
- List any known bugs or limitations
- Provide workarounds if applicable

## 🔗 Useful Resources
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [MVVM Pattern Guide](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)
- [Visual Studio MAUI Development](https://visualstudio.microsoft.com/vs/features/net-maui/)

## 📋 License
[Specify License Type] - See LICENSE.md for details

## 📞 Contact
- **Name**: Davi Silva
- **Email**: daviyeestudando@gmail.com
- **GitHub**: [DaviBicudoo](https://github.com/DaviBicudoo)

## 🌟 Acknowledgments
- Microsoft .NET Team
- MAUI Community
- Open-source contributors
