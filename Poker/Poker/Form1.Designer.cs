using System.ComponentModel;
using System.Windows.Forms;

namespace Poker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.foldButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.callButton = new System.Windows.Forms.Button();
            this.raiseButton = new System.Windows.Forms.Button();
            this.progressBarTimer = new System.Windows.Forms.ProgressBar();
            this.tableChips = new System.Windows.Forms.TextBox();
            this.addChipsButton = new System.Windows.Forms.Button();
            this.numberOfChipsToAdd = new System.Windows.Forms.TextBox();
            this.tableBot5Chips = new System.Windows.Forms.TextBox();
            this.tableBot4Chips = new System.Windows.Forms.TextBox();
            this.tableBot3Chips = new System.Windows.Forms.TextBox();
            this.tableBot2Chips = new System.Windows.Forms.TextBox();
            this.tableBot1Chips = new System.Windows.Forms.TextBox();
            this.potChips = new System.Windows.Forms.TextBox();
            this.bOptions = new System.Windows.Forms.Button();
            this.bigBlindButton = new System.Windows.Forms.Button();
            this.smallBlindSum = new System.Windows.Forms.TextBox();
            this.smallBlindButton = new System.Windows.Forms.Button();
            this.bigBlindSum = new System.Windows.Forms.TextBox();
            this.fifthBotStatus = new System.Windows.Forms.Label();
            this.fourthBotStatus = new System.Windows.Forms.Label();
            this.thirdBotStatus = new System.Windows.Forms.Label();
            this.firstBotStatus = new System.Windows.Forms.Label();
            this.playerStatus = new System.Windows.Forms.Label();
            this.secondBotStatus = new System.Windows.Forms.Label();
            this.potLabel = new System.Windows.Forms.Label();
            this.tbRaise = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // foldButton
            // 
            this.foldButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.foldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foldButton.Location = new System.Drawing.Point(223, 536);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(114, 49);
            this.foldButton.TabIndex = 0;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            this.foldButton.Click += new System.EventHandler(this.bFold_Click);
            // 
            // checkButton
            // 
            this.checkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(362, 536);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(111, 49);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // callButton
            // 
            this.callButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.callButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.callButton.Location = new System.Drawing.Point(493, 537);
            this.callButton.Name = "callButton";
            this.callButton.Size = new System.Drawing.Size(111, 48);
            this.callButton.TabIndex = 3;
            this.callButton.Text = "Call";
            this.callButton.UseVisualStyleBackColor = true;
            this.callButton.Click += new System.EventHandler(this.bCall_Click);
            // 
            // raiseButton
            // 
            this.raiseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.raiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.raiseButton.Location = new System.Drawing.Point(643, 537);
            this.raiseButton.Name = "raiseButton";
            this.raiseButton.Size = new System.Drawing.Size(111, 48);
            this.raiseButton.TabIndex = 4;
            this.raiseButton.Text = "raise";
            this.raiseButton.UseVisualStyleBackColor = true;
            this.raiseButton.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // progressBarTimer
            // 
            this.progressBarTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarTimer.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarTimer.Location = new System.Drawing.Point(223, 507);
            this.progressBarTimer.Maximum = 1000;
            this.progressBarTimer.Name = "progressBarTimer";
            this.progressBarTimer.Size = new System.Drawing.Size(667, 23);
            this.progressBarTimer.TabIndex = 5;
            this.progressBarTimer.Value = 1000;
            // 
            // tableChips
            // 
            this.tableChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableChips.Location = new System.Drawing.Point(727, 478);
            this.tableChips.Name = "tableChips";
            this.tableChips.Size = new System.Drawing.Size(163, 23);
            this.tableChips.TabIndex = 6;
            this.tableChips.Text = "Chips : 0";
            // 
            // addChipsButton
            // 
            this.addChipsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addChipsButton.Location = new System.Drawing.Point(265, 368);
            this.addChipsButton.Name = "addChipsButton";
            this.addChipsButton.Size = new System.Drawing.Size(75, 25);
            this.addChipsButton.TabIndex = 7;
            this.addChipsButton.Text = "AddChips";
            this.addChipsButton.UseVisualStyleBackColor = true;
            this.addChipsButton.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // numberOfChipsToAdd
            // 
            this.numberOfChipsToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfChipsToAdd.Location = new System.Drawing.Point(248, 339);
            this.numberOfChipsToAdd.Name = "numberOfChipsToAdd";
            this.numberOfChipsToAdd.Size = new System.Drawing.Size(92, 20);
            this.numberOfChipsToAdd.TabIndex = 8;
            // 
            // tableBot5Chips
            // 
            this.tableBot5Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableBot5Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableBot5Chips.Location = new System.Drawing.Point(1008, 507);
            this.tableBot5Chips.Name = "tableBot5Chips";
            this.tableBot5Chips.Size = new System.Drawing.Size(152, 23);
            this.tableBot5Chips.TabIndex = 9;
            this.tableBot5Chips.Text = "Chips : 0";
            // 
            // tableBot4Chips
            // 
            this.tableBot4Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableBot4Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableBot4Chips.Location = new System.Drawing.Point(1044, 3);
            this.tableBot4Chips.Name = "tableBot4Chips";
            this.tableBot4Chips.Size = new System.Drawing.Size(116, 23);
            this.tableBot4Chips.TabIndex = 10;
            this.tableBot4Chips.Text = "Chips : 0";
            // 
            // tableBot3Chips
            // 
            this.tableBot3Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableBot3Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableBot3Chips.Location = new System.Drawing.Point(630, 3);
            this.tableBot3Chips.Name = "tableBot3Chips";
            this.tableBot3Chips.Size = new System.Drawing.Size(125, 23);
            this.tableBot3Chips.TabIndex = 11;
            this.tableBot3Chips.Text = "Chips : 0";
            // 
            // tableBot2Chips
            // 
            this.tableBot2Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableBot2Chips.Location = new System.Drawing.Point(213, 3);
            this.tableBot2Chips.Name = "tableBot2Chips";
            this.tableBot2Chips.Size = new System.Drawing.Size(133, 23);
            this.tableBot2Chips.TabIndex = 12;
            this.tableBot2Chips.Text = "Chips : 0";
            this.tableBot2Chips.TextChanged += new System.EventHandler(this.tbBotChips2_TextChanged);
            // 
            // tableBot1Chips
            // 
            this.tableBot1Chips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableBot1Chips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableBot1Chips.Location = new System.Drawing.Point(12, 509);
            this.tableBot1Chips.Name = "tableBot1Chips";
            this.tableBot1Chips.Size = new System.Drawing.Size(142, 23);
            this.tableBot1Chips.TabIndex = 13;
            this.tableBot1Chips.Text = "Chips : 0";
            // 
            // potChips
            // 
            this.potChips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potChips.Location = new System.Drawing.Point(506, 169);
            this.potChips.Name = "potChips";
            this.potChips.Size = new System.Drawing.Size(125, 23);
            this.potChips.TabIndex = 14;
            this.potChips.Text = "0";
            // 
            // bOptions
            // 
            this.bOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOptions.Location = new System.Drawing.Point(248, 169);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(75, 36);
            this.bOptions.TabIndex = 15;
            this.bOptions.Text = "BB/SB";
            this.bOptions.UseVisualStyleBackColor = true;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // bigBlindButton
            // 
            this.bigBlindButton.Location = new System.Drawing.Point(248, 266);
            this.bigBlindButton.Name = "bigBlindButton";
            this.bigBlindButton.Size = new System.Drawing.Size(75, 23);
            this.bigBlindButton.TabIndex = 16;
            this.bigBlindButton.Text = "Big Blind";
            this.bigBlindButton.UseVisualStyleBackColor = true;
            this.bigBlindButton.Click += new System.EventHandler(this.bBB_Click);
            // 
            // smallBlindSum
            // 
            this.smallBlindSum.Location = new System.Drawing.Point(248, 240);
            this.smallBlindSum.Name = "smallBlindSum";
            this.smallBlindSum.Size = new System.Drawing.Size(75, 20);
            this.smallBlindSum.TabIndex = 17;
            this.smallBlindSum.Text = "250";
            // 
            // smallBlindButton
            // 
            this.smallBlindButton.Location = new System.Drawing.Point(248, 211);
            this.smallBlindButton.Name = "smallBlindButton";
            this.smallBlindButton.Size = new System.Drawing.Size(75, 23);
            this.smallBlindButton.TabIndex = 18;
            this.smallBlindButton.Text = "Small Blind";
            this.smallBlindButton.UseVisualStyleBackColor = true;
            this.smallBlindButton.Click += new System.EventHandler(this.bSB_Click);
            // 
            // bigBlindSum
            // 
            this.bigBlindSum.Location = new System.Drawing.Point(248, 295);
            this.bigBlindSum.Name = "bigBlindSum";
            this.bigBlindSum.Size = new System.Drawing.Size(75, 20);
            this.bigBlindSum.TabIndex = 19;
            this.bigBlindSum.Text = "500";
            // 
            // fifthBotStatus
            // 
            this.fifthBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fifthBotStatus.Location = new System.Drawing.Point(1008, 533);
            this.fifthBotStatus.Name = "fifthBotStatus";
            this.fifthBotStatus.Size = new System.Drawing.Size(152, 32);
            this.fifthBotStatus.TabIndex = 26;
            // 
            // fourthBotStatus
            // 
            this.fourthBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fourthBotStatus.Location = new System.Drawing.Point(1075, 29);
            this.fourthBotStatus.Name = "fourthBotStatus";
            this.fourthBotStatus.Size = new System.Drawing.Size(73, 32);
            this.fourthBotStatus.TabIndex = 27;
            // 
            // thirdBotStatus
            // 
            this.thirdBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thirdBotStatus.Location = new System.Drawing.Point(640, 29);
            this.thirdBotStatus.Name = "thirdBotStatus";
            this.thirdBotStatus.Size = new System.Drawing.Size(95, 32);
            this.thirdBotStatus.TabIndex = 28;
            // 
            // firstBotStatus
            // 
            this.firstBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstBotStatus.Location = new System.Drawing.Point(12, 535);
            this.firstBotStatus.Name = "firstBotStatus";
            this.firstBotStatus.Size = new System.Drawing.Size(142, 32);
            this.firstBotStatus.TabIndex = 29;
            // 
            // playerStatus
            // 
            this.playerStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerStatus.Location = new System.Drawing.Point(757, 536);
            this.playerStatus.Name = "playerStatus";
            this.playerStatus.Size = new System.Drawing.Size(120, 27);
            this.playerStatus.TabIndex = 30;
            // 
            // secondBotStatus
            // 
            this.secondBotStatus.Location = new System.Drawing.Point(214, 29);
            this.secondBotStatus.Name = "secondBotStatus";
            this.secondBotStatus.Size = new System.Drawing.Size(109, 32);
            this.secondBotStatus.TabIndex = 31;
            // 
            // potLabel
            // 
            this.potLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.potLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potLabel.Location = new System.Drawing.Point(554, 130);
            this.potLabel.Name = "potLabel";
            this.potLabel.Size = new System.Drawing.Size(31, 21);
            this.potLabel.TabIndex = 0;
            this.potLabel.Text = "Pot";
            // 
            // tbRaise
            // 
            this.tbRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbRaise.Location = new System.Drawing.Point(760, 566);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(108, 20);
            this.tbRaise.TabIndex = 0;
            this.tbRaise.TextChanged += new System.EventHandler(this.tbRaise_TextChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1160, 611);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.potLabel);
            this.Controls.Add(this.secondBotStatus);
            this.Controls.Add(this.playerStatus);
            this.Controls.Add(this.firstBotStatus);
            this.Controls.Add(this.thirdBotStatus);
            this.Controls.Add(this.fourthBotStatus);
            this.Controls.Add(this.fifthBotStatus);
            this.Controls.Add(this.bigBlindSum);
            this.Controls.Add(this.smallBlindButton);
            this.Controls.Add(this.smallBlindSum);
            this.Controls.Add(this.bigBlindButton);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.potChips);
            this.Controls.Add(this.tableBot1Chips);
            this.Controls.Add(this.tableBot2Chips);
            this.Controls.Add(this.tableBot3Chips);
            this.Controls.Add(this.tableBot4Chips);
            this.Controls.Add(this.tableBot5Chips);
            this.Controls.Add(this.numberOfChipsToAdd);
            this.Controls.Add(this.addChipsButton);
            this.Controls.Add(this.tableChips);
            this.Controls.Add(this.progressBarTimer);
            this.Controls.Add(this.raiseButton);
            this.Controls.Add(this.callButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.foldButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GLS Texas Poker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button foldButton;
        private Button checkButton;
        private Button callButton;
        private Button raiseButton;
        private ProgressBar progressBarTimer;//ProgressBar
        private TextBox tableChips;
        private Button addChipsButton;
        private TextBox numberOfChipsToAdd;
        private TextBox tableBot5Chips;//tableChip
        private TextBox tableBot4Chips;
        private TextBox tableBot3Chips;
        private TextBox tableBot2Chips;
        private TextBox tableBot1Chips;
        private TextBox potChips;
        private Button bOptions;
        private Button bigBlindButton;
        private TextBox smallBlindSum;
        private Button smallBlindButton;
        private TextBox bigBlindSum;
        private Label fifthBotStatus;
        private Label fourthBotStatus;
        private Label thirdBotStatus;
        private Label firstBotStatus;
        private Label playerStatus;
        private Label secondBotStatus;
        private Label potLabel;
        private TextBox tbRaise;



    }
}

