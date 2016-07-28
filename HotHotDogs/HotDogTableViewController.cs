using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core;

namespace HotHotDogs
{
    public partial class HotDogTableViewController : UITableViewController
    {
		HotDogDataService dataService = new HotDogDataService();

        public HotDogTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var hotDogs = dataService.GetAllHotDogs();
			var datasource = new HotDogDataSource(hotDogs, this);

			TableView.Source = datasource;

			this.NavigationItem.Title = "Hot Hot Dog's menu";
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			//if (segue.Identifier == "HotDogDetailSegue")
			//{
			//	var hotDogDetailViewController = segue.DestinationViewController as HotDogDetailViewController;
			//	if (hotDogDetailViewController != null)
			//	{
			//		var source = TableView.Source as HotDogDataSource;
			//		var rowPath = TableView.IndexPathForSelectedRow;
			//		var item = source.GetItem(rowPath.Row);
			//		hotDogDetailViewController.SelectedHotDog = item;
			//	}
			//}
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