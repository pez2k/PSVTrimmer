using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PSVTrimmer
{
    public partial class PSVTrimmer : Form
    {
        public PSVTrimmer()
        {
            InitializeComponent();
            fdInput.FileOk += inputFileSelected;
            fdInput.Filter = "PSV images (*.psv)|*.psv";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fdInput.ShowDialog();
        }

        private void inputFileSelected(object sender, CancelEventArgs e)
        {
            txtInput.Text = fdInput.FileName;
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            Trim(txtInput.Text);
        }
    }
}
