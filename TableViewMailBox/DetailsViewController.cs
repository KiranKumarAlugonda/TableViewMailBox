using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TableViewMailBox
{
	partial class DetailsViewController : UIViewController
	{
		public DetailsViewController (IntPtr handle) : base (handle)
		{
		}
        EmailItem item;
        public EmailItem Item
        {
            get{
                return item;
            }
            set{ 
                item = value;
                UpdateItem();
            }
        }
        //Checking whether the items are getting ot not
        void UpdateItem()
        {
            if (EmailText != null)
            {
                EmailText.Text = Item != null ? Item.ToString() : "";
            }
        }
        //Loading the items before the view appears
        public override void ViewWillAppear(bool animated)
        {
            UpdateItem();
        }
        //Back Button dismiss the screen through code.
//        partial void OnDismiss(UIButton sender)
//        {
//            this.DismissViewController (true, null);
//        }


	}
}
