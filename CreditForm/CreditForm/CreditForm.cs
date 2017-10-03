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
    public partial class CreditForm : Form
    {
        CreditEntities db = new CreditEntities();
        public static CREDIT selectedCredit;
        public CreditForm()
        {
            InitializeComponent();
            fillComboTypes();
            fillGrid();
        }

        private void fillComboTypes()
        {
            cmbType.Text = "Select credit type...";
            var ct = db.CREDIT_TYPES.Select(c => c.NAME).ToArray<string>();
            cmbType.Items.AddRange(ct);
        }

        private void fillGrid()
        {
            dgwCredits.DataSource = db.CREDITS.Select(c => new {
                ID = c.ID,
                Username = c.NAME,
                Disbursment = c.DISBURSEMENT,
                Commission = c.COMMISSION,
                Interest = c.INTEREST_RATE,
                Term = c.TERM,
                Credit_Type = c.CREDIT_TYPES.NAME }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Amount = txtAmount.Text;
            string Commission = txtCom.Text;
            string Rate = txtRate.Text;
            string Term = txtTerm.Text;
            string Type = cmbType.Text;

            if (Name != "" && Amount != "" && Commission != "" && Rate != "" && Type != "Select credit type..." && Term != "")
            {
                CREDIT cr = new CREDIT()
                {
                    NAME = Name,
                    DISBURSEMENT = Convert.ToInt32(Amount),
                    COMMISSION = Convert.ToInt32(Commission),
                    INTEREST_RATE = Convert.ToInt32(Rate),
                    TERM = Convert.ToInt32(Term),
                    CREDIT_TYPE = db.CREDIT_TYPES.FirstOrDefault(c => c.NAME == Type).ID
                };
                db.CREDITS.Add(cr);
                db.SaveChanges();
                clearCreditForm();

            }
            else
            {
                MessageBox.Show("Please, fill in all fields!");
            }
        }

        private void clearCreditForm()
        {
            txtName.Text = "";
            txtAmount.Text = "";
            txtCom.Text = "";
            txtRate.Text = "";
            txtTerm.Text = "";
            cmbType.Text = "Select credit type...";
            fillGrid();
        }

        private void selectRow(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Id = Convert.ToInt32(dgwCredits.Rows[e.RowIndex].Cells[0].Value);
            selectedCredit = db.CREDITS.FirstOrDefault(c => c.ID == Id);
            Kardex krd = new Kardex(selectedCredit);
            krd.Show();
        }

        private void CreditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
