using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.App.ActionBar;

namespace CustomPopupLayout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnshowPopup;
        private Button btnPopupCancel;
        private Button btnPopOk;
        private Dialog rescheduleDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnshowPopup = FindViewById<Button>(Resource.Id.btnPopup);
            btnshowPopup.Click += BtnshowPopup_Click; ;

        }

        private void BtnshowPopup_Click(object sender, System.EventArgs e)
        {
            rescheduleDialog = new Dialog(this);
            rescheduleDialog.Window.SetTitle("Alert Title");
            rescheduleDialog.SetContentView(Resource.Layout.activity_main);
            rescheduleDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            rescheduleDialog.Show();

            // Some Time Layout width not fit with windows size
            // but Below lines are not necessery
            rescheduleDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            rescheduleDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);

            // Access Popup layout fields like below
            btnPopupCancel = rescheduleDialog.FindViewById<Button>(Resource.Id.btnCancel);
            btnPopOk = rescheduleDialog.FindViewById<Button>(Resource.Id.btnOk);

            // Events for that popup layout
            btnPopupCancel.Click += BtnPopupCancel_Click;
            btnPopOk.Click += BtnPopOk_Click;

        }

        private void BtnPopOk_Click(object sender, System.EventArgs e)
        {
            rescheduleDialog.Dismiss();
            rescheduleDialog.Hide();
        }

        private void BtnPopupCancel_Click(object sender, System.EventArgs e)
        {
            rescheduleDialog.Dismiss();
            rescheduleDialog.Hide();
        }
    }
}