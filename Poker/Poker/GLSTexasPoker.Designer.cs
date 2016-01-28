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
            this.Bot1Chips = new System.Windows.Forms.TextBox();
            this.Bot4StatusLabel = new System.Windows.Forms.Label();
            this.Bot5Chips = new System.Windows.Forms.TextBox();
            this.numberOfChipsToAdd = new System.Windows.Forms.TextBox();
            this.addChipsButton = new System.Windows.Forms.Button();
            this.PlayerChips = new System.Windows.Forms.TextBox();
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
            this.tbRaise.Location = new System.Drawing.Point(940, 866);
            this.tbRaise.Margin = new System.Windows.Forms.Padding(4);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(143, 22);
            this.tbRaise.TabIndex = 0;
            this.tbRaise.TextChanged += new System.EventHandler(this.tbRaise_TextChanged);
            // 
            // potLabel
            // 
            this.potLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potLabel.Location = new System.Drawing.Point(863, 201);
            this.potLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.potLabel.Name = "potLabel";
            this.potLabel.Size = new System.Drawing.Size(41, 26);
            this.potLabel.TabIndex = 0;
            this.potLabel.Text = "Pot";
            // 
            // playerStatusLabel
            // 
            this.playerStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerStatusLabel.Location = new System.Drawing.Point(1124, 844);
            this.playerStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerStatusLabel.Name = "playerStatusLabel";
            this.playerStatusLabel.Size = new System.Drawing.Size(160, 33);
            this.playerStatusLabel.TabIndex = 30;
            // 
            // Bot1StatusLabel
            // 
            this.Bot1StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bot1StatusLabel.Location = new System.Drawing.Point(25, 795);
            this.Bot1StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bot1StatusLabel.Name = "Bot1StatusLabel";
            this.Bot1StatusLabel.Size = new System.Drawing.Size(189, 39);
            this.Bot1StatusLabel.TabIndex = 29;
            // 
            // Bot3StatusLabel
            // 
            this.Bot3StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot3StatusLabel.Location = new System.Drawing.Point(972, 43);
            this.Bot3StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bot3StatusLabel.Name = "Bot3StatusLabel";
            this.Bot3StatusLabel.Size = new System.Drawing.Size(127, 39);
            this.Bot3StatusLabel.TabIndex = 28;
            // 
            // Bot2StatusLabel
            // 
            this.Bot2StatusLabel.Location = new System.Drawing.Point(25, 43);
            this.Bot2StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bot2StatusLabel.Name = "Bot2StatusLabel";
            this.Bot2StatusLabel.Size = new System.Drawing.Size(145, 39);
            this.Bot2StatusLabel.TabIndex = 31;
            // 
            // Bot5StatusLabel
            // 
            this.Bot5StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot5StatusLabel.Location = new System.Drawing.Point(1493, 802);
            this.Bot5StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bot5StatusLabel.Name = "Bot5StatusLabel";
            this.Bot5StatusLabel.Size = new System.Drawing.Size(203, 39);
            this.Bot5StatusLabel.TabIndex = 26;
            // 
            // bigBlindSum
            // 
            this.bigBlindSum.Location = new System.Drawing.Point(343, 320);
            this.bigBlindSum.Margin = new System.Windows.Forms.Padding(4);
            this.bigBlindSum.Name = "bigBlindSum";
            this.bigBlindSum.Size = new System.Drawing.Size(99, 22);
            this.bigBlindSum.TabIndex = 19;
            this.bigBlindSum.Text = "500";
            // 
            // smallBlindButton
            // 
            this.smallBlindButton.Location = new System.Drawing.Point(343, 217);
            this.smallBlindButton.Margin = new System.Windows.Forms.Padding(4);
            this.smallBlindButton.Name = "smallBlindButton";
            this.smallBlindButton.Size = new System.Drawing.Size(100, 28);
            this.smallBlindButton.TabIndex = 18;
            this.smallBlindButton.Text = "Small Blind";
            this.smallBlindButton.UseVisualStyleBackColor = true;
            this.smallBlindButton.Click += new System.EventHandler(this.bSB_Click);
            // 
            // smallBlindSum
            // 
            this.smallBlindSum.Location = new System.Drawing.Point(343, 252);
            this.smallBlindSum.Margin = new System.Windows.Forms.Padding(4);
            this.smallBlindSum.Name = "smallBlindSum";
            this.smallBlindSum.Size = new System.Drawing.Size(99, 22);
            this.smallBlindSum.TabIndex = 17;
            this.smallBlindSum.Text = "250";
            // 
            // bigBlindButton
            // 
            this.bigBlindButton.Location = new System.Drawing.Point(343, 284);
            this.bigBlindButton.Margin = new System.Windows.Forms.Padding(4);
            this.bigBlindButton.Name = "bigBlindButton";
            this.bigBlindButton.Size = new System.Drawing.Size(100, 28);
            this.bigBlindButton.TabIndex = 16;
            this.bigBlindButton.Text = "Big Blind";
            this.bigBlindButton.UseVisualStyleBackColor = true;
            this.bigBlindButton.Click += new System.EventHandler(this.bBB_Click);
            // 
            // potChips
            // 
            this.potChips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potChips.Location = new System.Drawing.Point(799, 249);
            this.potChips.Margin = new System.Windows.Forms.Padding(4);
            this.potChips.Name = "potChips";
            this.potChips.ReadOnly = true;
            this.potChips.Size = new System.Drawing.Size(165, 26);
            this.potChips.TabIndex = 14;
            this.potChips.Text = "0";
            // 
            // Bot1Chips
            // 
            this.Bot1Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bot1Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot1Chips.Location = new System.Drawing.Point(25, 763);
            this.Bot1Chips.Margin = new System.Windows.Forms.Padding(4);
            this.Bot1Chips.Name = "Bot1Chips";
            this.Bot1Chips.ReadOnly = true;
            this.Bot1Chips.Size = new System.Drawing.Size(188, 26);
            this.Bot1Chips.TabIndex = 13;
            this.Bot1Chips.Text = "Chips : 0";
            // 
            // Bot4StatusLabel
            // 
            this.Bot4StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot4StatusLabel.Location = new System.Drawing.Point(1584, 43);
            this.Bot4StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Bot4StatusLabel.Name = "Bot4StatusLabel";
            this.Bot4StatusLabel.Size = new System.Drawing.Size(97, 39);
            this.Bot4StatusLabel.TabIndex = 27;
            // 
            // Bot5Chips
            // 
            this.Bot5Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot5Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot5Chips.Location = new System.Drawing.Point(1493, 763);
            this.Bot5Chips.Margin = new System.Windows.Forms.Padding(4);
            this.Bot5Chips.Name = "Bot5Chips";
            this.Bot5Chips.ReadOnly = true;
            this.Bot5Chips.Size = new System.Drawing.Size(201, 26);
            this.Bot5Chips.TabIndex = 9;
            this.Bot5Chips.Text = "Chips : 0";
            // 
            // numberOfChipsToAdd
            // 
            this.numberOfChipsToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfChipsToAdd.Location = new System.Drawing.Point(343, 517);
            this.numberOfChipsToAdd.Margin = new System.Windows.Forms.Padding(4);
            this.numberOfChipsToAdd.Name = "numberOfChipsToAdd";
            this.numberOfChipsToAdd.Size = new System.Drawing.Size(121, 22);
            this.numberOfChipsToAdd.TabIndex = 8;
            // 
            // addChipsButton
            // 
            this.addChipsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addChipsButton.Location = new System.Drawing.Point(365, 553);
            this.addChipsButton.Margin = new System.Windows.Forms.Padding(4);
            this.addChipsButton.Name = "addChipsButton";
            this.addChipsButton.Size = new System.Drawing.Size(100, 31);
            this.addChipsButton.TabIndex = 7;
            this.addChipsButton.Text = "AddChips";
            this.addChipsButton.UseVisualStyleBackColor = true;
            this.addChipsButton.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // PlayerChips
            // 
            this.PlayerChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayerChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerChips.Location = new System.Drawing.Point(1128, 814);
            this.PlayerChips.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerChips.Name = "PlayerChips";
            this.PlayerChips.ReadOnly = true;
            this.PlayerChips.Size = new System.Drawing.Size(216, 26);
            this.PlayerChips.TabIndex = 6;
            this.PlayerChips.Text = "Chips : 0";
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarTimer.Location = new System.Drawing.Point(408, 783);
            this.progressBarTimer.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarTimer.Maximum = 1000;
            this.progressBarTimer.Name = "progressBarTimer";
            this.progressBarTimer.Size = new System.Drawing.Size(889, 28);
            this.progressBarTimer.TabIndex = 5;
            this.progressBarTimer.Value = 1000;
            // 
            // raiseButton
            // 
            this.raiseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.raiseButton.Enabled = false;
            this.raiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.raiseButton.Location = new System.Drawing.Point(940, 820);
            this.raiseButton.Margin = new System.Windows.Forms.Padding(4);
            this.raiseButton.Name = "raiseButton";
            this.raiseButton.Size = new System.Drawing.Size(148, 39);
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
            this.callButton.Location = new System.Drawing.Point(768, 820);
            this.callButton.Margin = new System.Windows.Forms.Padding(4);
            this.callButton.Name = "callButton";
            this.callButton.Size = new System.Drawing.Size(148, 59);
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
            this.checkButton.Location = new System.Drawing.Point(593, 820);
            this.checkButton.Margin = new System.Windows.Forms.Padding(4);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(148, 59);
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
            this.foldButton.Location = new System.Drawing.Point(408, 818);
            this.foldButton.Margin = new System.Windows.Forms.Padding(4);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(152, 60);
            this.foldButton.TabIndex = 0;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            this.foldButton.Click += new System.EventHandler(this.bFold_Click);
            // 
            // Bot4Chips
            // 
            this.Bot4Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot4Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot4Chips.Location = new System.Drawing.Point(1543, 11);
            this.Bot4Chips.Margin = new System.Windows.Forms.Padding(4);
            this.Bot4Chips.Name = "Bot4Chips";
            this.Bot4Chips.ReadOnly = true;
            this.Bot4Chips.Size = new System.Drawing.Size(137, 26);
            this.Bot4Chips.TabIndex = 10;
            this.Bot4Chips.Text = "Chips : 0";
            // 
            // Bot3Chips
            // 
            this.Bot3Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bot3Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot3Chips.Location = new System.Drawing.Point(959, 11);
            this.Bot3Chips.Margin = new System.Windows.Forms.Padding(4);
            this.Bot3Chips.Name = "Bot3Chips";
            this.Bot3Chips.ReadOnly = true;
            this.Bot3Chips.Size = new System.Drawing.Size(165, 26);
            this.Bot3Chips.TabIndex = 11;
            this.Bot3Chips.Text = "Chips : 0";
            // 
            // Bot2Chips
            // 
            this.Bot2Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bot2Chips.Location = new System.Drawing.Point(24, 11);
            this.Bot2Chips.Margin = new System.Windows.Forms.Padding(4);
            this.Bot2Chips.Name = "Bot2Chips";
            this.Bot2Chips.ReadOnly = true;
            this.Bot2Chips.Size = new System.Drawing.Size(176, 26);
            this.Bot2Chips.TabIndex = 12;
            this.Bot2Chips.Text = "Chips : 0";
            this.Bot2Chips.TextChanged += new System.EventHandler(this.tbBotChips2_TextChanged);
            // 
            // GLSTexasPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1712, 885);
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
            this.Controls.Add(this.Bot1Chips);
            this.Controls.Add(this.Bot2Chips);
            this.Controls.Add(this.Bot3Chips);
            this.Controls.Add(this.Bot4Chips);
            this.Controls.Add(this.Bot5Chips);
            this.Controls.Add(this.numberOfChipsToAdd);
            this.Controls.Add(this.addChipsButton);
            this.Controls.Add(this.PlayerChips);
            this.Controls.Add(this.progressBarTimer);
            this.Controls.Add(this.raiseButton);
            this.Controls.Add(this.callButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.foldButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1814, 932);
            this.MinimumSize = new System.Drawing.Size(1698, 883);
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
        private TextBox Bot1Chips;
        private Label Bot4StatusLabel;
        private TextBox Bot5Chips;
        private TextBox numberOfChipsToAdd;
        private Button addChipsButton;
        private TextBox PlayerChips;
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

