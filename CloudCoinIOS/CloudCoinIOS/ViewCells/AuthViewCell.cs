// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace CloudCoinIOS
{
	public partial class AuthViewCell : UITableViewCell
	{
		public AuthViewCell (IntPtr handle) : base (handle)
		{
		}

		public AuthViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {

		}

        public void UpdateCell(Coin4Display coin)
        {
            lblSerial.Text = coin.Serial.ToString();
            lblValue.Text = coin.Value.ToString();
            lblAuthenticated.Text = coin.Check ? "True" : "False";
            lblPercent.Text = coin.Comment;
        }
	}
}
