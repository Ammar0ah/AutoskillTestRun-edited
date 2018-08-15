using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoskillTestRun.Models;
using AutoskillTestRun.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoskillTestRun.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsFeedListPage : BasePage
	{
		public NewsFeedListPage ()
		{
			InitializeComponent ();
		}

	    public void DeselectItem()
	    {
	        MyListView.SelectedItem = null;
	    }

	}
}