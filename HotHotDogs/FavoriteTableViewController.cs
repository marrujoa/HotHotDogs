using System;
using UIKit;
using Foundation;
using System.CodeDom.Compiler;
using RaysHotDogs.Core;

namespace HotHotDogs
{
	partial class FavoriteTableViewController : UITableViewController
	{
		HotDogDataService dataService = new HotDogDataService();

		public FavoriteTableViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var favorites = dataService.GetAllHotDogs();
			TableView.Source = new HotDogDataSource(favorites, this);
			this.ParentViewController.NavigationItem.Title = "Our Favorite Hot Dogs!";
		}

		public async void HotDogSelected(HotDog selectedHotDog)
		{
			HotDogDetailViewController detailController =
				this.Storyboard.InstantiateViewController("HotDogDetailViewController") as HotDogDetailViewController;

			if (detailController != null)
			{
				detailController.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;

				detailController.SelectedHotDog = selectedHotDog;

				await PresentViewControllerAsync(detailController, true);
			}
		}
	}
}

