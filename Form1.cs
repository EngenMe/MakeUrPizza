using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeUrPizza
{
    public partial class frmMain : Form
    {
        // Constructor to initialize the form components
        public frmMain()
        {
            InitializeComponent();
        }

        // Method to update the selected pizza size label
        void UpdateSize()
        {
            lblSize.Text = "Size:     ";
            if (rbSmall.Checked)
            {
                lblSize.Text += "Small";
                return;
            }
            if (rbMedium.Checked)
            {
                lblSize.Text += "Medium";
                return;
            }
            if (rbLarge.Checked)
            {
                lblSize.Text += "Large";
                return;
            }
        }

        // Method to get the price of the selected pizza size
        float SizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else if (rbLarge.Checked)
                return Convert.ToSingle(rbLarge.Tag);
            else
                return 0;
        }

        // Method to calculate the total price of selected toppings
        float TroppingsPrice()
        {
            float troppings_price = 0;
            if (cbExtraChees.Checked)
                troppings_price += Convert.ToSingle(cbExtraChees.Tag);
            if (cbMushrooms.Checked)
                troppings_price += Convert.ToSingle(cbMushrooms.Tag);
            if (cbTomatos.Checked)
                troppings_price += Convert.ToSingle(cbTomatos.Tag);
            if (cbOnion.Checked)
                troppings_price += Convert.ToSingle(cbOnion.Tag);
            if (cbOlives.Checked)
                troppings_price += Convert.ToSingle(cbOlives.Tag);
            if (cbPepper.Checked)
                troppings_price += Convert.ToSingle(cbPepper.Tag);

            return troppings_price;
        }

        // Method to get the price of the selected crust type
        float CrustPrice()
        {
            if (rbThick.Checked)
                return 5;

            return 0;
        }

        // Method to calculate the total price of the pizza
        float CalculateTotalPrice()
        {
            return SizePrice() + TroppingsPrice() + CrustPrice();
        }

        // Method to update the total price label
        void UpdatePrice()
        {
            lblTotalPrice.Text = "Total Price: " + CalculateTotalPrice() + "€";
        }

        // Method to enable the order button if all required selections are made
        void UpdateEnablingOrder()
        {
            short enabling_score = 0;

            if (rbSmall.Checked || rbMedium.Checked || rbLarge.Checked)
                enabling_score += 1;
            if (rbThin.Checked || rbThick.Checked)
                enabling_score += 1;
            if (rbHere.Checked || rbTakeAway.Checked)
                enabling_score += 1;

            if (enabling_score == 3)
                btnOrder.Enabled = true;
        }

        // Method to update the crust type label
        void UpdateCrustType()
        {
            lblCrustType.Text = "Crust Type:    ";
            lblCrustType.Text += (rbThin.Checked ? "Thin" : "Thick");
        }

        // Method to update the label indicating where to eat
        void UpdateWhereToEat()
        {
            lblWhereToEat.Text = "Where To Eat:    ";
            lblWhereToEat.Text += (rbHere.Checked ? "Here" : "Take Away");
        }

        // Method to update the selected toppings label
        void UpdateTroppings()
        {
            lblTroppings.Text = "Troppings:\n";

            if (cbExtraChees.Checked)
                lblTroppings.Text += "Extra Chees\n";
            if (cbMushrooms.Checked)
                lblTroppings.Text += "Mushrooms\n";
            if (cbTomatos.Checked)
                lblTroppings.Text += "Tomatoes\n";
            if (cbOnion.Checked)
                lblTroppings.Text += "Onion\n";
            if (cbOlives.Checked)
                lblTroppings.Text += "Olives\n";
            if (cbPepper.Checked)
                lblTroppings.Text += "Pepper\n";
        }

        // Method to disable all selection group boxes
        void DisableBoxs()
        {
            gbxSize.Enabled = false;
            gbxCrustType.Enabled = false;
            gbxTroppings.Enabled = false;
            gbxWhereToEat.Enabled = false;
        }

        // Method to reset the form to its default state
        void ResetToDefault()
        {
            gbxSize.Enabled = true;
            gbxCrustType.Enabled = true;
            gbxTroppings.Enabled = true;
            gbxWhereToEat.Enabled = true;

            btnOrder.Enabled = false;

            cbExtraChees.Checked = false;
            cbMushrooms.Checked = false;
            cbTomatos.Checked = false;
            cbOnion.Checked = false;
            cbOlives.Checked = false;
            cbPepper.Checked = false;

            rbSmall.Checked = false;
            rbMedium.Checked = false;
            rbLarge.Checked = false;

            rbThin.Checked = false;
            rbThick.Checked = false;

            rbHere.Checked = false;
            rbTakeAway.Checked = false;

            lblSize.Text = "Size: ";
            lblTroppings.Text = "Troppings: ";
            lblCrustType.Text = "Crust Type: ";
            lblWhereToEat.Text = "Where To Eat: ";
            lblTotalPrice.Text = "Total Price: ";
        }

        // Event handlers for radio button and checkbox changes
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdatePrice();
            UpdateEnablingOrder();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdatePrice();
            UpdateEnablingOrder();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdatePrice();
            UpdateEnablingOrder();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateEnablingOrder();
            UpdateCrustType();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateEnablingOrder();
            UpdateCrustType();
        }

        private void rbHere_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnablingOrder();
            UpdateWhereToEat();
        }

        private void rbTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnablingOrder();
            UpdateWhereToEat();
        }

        private void cbExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        private void cbTomatos_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        private void cbPepper_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
            UpdateTroppings();
        }

        // Event handler for the order button click
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Check Out", "Confirm :)", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Your Order is on the Way!", "Order Placed", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                DisableBoxs();
            }
        }

        // Event handler for the reset button click
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel Order :(", "Reset", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show("Order Cancelled", "Cancell!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                ResetToDefault();
            }
        }
    }
}
