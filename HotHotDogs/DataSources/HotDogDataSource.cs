using System;
using System.Collections.Generic;
using Foundation;
using RaysHotDogs.Core;
using UIKit;

namespace HotHotDogs
{
	public class HotDogDataSource : UITableViewSource
	{
		private List<HotDog> hotDogs;
		NSString cellIdentifier = new NSString("HotDogCell");

		UITableViewController callingController;

		public HotDogDataSource(List<HotDog> hotDogs, UITableViewController callingController)
		{
			this.hotDogs = hotDogs;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return hotDogs.Count; 
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;

			//if (cell == null) {
			//	cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			//}

			//var hotDog = hotDogs[indexPath.Row];
			//cell.TextLabel.Text = hotDog.Name;
			//cell.ImageView.Image = UIImage.FromFile("Images/hotdog" + hotDog.HotDogId + ".jpg");

			//return cell;
			HotDogListCell cell = tableView.DequeueReusableCell(cellIdentifier) as HotDogListCell;

			if (cell == null)
				cell = new HotDogListCell(cellIdentifier);
			
			cell.UpdateCell(hotDogs[indexPath.Row].Name
							, hotDogs[indexPath.Row].Price.ToString()
			                , UIImage.FromFile("Images/hotdog" + hotDogs[indexPath.Row].HotDogId + ".jpg") );
			return cell;
		}

		public HotDog GetItem(int id) {
				return hotDogs[id];
		}

		//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		//{
		//	var selectedHotDog = this.hotDogs[indexPath.Row];

		//	var favoritesController = callingController as FavoritesViewController;

		//	if (favoritesController != null) {
		//		favoritesController.HotDogSelected(selectedHotDog);
		//		tableView.DeselectRow(indexPath, true);
		//		return;
		//	}

		//	var meatLoversController = callingController as MeatLoversViewController;

		//	if (meatLoversController != null)
		//	{
		//		meatLoversController.HotDogSelected(selectedHotDog);
		//		tableView.DeselectRow(indexPath, true);
		//		return;
		//	}

		//	var veggieLoversController = callingController as VeggieLoversViewController;

		//	if (veggieLoversController != null)
		//	{
		//		veggieLoversController.HotDogSelected(selectedHotDog);
		//		tableView.DeselectRow(indexPath, true);
		//		return;
		//	}
		//}
	}
}