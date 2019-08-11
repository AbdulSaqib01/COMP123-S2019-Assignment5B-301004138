﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Assignment5B_301004138.Views
{
    public partial class ProductInfoForm : Form
    {
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is event handler for NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            Program.Forms[FormName.ORDER_FORM].Show();
            this.Hide();
        }

        /// <summary>
        /// This is event handler for CancelButton Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel? Your order will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// This is event handler for CancelButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductInfoForm_Load(object sender, EventArgs e)
        {
            ProductIDDataLabel.Text = Program.product.productID.ToString();
            CostDataLabel.Text = Program.product.cost.ToString();
            CostDataLabel.Text = string.Format("{0:C2}", decimal.Parse(CostDataLabel.Text));
            ManufacturerDataLabel.Text = Program.product.manufacturer.ToString();
            ModelDataLabel.Text = Program.product.model.ToString();
            ConditionDataLabel.Text = Program.product.condition.ToString();
            PlatformDataLabel.Text = Program.product.platform.ToString();
            OSDataLabel.Text = Program.product.OS.ToString();
            MemoryDataLabel.Text = Program.product.RAM_size.ToString();
            LCDSizeDataLabel.Text = Program.product.screensize.ToString();
            HDDDataLabel.Text = Program.product.HDD_size.ToString();
            CPUBrandDataLabel.Text = Program.product.CPU_brand;
            CPUNumberDataLabel.Text = Program.product.CPU_number;
            GPUTypeDataLabel.Text = Program.product.GPU_Type;
            CPUTypeDataLabel.Text = Program.product.CPU_type;
            CPUSpeedDataLabel.Text = Program.product.CPU_speed;
            WebCamDataLabel.Text = Program.product.webcam;
        }

        /// <summary>
        /// This is event handler for saveToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductSaveFileDialog.FileName = "Hardware.txt";
            ProductSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ProductSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            var resultFile = ProductSaveFileDialog.ShowDialog();
            if (resultFile != DialogResult.Cancel)
            {
                // This will open up the file dialog
                using (StreamWriter output = new StreamWriter(File.Open(ProductSaveFileDialog.FileName, FileMode.Create)))
                {
                    // writing up data to the file
                    output.WriteLine(Program.product.productID.ToString());
                    output.WriteLine(Program.product.cost);
                    output.WriteLine(Program.product.manufacturer);
                    output.WriteLine(Program.product.model);
                    output.WriteLine(Program.product.condition);
                    output.WriteLine(Program.product.platform);
                    output.WriteLine(Program.product.OS);
                    output.WriteLine(Program.product.RAM_size);
                    output.WriteLine(Program.product.screensize);
                    output.WriteLine(Program.product.HDD_size);
                    output.WriteLine(Program.product.CPU_brand);
                    output.WriteLine(Program.product.CPU_number);
                    output.WriteLine(Program.product.GPU_Type);
                    output.WriteLine(Program.product.CPU_type);
                    output.WriteLine(Program.product.CPU_speed);
                    output.WriteLine(Program.product.webcam);

                    // cleaning up!
                    output.Close();
                    output.Dispose();

                    MessageBox.Show("File Have Been Saved Successfully!", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// This is event handler for openToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductOpenFileDialog.FileName = "Harware.txt";
            ProductOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ProductOpenFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            var resultFile = ProductOpenFileDialog.ShowDialog();
            if (resultFile != DialogResult.Cancel)
            {
                try
                {
                    using (StreamReader input = new StreamReader(File.Open(ProductOpenFileDialog.FileName, FileMode.Open)))
                    {
                        Program.product.productID = short.Parse(input.ReadLine());
                        Program.product.cost = decimal.Parse(input.ReadLine());
                        Program.product.manufacturer = input.ReadLine();
                        Program.product.model = input.ReadLine();
                        Program.product.condition = input.ReadLine();
                        Program.product.platform = input.ReadLine();
                        Program.product.OS = input.ReadLine();
                        Program.product.RAM_size = input.ReadLine();
                        Program.product.screensize = input.ReadLine();
                        Program.product.HDD_size = input.ReadLine();
                        Program.product.CPU_brand = input.ReadLine();
                        Program.product.CPU_number = input.ReadLine();
                        Program.product.GPU_Type = input.ReadLine();
                        Program.product.CPU_type = input.ReadLine();
                        Program.product.CPU_speed = input.ReadLine();
                        Program.product.webcam = input.ReadLine();

                        input.Close();
                        input.Dispose();
                    }
                }
                catch (IOException error)
                {

                    MessageBox.Show($"ERROR: {error.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException errorFormat)
                {
                    MessageBox.Show($"ERROR: {errorFormat.Message} \n\nPlease select the correct file type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ProductInfoForm_Load(sender,e);
        }

        /// <summary>
        /// This is event handler for SelectAnotherPoductButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAnotherProductButton_Click(object sender, EventArgs e)
        {
            Program.Forms[FormName.SELECT_FORM].Show();
            //ProductInfoForm_Load(sender, e);
            this.Hide();
        }
    }
}
