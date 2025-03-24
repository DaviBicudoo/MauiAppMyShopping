using MauiAppMyShopping.Models;

namespace MauiAppMyShopping.Views;

public partial class NewProduct : ContentPage
{
	public NewProduct()
	{
		InitializeComponent();
	}

    	private async void ToolbarItem_Clicked(object sender, EventArgs e)
    	{
		try
		{
			Product product = new Product
			{
				Description = productDescriptionTxt.Text,
				Amount = Convert.ToInt16(productAmountTxt.Text),
				Price = Convert.ToDouble(productUnitPrice.Text)
			}; // Creates a new instance of Product with the assigned values (on NewProduct.xaml)

			await App.Database.Create(product); // The product is created

			await DisplayAlert(":)", "Success", "OK");

			await Navigation.PopAsync(); // The view is closed, and we go back to home screen

		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "Exit"); // If there's a problem, you know...
		}
    	}
}
