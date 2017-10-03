using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreditForm.Model;

namespace CreditForm
{
    public partial class Kardex : Form
    {
        CREDIT selectedCredit;
        public Kardex(CREDIT selectedCredit)
        {
            InitializeComponent();
            fillKardex(selectedCredit);
        }

        private void fillKardex(CREDIT selectedCredit)
        {
            this.selectedCredit = selectedCredit;
            dgwKardex.DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwKardex.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgwKardex.ColumnCount = 5;
            dgwKardex.Columns[0].Name = "Months";
            dgwKardex.Columns[1].Name = "Monthly PR payment";
            dgwKardex.Columns[2].Name = "Monthly Int payment";
            dgwKardex.Columns[3].Name = "Monthly Total payment";
            dgwKardex.Columns[4].Name = "Outstanding balance";

            int months = Convert.ToInt32(selectedCredit.TERM);
            double outBalance = Convert.ToDouble(selectedCredit.DISBURSEMENT);
            double prPay = Convert.ToDouble(outBalance / months);
            double sumInterest = 0;
            for (int i=1;i<=months; i++)
            {
                double intPay = Convert.ToDouble(outBalance * selectedCredit.INTEREST_RATE / 100 / 12);
                sumInterest += intPay;
                double totPay = prPay + intPay;
                outBalance -= prPay;
                dgwKardex.Rows.Add(i, String.Format("{0:n}", Math.Round(prPay,2)), String.Format("{0:n}", Math.Round(intPay,2)), String.Format("{0:n}", Math.Round(totPay,2)), String.Format("{0:n}", Math.Round(outBalance,2)));
            }
            dgwKardex.Rows.Add("Total", String.Format("{0:n}",Math.Round(Convert.ToDouble(selectedCredit.DISBURSEMENT), 2)), String.Format("{0:n}", Math.Round(sumInterest,2)), String.Format("{0:n}", Math.Round(sumInterest + Convert.ToDouble(selectedCredit.DISBURSEMENT), 2)), "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Kardex";
            for (int i = 1; i < dgwKardex.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgwKardex.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgwKardex.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgwKardex.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgwKardex.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.SaveAs("C:\\Users\\samir.dadash-zada\\Desktop\\Kardex"+ selectedCredit.NAME + selectedCredit.ID + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
        }
    }
}
