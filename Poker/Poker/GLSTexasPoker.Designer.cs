using System.ComponentModel;
using System.Windows.Forms;

namespace Poker
{
    partial class GLSTexasPoker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLSTexasPoker));
            this.GameUpdate = new System.Windows.Forms.Timer(this.components);
            this.RotateTimer = new System.Windows.Forms.Timer(this.components);
            this.tbRaise = new System.Windows.Forms.TextBox();
            this.potLabel = new System.Windows.Forms.Label();
            this.playerStatusLabel = new System.Windows.Forms.Label();
            this.Bot1StatusLabel = new System.Windows.Forms.Label();
            this.Bot3StatusLabel = new System.Windows.Forms.Label();
            this.Bot2StatusLabel = new System.Windows.Forms.Label();
            this.Bot5StatusLabel = new System.Windows.Forms.Label();
            this.bigBlindSum = new System.Windows.Forms.TextBox();
            this.smallBlindButton = new System.Windows.Forms.Button();
            this.smallBlindSum = new System.Windows.Forms.TextBox();
            this.bigBlindButton = new System.Windows.Forms.Button();
            this.potChips = new System.Windows.Forms.TextBox();
            this.Bot4StatusLabel = new System.Windows.Forms.Label();
            this.numberOfChipsToAdd = new System.Windows.Forms.TextBox();
            this.addChipsButton = new System.Windows.Forms.Button();
            this.progressBarTimer = new System.Windows.Forms.ProgressBar();
            this.raiseButton = new System.Windows.Forms.Button();
            this.callButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.foldButton = new System.Windows.Forms.Button();
            this.Bot4Chips = new System.Windows.Forms.TextBox();
            this.Bot3Chips = new System.Windows.Forms.TextBox();
            this.Bot2Chips = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GameUpdate
            // 
            this.GameUpdate.Tick += new System.EventHandler(this.GameUpdate_Tick);
            // 
            // RotateTimer
            // 
            this.RotateTimer.Tick += new System.EventHandler(this.RotateTimer_Tick);
            // 
            // tbRaise
            // 
            this.tbRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbRaise.Location = new System.Drawing.Point(774, 622);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(118, 20);
            this.tbRaise.TabIndex = 0;
            this.tbRaise.TextChanged += new System.EventHandler(this.tbRaise_TextChanged);
            // 
            // potLabel
            // 
            this.potLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potLabel.Location = new System.Drawing.Point(654, 203);
            this.potLabel.Name = "potLabel";
            this.potLabel.Size = new System.Drawing.Size(31, 21);
            this.potLabel.TabIndex = 0;
            this.potLabel.Text = "Pot";
            // 
            // playerStatusLabel
            // 
            this.playerStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerStatusLabel.Location = new System.Drawing.Point(771, 664);
            this.playerStatusLabel.Name = "playerStatusLabel";
            this.playerStatusLabel.Size = new System.Drawing.Size(120, 27);
            this.playerStatusLabel.TabIndex = 30;
            // 
            // Bot1StatusLabel
            // 
            this.Bot1StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bot1StatusLabel.Location = new System.Drawing.Point(49, 650);
            this.Bot1StatusLabel.Name = "Bot1StatusLabel";
            this.Bot1StatusLabel.Size = new System.Drawing.Size(142, 22);
            this.Bot1StatusLabel.TabIndex = 29;
            // 
            // Bot3StatusLabel
            // 
            this.Bot3StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot3StatusLabel.Location = new System.Drawing.Point(944, -185);
            this.Bot3StatusLabel.Name = "Bot3StatusLabel";
            this.Bot3StatusLabel.Size = new System.Drawing.Size(95, 32);
            this.Bot3StatusLabel.TabIndex = 28;
            // 
            // Bot2StatusLabel
            // 
            this.Bot2StatusLabel.Location = new System.Drawing.Point(-98, -185);
            this.Bot2StatusLabel.Name = "Bot2StatusLabel";
            this.Bot2StatusLabel.Size = new System.Drawing.Size(109, 32);
            this.Bot2StatusLabel.TabIndex = 31;
            // 
            // Bot5StatusLabel
            // 
            this.Bot5StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot5StatusLabel.Location = new System.Drawing.Point(1335, 562);
            this.Bot5StatusLabel.Name = "Bot5StatusLabel";
            this.Bot5StatusLabel.Size = new System.Drawing.Size(152, 32);
            this.Bot5StatusLabel.TabIndex = 26;
            // 
            // bigBlindSum
            // 
            this.bigBlindSum.Location = new System.Drawing.Point(293, 258);
            this.bigBlindSum.Name = "bigBlindSum";
            this.bigBlindSum.Size = new System.Drawing.Size(75, 20);
            this.bigBlindSum.TabIndex = 19;
            this.bigBlindSum.Text = "500";
            // 
            // smallBlindButton
            // 
            this.smallBlindButton.Location = new System.Drawing.Point(293, 174);
            this.smallBlindButton.Name = "smallBlindButton";
            this.smallBlindButton.Size = new System.Drawing.Size(75, 23);
            this.smallBlindButton.TabIndex = 18;
            this.smallBlindButton.Text = "Small Blind";
            this.smallBlindButton.UseVisualStyleBackColor = true;
            this.smallBlindButton.Click += new System.EventHandler(this.bSB_Click);
            // 
            // smallBlindSum
            // 
            this.smallBlindSum.Location = new System.Drawing.Point(293, 203);
            this.smallBlindSum.Name = "smallBlindSum";
            this.smallBlindSum.Size = new System.Drawing.Size(75, 20);
            this.smallBlindSum.TabIndex = 17;
            this.smallBlindSum.Text = "250";
            // 
            // bigBlindButton
            // 
            this.bigBlindButton.Location = new System.Drawing.Point(293, 229);
            this.bigBlindButton.Name = "bigBlindButton";
            this.bigBlindButton.Size = new System.Drawing.Size(75, 23);
            this.bigBlindButton.TabIndex = 16;
            this.bigBlindButton.Text = "Big Blind";
            this.bigBlindButton.UseVisualStyleBackColor = true;
            this.bigBlindButton.Click += new System.EventHandler(this.bBB_Click);
            // 
            // potChips
            // 
            this.potChips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potChips.Location = new System.Drawing.Point(610, 229);
            this.potChips.Name = "potChips";
            this.potChips.ReadOnly = true;
            this.potChips.Size = new System.Drawing.Size(125, 23);
            this.potChips.TabIndex = 14;
            this.potChips.Text = "0";
            // 
            // Bot4StatusLabel
            // 
            this.Bot4StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot4StatusLabel.Location = new System.Drawing.Point(1403, -185);
            this.Bot4StatusLabel.Name = "Bot4StatusLabel";
            this.Bot4StatusLabel.Size = new System.Drawing.Size(73, 32);
            this.Bot4StatusLabel.TabIndex = 27;
            // 
            // numberOfChipsToAdd
            // 
            this.numberOfChipsToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfChipsToAdd.Location = new System.Drawing.Point(293, 331);
            this.numberOfChipsToAdd.Name = "numberOfChipsToAdd";
            this.numberOfChipsToAdd.Size = new System.Drawing.Size(92, 20);
            this.numberOfChipsToAdd.TabIndex = 8;
            // 
            // addChipsButton
            // 
            this.addChipsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addChipsButton.Location = new System.Drawing.Point(310, 360);
            this.addChipsButton.Name = "addChipsButton";
            this.addChipsButton.Size = new System.Drawing.Size(75, 25);
            this.addChipsButton.TabIndex = 7;
            this.addChipsButton.Text = "AddChips";
            this.addChipsButton.UseVisualStyleBackColor = true;
            this.addChipsButton.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarTimer.Location = new System.Drawing.Point(354, 450);
            this.progressBarTimer.Maximum = 1000;
            this.progressBarTimer.Name = "progressBarTimer";
            this.progressBarTimer.Size = new System.Drawing.Size(667, 23);
            this.progressBarTimer.TabIndex = 5;
            this.progressBarTimer.Value = 1000;
            // 
            // raiseButton
            // 
            this.raiseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.raiseButton.Enabled = false;
            this.raiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.raiseButton.Location = new System.Drawing.Point(774, 575);
            this.raiseButton.Name = "raiseButton";
            this.raiseButton.Size = new System.Drawing.Size(111, 32);
            this.raiseButton.TabIndex = 4;
            this.raiseButton.Text = "Raise";
            this.raiseButton.UseVisualStyleBackColor = true;
            this.raiseButton.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // callButton
            // 
            this.callButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.callButton.Enabled = false;
            this.callButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.callButton.Location = new System.Drawing.Point(774, 507);
            this.callButton.Name = "callButton";
            this.callButton.Size = new System.Drawing.Size(111, 48);
            this.callButton.TabIndex = 3;
            this.callButton.Text = "Call";
            this.callButton.UseVisualStyleBackColor = true;
            this.callButton.Click += new System.EventHandler(this.bCall_Click);
            // 
            // checkButton
            // 
            this.checkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkButton.Enabled = false;
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(394, 507);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(111, 48);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // foldButton
            // 
            this.foldButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.foldButton.Enabled = false;
            this.foldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foldButton.Location = new System.Drawing.Point(394, 575);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(114, 49);
            this.foldButton.TabIndex = 0;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            this.foldButton.Click += new System.EventHandler(this.bFold_Click);
            // 
            // Bot4Chips
            // 
            this.Bot4Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot4Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot4Chips.Location = new System.Drawing.Point(1371, -121);
            this.Bot4Chips.Name = "Bot4Chips";
            this.Bot4Chips.ReadOnly = true;
            this.Bot4Chips.Size = new System.Drawing.Size(104, 23);
            this.Bot4Chips.TabIndex = 10;
            this.Bot4Chips.Text = "Chips : 0";
            // 
            // Bot3Chips
            // 
            this.Bot3Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot3Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot3Chips.Location = new System.Drawing.Point(933, -121);
            this.Bot3Chips.Name = "Bot3Chips";
            this.Bot3Chips.ReadOnly = true;
            this.Bot3Chips.Size = new System.Drawing.Size(125, 23);
            this.Bot3Chips.TabIndex = 11;
            this.Bot3Chips.Text = "Chips : 0";
            // 
            // Bot2Chips
            // 
            this.Bot2Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot2Chips.Location = new System.Drawing.Point(-100, -121);
            this.Bot2Chips.Name = "Bot2Chips";
            this.Bot2Chips.ReadOnly = true;
            this.Bot2Chips.Size = new System.Drawing.Size(133, 23);
            this.Bot2Chips.TabIndex = 12;
            this.Bot2Chips.Text = "Chips : 0";
            this.Bot2Chips.TextChanged += new System.EventHandler(this.tbBotChips2_TextChanged);
            // 
            // GLSTexasPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1348, 726);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.potLabel);
            this.Controls.Add(this.Bot2StatusLabel);
            this.Controls.Add(this.playerStatusLabel);
            this.Controls.Add(this.Bot1StatusLabel);
            this.Controls.Add(this.Bot3StatusLabel);
            this.Controls.Add(this.Bot4StatusLabel);
            this.Controls.Add(this.Bot5StatusLabel);
            this.Controls.Add(this.bigBlindSum);
            this.Controls.Add(this.smallBlindButton);
            this.Controls.Add(this.smallBlindSum);
            this.Controls.Add(this.bigBlindButton);
            this.Controls.Add(this.potChips);
            this.Controls.Add(this.Bot2Chips);
            this.Controls.Add(this.Bot3Chips);
            this.Controls.Add(this.Bot4Chips);
            this.Controls.Add(this.numberOfChipsToAdd);
            this.Controls.Add(this.addChipsButton);
            this.Controls.Add(this.progressBarTimer);
            this.Controls.Add(this.raiseButton);
            this.Controls.Add(this.callButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.foldButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1364, 765);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "GLSTexasPoker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GLS Texas Poker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer GameUpdate;
        private Timer RotateTimer;
        private TextBox tbRaise;
        private Label potLabel;
        private Label playerStatusLabel;
        private Label Bot1StatusLabel;
        private Label Bot3StatusLabel;
        private Label Bot2StatusLabel;
        private Label Bot5StatusLabel;
        private TextBox bigBlindSum;
        private Button smallBlindButton;
        private TextBox smallBlindSum;
        private Button bigBlindButton;
        private TextBox potChips;
        private Label Bot4StatusLabel;
        private TextBox numberOfChipsToAdd;
        private Button addChipsButton;
        private ProgressBar progressBarTimer;
        private Button raiseButton;
        private Button callButton;
        private Button checkButton;
        private Button foldButton;
        private TextBox Bot4Chips;
        private TextBox Bot3Chips;
        private TextBox Bot2Chips;
    }
}

