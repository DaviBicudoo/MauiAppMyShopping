using MauiAppMyShopping.Models;
using System.Collections.ObjectModel;

namespace MauiAppMyShopping.Views;

public partial class ProductList : ContentPage
{
	ObservableCollection<Product> list = new ObservableCollection<Product>();

	public ProductList()
	{
		InitializeComponent();

		productList.ItemsSource = list;
	}

    protected async override void OnAppearing()
    {
		List<Product> temporaryList = await App.Database.GetAll();

		temporaryList.ForEach(x => list.Add(x));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NewProduct());
		}
		catch (Exception ex)
		{
			DisplayAlert("OPS!", ex.Message, "Exit");
		}
    }

    private async void searchTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
		string query = e.NewTextValue;

		list.Clear();

        List<Product> temporaryList = await App.Database.Search(query);

        temporaryList.ForEach(x => list.Add(x));
    }
}