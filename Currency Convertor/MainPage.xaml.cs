using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Currency_Convertor.Models;
using Newtonsoft.Json.Linq;

namespace Currency_Convertor
{
	public partial class MainPage : ContentPage
	{

		double TotalAmount;

		/// <summary>
		/// Create an instance to the class model
		/// </summary>
		CurrencyModel DataModel = new CurrencyModel();
		
		public MainPage()
		{
			InitializeComponent();
			CallAPI();
		}

		//Call the API function from the class and pre-load it each time the app is opened
		public async void CallAPI()
		{
			await API.GetAPI();
		
		}

		//Update and print out the currency convertion 
		public async void  UpdateCurrency()
		{
			double convertCurrency;
			
			string currency = (string)PickerCurrency.SelectedItem;
			if(currency != null)
			{
				JObject rates = await API.GetAPI();
				float value = rates.Value<float>(currency);
				if (TotalAmount == 0)
				{
					convertCurrency = Math.Round((value * 0),2);
				}
				else
				{
					convertCurrency = Math.Round((value * TotalAmount),2);
				}
				Convertor.Text = convertCurrency.ToString();
			}
			

		}

		//Load the currency convertor each time we select an element in the picker
		private void PickerCurrency_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateCurrency();
		}

		/// <summary>
		/// Update the total amout on the screen
		/// </summary>
		public void UpdateUI()
		{
			TotalAmount = (DataModel.Num1 * 1) + (DataModel.Num50c * 0.5) + (DataModel.Num10c * 0.1) + (DataModel.Num5c * 0.05);
			Output.Text = String.Format("{0}€", TotalAmount );
			UpdateCurrency();
			
		}

		/// <summary>
		/// Update the counter of each coin's amount
		/// </summary>
		public void UpdateCount()
		{
			count1dollar.Text = String.Format("({0})", DataModel.Num1);
			count50c.Text = String.Format("({0})", DataModel.Num50c);
			count10c.Text = String.Format("({0})", DataModel.Num10c);
			count5c.Text = String.Format("({0})", DataModel.Num5c);
		}

		/// <summary>
		/// Update the coin's amount in the left of the screen
		/// </summary>
		public void UpdateOutput()
		{
			output1dollar.Text = String.Format("{0}€", DataModel.Num1 * 1);
			if ((DataModel.Num50c * 0.5) >= 1)
			{
				output50c.Text = String.Format("{0}€", DataModel.Num50c * 0.5);
			}else
			{
				output50c.Text = String.Format("{0}c", DataModel.Num50c * 0.5);
			}

			if ((DataModel.Num10c * 0.1) >= 1)
			{
				output10c.Text = String.Format("{0}€", DataModel.Num10c * 0.1);
			}else
			{
				output10c.Text = String.Format("{0}c", DataModel.Num10c * 0.1);
			}
			if ((DataModel.Num5c * 0.05) >= 1)
			{
				output5c.Text = String.Format("{0}€", DataModel.Num5c * 0.05);
			}else
			{
				output5c.Text = String.Format("{0}c", DataModel.Num5c * 0.05);
			}

		}
		
		/// <summary>
		/// Add 1 dollar to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd1_Clicked(object sender, EventArgs e)
		{
			DataModel.AddOne();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Add 50 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd50c_Clicked(object sender, EventArgs e)
		{
			DataModel.Add50c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}
		
		/// <summary>
		/// Add 10 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void BtnAdd10c_Clicked(object sender, EventArgs e)
		{
			DataModel.Add10c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Add 5 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnAdd5c_Clicked(object sender, EventArgs e)
		{
			DataModel.Add5c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Subtract 5 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSubtract5c_Clicked(object sender, EventArgs e)
		{

			DataModel.Subtract5c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();

		}

		/// <summary>
		/// Subtract 10 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSubtract10c_Clicked(object sender, EventArgs e)
		{
			DataModel.Subtract10c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Subtract 50 cent to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSubtract50c_Clicked(object sender, EventArgs e)
		{
			DataModel.Subtract50c();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Subtract a dollar to the wallet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSubtract1_Clicked(object sender, EventArgs e)
		{
			DataModel.Subtract1();
			UpdateUI();
			UpdateCount();
			UpdateOutput();
		}


		/// <summary>
		///  Down 10 cent to 5 cent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void down10c_Clicked(object sender, EventArgs e)
		{
			DataModel.Down10c();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Up 10 cent to 50 cent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void up10c_Clicked(object sender, EventArgs e)
		{
			DataModel.Up10c();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Up 5 cent to 10 cent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void up5c_Clicked(object sender, EventArgs e)
		{
			DataModel.Up5c();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Down 50 cent to 10 cent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void down50c_Clicked(object sender, EventArgs e)
		{ 
			DataModel.Down50c();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Convert 50 cent to a dollar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void up50c_Clicked(object sender, EventArgs e)
		{
			DataModel.Up50c();
			UpdateCount();
			UpdateOutput();
		}

		/// <summary>
		/// Up a dollar to 50 cent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void downDollar_Clicked(object sender, EventArgs e)
		{
			DataModel.Downdollar();
			UpdateCount();
			UpdateOutput();
		}

	
	}
}
