using System.Windows.Forms;

namespace ArcQms.Forms
{
    partial class AddQmsServiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddQmsServiceForm));
            this.wpfAddQmsService = new System.Windows.Forms.Integration.ElementHost();
            this.addQmsServiceControl1 = new ArcQms.Forms.AddQmsServiceControl();
            this.SuspendLayout();
            // 
            // wpfAddQmsService
            // 
            resources.ApplyResources(this.wpfAddQmsService, "wpfAddQmsService");
            this.wpfAddQmsService.Name = "wpfAddQmsService";
            this.wpfAddQmsService.Child = this.addQmsServiceControl1;
            // 
            // AddQmsServiceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wpfAddQmsService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddQmsServiceForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost wpfAddQmsService;
        private AddQmsServiceControl addQmsServiceControl1;
    }
}