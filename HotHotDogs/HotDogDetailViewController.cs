using Foundation;
using System;
using UIKit;
using RaysHotDogs.Core;

namespace HotHotDogs
{
    public partial class HotDogDetailViewController : UIViewController
    {
		public HotDog SelectedHotDog {
			get; set;
		}

        public HotDogDetailViewController (IntPtr handle) : base (handle)
        {
			HotDogDataService hotDogDataService = new HotDogDataService();
			SelectedHotDog = hotDogDataService.GetHotDogById(1);
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DatabindUI();

			AddToCartButton.TouchUpInside += (object sender, EventArgs e) => {
				UIAlertView message = new UIAlertView("HOT HOT DOGS", "That hot dog is added to your order.", null, "OK", null);
				message.Show();
			};
		}

		private void DatabindUI() {
			UIImage img = UIImage.FromFile("Images/" + SelectedHotDog.ImagePath + ".jpg");
			HotDogImageView.Image = img;
			Name.Text = SelectedHotDog.Name;
			ShortDescriptionLabel.Text = SelectedHotDog.ShortDescription;
			LongDescription.Text = SelectedHotDog.Description;
			PriceLabel.Text = "$" + SelectedHotDog.Price.ToString();
		}
    }
}