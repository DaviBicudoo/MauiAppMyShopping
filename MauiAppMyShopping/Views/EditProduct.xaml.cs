using MauiAppMyShopping.Models;

namespace MauiAppMyShopping.Views;

public partial class EditProduct : ContentPage
{
	public EditProduct()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
	            Product anexedProduct = BindingContext as Product; // Creates a variable (product type) which will be our Binding Context --> In other words, it will do the "ViewModel" function, linking the DB with the View
	
	            Product product = new Product
	            {
	                Id = anexedProduct.Id,
	                Description = productDescriptionTxt.Text,
	                Amount = Convert.ToInt16(productAmountTxt.Text),
	                Price = Convert.ToDouble(productUnitPrice.Text)
	            }; // Inserting the given values to a new instance of products
	
	            await App.Database.Update(product); // Update the product with new values
	
	            await DisplayAlert("Updated", "Success", "OK");
	
	            await Navigation.PopAsync();
        	}
		catch (Exception ex)
		{
			await DisplayAlert("OPS!", ex.Message, "OK");
		}
    }
}
