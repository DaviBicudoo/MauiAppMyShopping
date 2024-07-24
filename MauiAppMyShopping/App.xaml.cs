using MauiAppMyShopping.Helpers;

namespace MauiAppMyShopping
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), 
                        "shopping_db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ProductList());
        }
    }
}
