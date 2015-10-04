using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace TableViewMailBox
{
    partial class TableViewController : UITableViewController
    {
        EmailServer emailServer = new EmailServer();

        public TableViewController (IntPtr handle) : base (handle)
        {
        }
        //Getting the number of rows
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }
        //Accessing cells
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(CGRect.Empty);
            var emailItem = emailServer.Email[indexPath.Row];

            cell.TextLabel.Text = emailItem.Subject;
           // cell.DetailTextLabel.Text = emailItem.Body;
            if (cell.ImageView != null)
                cell.ImageView.Image = emailItem.GetImage();
            cell.TextLabel.TextColor = UIColor.Blue;
            //cell.DetailTextLabel.TextColor = UIColor.Gray;
            //Displaying disclosure(arrow)
            // cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
            return cell;
        }
        //Whent the Accessory Button is tapped
        public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            var emailItem = emailServer.Email[indexPath.Row];
            var controller = UIAlertController.Create(emailItem.Subject, emailItem.Body, UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("OK",
                    UIAlertActionStyle.Default, null));
            PresentViewController(controller, true,null);
        }

        //Selecting the Rows and displaying detail view controller
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var emailItem = emailServer.Email[indexPath.Row];
            var storyboard = UIStoryboard.FromName("Main",null);
            var detailViewController = storyboard.InstantiateViewController("DetailsViewController") as DetailsViewController;
            detailViewController.Item = emailItem;
            PresentViewController(detailViewController, true, null);
        }
    }
}
