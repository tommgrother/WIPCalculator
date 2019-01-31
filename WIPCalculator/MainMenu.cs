using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace WIPCalculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionStrings.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("usp_calc_wip", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtPunchedNotWelded.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["PunchNotWeldValue"]);
                txtWeldedNotBuffedBase.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["WeldNotBuffBaseMaterial"]);
                txtBuffedNotPaintedBase.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["BuffNotPaintBaseMaterial"]);
                txtPaintedNotPackedBase.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["PaintNotPackBaseMaterial"]);
                txtPackNotInvoiceBase.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["PackNotInvoiceBaseMaterial"]);

                txtQtyHingeBrackets.Text = reader["HingeBracketryWeld"].ToString();
                txtHingeBracketCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["HingeBracketPrice"]);
                txtQtyLockBrackets.Text = reader["LockBracketryWeld"].ToString();
                txtLockBracketCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["LockBracketPrice"]);

                //Infill types
                txtQtyDufaylite.Text = reader["DufayliteCount"].ToString();
                txtQtyRockwool.Text  =reader["RockwoolCount"].ToString();
                txtQuantityCelotex.Text =reader["CelotexCount"].ToString();
                txtQtyWoodCore.Text = reader["WoodcoreCount"].ToString();

                txtLDufayliteCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["DufayliteCost"]);
                txtRockwoolCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["RockwoolCost"]);
                txtCelotexCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["CelotexCost"]);
                txtWoodCoreCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["WoodcoreCost"]);

                //Bracketry

                txtQtyFloodBracketry.Text = reader["FloodBracketryCount"].ToString();
                txtFloodBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["FloodBracketryCost"]);

                txtQtySR1Bracketry.Text = reader["SR1BracketryCount"].ToString();
                txtSR1BracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR1BracketryCost"]);

                txtQtySR2PanicBracketry.Text = reader["SR2PanicBracketryCount"].ToString();
                txtSR2PanicBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR2PanicBracketryCost"]);
                txtQtySR2MorticeBracketry.Text = reader["SR2MorticeBracketryCount"].ToString();
                txtSR2MorticeBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR2MorticeBracketryCost"]);

                txtQtySR3PanicBracketry.Text = reader["SR3PanicBracketryCount"].ToString();
                txtSR3PanicBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR3PanicBracketryCost"]);
                txtQtySR3MorticeBracketry.Text = reader["SR3MorticeBracketryCount"].ToString();
                txtSR3MorticeBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR3MorticeBracketryCost"]);
                txtSR3MorticeBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR3MorticeBracketryCost"]);
                txtSR3MorticeBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SR3MorticeBracketryCost"]);

                txtQtyFRBracketry.Text = reader["FireRatedBracketryCount"].ToString();
                txtFRBracketryCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["FireRatedBracketryCost"]);


                txtQtyTopHats.Text = reader["TopHatCount"].ToString();
                txtQtyFlatHats.Text = reader["FlatHatCount"].ToString();
                txtTopHatCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["TopHatCost"]);
                txtFlatHatCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["FlatHatCost"]);


                //Labour Hours

                txtPunchHours.Text = reader["PunchLabourHours"].ToString();
                txtBendHours.Text = reader["BendLabourHours"].ToString();
                txtWeldHours.Text = reader["WeldLabourHours"].ToString();
                txtBuffHours.Text = reader["BuffLabourHours"].ToString();
                txtPaintHours.Text = reader["PaintLabourHours"].ToString();
                txtPackHours.Text = reader["PackLabourHours"].ToString();
                txtAveragePunchSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AveragePunchSalary"]);
                txtAverageBendSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AverageBendSalary"]);
                txtAverageWeldSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AverageWeldSalary"]);
                txtAverageBuffSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AverageBuffSalary"]);
                txtAveragePaintSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AveragePaintSalary"]);
                txtAveragePackSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["AveragePackSalary"]);
                txtTotalLabour.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["TotalLabourCost"]);

                //Total Doors

                txtTotalDoors.Text = reader["TotalDoors"].ToString();


                txtHardwareValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["HardwareValue"]);

                txtTotalPaintValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["TotalPaintValue"]);

                txtWeldExtrasWeld.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["WeldExtrasWeld"]);

                txtTotalWip.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["totalWIP"]);




            }

            con.Close();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}