using System;

using UIKit;
using Foundation;
using CoreGraphics;

namespace TableViewMailBox
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }
        UITableView tableView;
        class EmailServerDataSource : UITableViewDataSource
        {
            EmailServer emailServer = new EmailServer();

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return emailServer.Email.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Value1,null);
                var item = emailServer.Email[indexPath.Row];

                //cell.TextLabel.Text = item.Subject;
                cell.TextLabel.Text = item.Subject.Substring(0,20)+ "...";
                cell.DetailTextLabel.Text = item.Body;
                if(cell.ImageView != null)
                   cell.ImageView.Image = item.GetImage();
                cell.TextLabel.TextColor = UIColor.Blue;
                cell.DetailTextLabel.TextColor = UIColor.Gray;
                cell.Accessory = UITableViewCellAccessory.Checkmark;
                return cell;
            }
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            tableView = new UITableView(this.View.Frame);

            tableView.DataSource = new EmailServerDataSource();

            this.View.Add(tableView);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

