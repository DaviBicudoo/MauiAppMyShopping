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
			};

			await App.Database.Create(product);

			await DisplayAlert(":)", "Success", "OK");

			await Navigation.PopAsync();

		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "Exit");
		}
    }
}