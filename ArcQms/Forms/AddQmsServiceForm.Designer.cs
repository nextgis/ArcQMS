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
            this.lbQmsServices = new System.Windows.Forms.ListBox();
            this.tbfilterServices = new System.Windows.Forms.TextBox();
            this.btnAddQmsService = new System.Windows.Forms.Button();
            this.wbQmsService = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lbQmsServices
            // 
            this.lbQmsServices.FormattingEnabled = true;
            resources.ApplyResources(this.lbQmsServices, "lbQmsServices");
            this.lbQmsServices.Name = "lbQmsServices";
            this.lbQmsServices.SelectedIndexChanged += new System.EventHandler(this.lbQmsServices_SelectedIndexChanged);
            // 
            // tbfilterServices
            // 
            resources.ApplyResources(this.tbfilterServices, "tbfilterServices");
            this.tbfilterServices.Name = "tbfilterServices";
            this.tbfilterServices.TextChanged += new System.EventHandler(this.tbfilterServices_TextChanged);
            // 
            // btnAddQmsService
            // 
            this.btnAddQmsService.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnAddQmsService, "btnAddQmsService");
            this.btnAddQmsService.Name = "btnAddQmsService";
            this.btnAddQmsService.UseVisualStyleBackColor = true;
            this.btnAddQmsService.Click += new System.EventHandler(this.button1_Click);
            // 
            // wbQmsService
            // 
            this.wbQmsService.AllowWebBrowserDrop = false;
            this.wbQmsService.CausesValidation = false;
            this.wbQmsService.IsWebBrowserContextMenuEnabled = false;
            resources.ApplyResources(this.wbQmsService, "wbQmsService");
            this.wbQmsService.Name = "wbQmsService";
            this.wbQmsService.ScriptErrorsSuppressed = true;
            this.wbQmsService.Url = new System.Uri("https://qms.nextgis.com/geoservices/464/", System.UriKind.Absolute);
            this.wbQmsService.WebBrowserShortcutsEnabled = false;
            // 
            // AddQmsService
            // 
            this.AcceptButton = this.btnAddQmsService;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbQmsService);
            this.Controls.Add(this.btnAddQmsService);
            this.Controls.Add(this.tbfilterServices);
            this.Controls.Add(this.lbQmsServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddQmsService";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbQmsServices;
        private System.Windows.Forms.TextBox tbfilterServices;
        private System.Windows.Forms.Button btnAddQmsService;
        private System.Windows.Forms.WebBrowser wbQmsService;
    }
}