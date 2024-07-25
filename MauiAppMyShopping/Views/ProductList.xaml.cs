namespace MauiAppMyShopping.Views;

public partial class ProductList : ContentPage
{
	public ProductList()
	{
		InitializeComponent();
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
}