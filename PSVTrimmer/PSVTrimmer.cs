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
            fdInput.Filter = "PSV images (*.psv)|*.psv";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fdInput.FileOk += inputFileSelected;
            fdInput.ShowDialog();
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            fdInput.FileOk += outputFileSelected;
            fdInput.ShowDialog();
        }

        private void inputFileSelected(object sender, CancelEventArgs e)
        {
            txtInput.Text = fdInput.FileName;
            fdInput.FileOk -= inputFileSelected;
        }

        private void outputFileSelected(object sender, CancelEventArgs e)
        {
            txtOutput.Text = fdInput.FileName;
            fdInput.FileOk -= outputFileSelected;
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            Trim(txtInput.Text, txtOutput.Text);
        }
    }
}
