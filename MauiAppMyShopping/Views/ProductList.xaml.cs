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
		try
		{
			list.Clear(); // It clears the list view every time we go back to the window

			List<Product> temporaryList = await App.Database.GetAll();

			temporaryList.ForEach(x => list.Add(x));

		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "OK");
		}
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
		try
		{
            string query = e.NewTextValue;

            list.Clear();

            List<Product> temporaryList = await App.Database.Search(query);

            temporaryList.ForEach(x => list.Add(x));

        } catch(Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "OK");
		}
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		try
		{
            double total = list.Sum(x => x.Total);

            string message = $"The total price is {total:c}";

            DisplayAlert("My order", message, "OK");

        }
		catch (Exception ex)
		{
			DisplayAlert("OPS!", ex.Message, "OK");
		}
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
		// Delete product
		try
		{
			MenuItem selectedMenuItem = sender as MenuItem;

			Product product = selectedMenuItem.BindingContext as Product;

			bool confirm = await DisplayAlert("Warning!", $"Do you really want to exclude this product? ({product.Description}", 
				"Yes", "No");

			if(confirm)
			{
				await App.Database.Delete(product.Id);
				list.Remove(product);
			}

		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "OK");
		}
    }

    private async void MenuItem_Clicked_1(object sender, EventArgs e)
    {
		// Edit product 

		await Navigation.PushAsync(new Views.EditProduct());
    }
}