using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace XamarinAndroidApp
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button calculateButton;
        EditText ammountText;
        TextView tipText;
        TextView totalText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            calculateButton = FindViewById<Button>(Resource.Id.buttonCalculate);
            ammountText = FindViewById<EditText>(Resource.Id.editTextAmmount);
            tipText = FindViewById<TextView>(Resource.Id.textViewTip);
            totalText = FindViewById<TextView>(Resource.Id.textViewTotal);
            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            var ammount = 0;
            if (!string.IsNullOrEmpty(ammountText.Text) && int.TryParse(ammountText.Text, out ammount))
            {

                tipText.Text = (ammount*0.15).ToString();
                totalText.Text = (ammount*1.15).ToString();
            }
            else
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Incorrect ammount");

                alert.SetPositiveButton("OK", (senderAlert, args) => {
                    //change value write your own set of instructions
                    //you can also create an event for the same in xamarin
                    //instead of writing things here
                });
                //run the alert in UI thread to display in the screen
                RunOnUiThread(() => {
                    alert.Show();
                });

            }

        }
    }
}

