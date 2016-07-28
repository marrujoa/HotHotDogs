using System;
using UIKit;
using Foundation;
using System.CodeDom.Compiler;
using RaysHotDogs.Core;
using System.Collections.Generic;

namespace HotHotDogs
{
	partial class MeatLoversTableViewController : UITableViewController
	{
		HotDogDataService dataService = new HotDogDataService();

		public MeatLoversTableViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var favorites = new List<HotDog>() { dataService.GetHotDogById(1) };
			TableView.Source = new HotDogDataSource(favorites, this);
			this.ParentViewController.NavigationItem.Title = "Our Meat Lovers Hot Dogs!";
		}

		public async void HotDogSelected(HotDog selectedHotDog)
		{
			HotDogDetailViewController detailController =
				this.Storyboard.InstantiateViewController("HotDogDetailViewController") as HotDogDetailViewController;

			if (detailController != null)
			{
				detailController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;

				detailController.SelectedHotDog = selectedHotDog;

				await PresentViewControllerAsync(detailController, true);
			}
		}
	}
}

