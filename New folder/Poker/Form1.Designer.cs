namespace Poker
{
    partial class Form1
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
            this.bFold = new System.Windows.Forms.Button();
            this.bCheck = new System.Windows.Forms.Button();
            this.bCall = new System.Windows.Forms.Button();
            this.bRaise = new System.Windows.Forms.Button();
            this.pbTimer = new System.Windows.Forms.ProgressBar();
            this.tbChips = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.tbBotChips5 = new System.Windows.Forms.TextBox();
            this.tbBotChips4 = new System.Windows.Forms.TextBox();
            this.tbBotChips3 = new System.Windows.Forms.TextBox();
            this.tbBotChips2 = new System.Windows.Forms.TextBox();
            this.tbBotChips1 = new System.Windows.Forms.TextBox();
            this.pot = new System.Windows.Forms.TextBox();
            this.bOptions = new System.Windows.Forms.Button();
            this.bBB = new System.Windows.Forms.Button();
            this.tbSB = new System.Windows.Forms.TextBox();
            this.bSB = new System.Windows.Forms.Button();
            this.tbBB = new System.Windows.Forms.TextBox();
            this.fifthBotStatus = new System.Windows.Forms.Label();
            this.fourthBotStatus = new System.Windows.Forms.Label();
            this.thirdBotStatus = new System.Windows.Forms.Label();
            this.firstBotStatus = new System.Windows.Forms.Label();
            this.playerStatus = new System.Windows.Forms.Label();
            this.secondBotStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRaise = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bFold
            // 
            this.bFold.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFold.Location = new System.Drawing.Point(447, 812);
            this.bFold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bFold.Name = "bFold";
            this.bFold.Size = new System.Drawing.Size(173, 76);
            this.bFold.TabIndex = 0;
            this.bFold.Text = "Fold";
            this.bFold.UseVisualStyleBackColor = true;
            this.bFold.Click += new System.EventHandler(this.bFold_Click);
            // 
            // bCheck
            // 
            this.bCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCheck.Location = new System.Drawing.Point(659, 812);
            this.bCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(179, 76);
            this.bCheck.TabIndex = 2;
            this.bCheck.Text = "Check";
            this.bCheck.UseVisualStyleBackColor = true;
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // bCall
            // 
            this.bCall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCall.Location = new System.Drawing.Point(889, 814);
            this.bCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCall.Name = "bCall";
            this.bCall.Size = new System.Drawing.Size(168, 76);
            this.bCall.TabIndex = 3;
            this.bCall.Text = "Call";
            this.bCall.UseVisualStyleBackColor = true;
            this.bCall.Click += new System.EventHandler(this.bCall_Click);
            // 
            // bRaise
            // 
            this.bRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRaise.Location = new System.Drawing.Point(1113, 814);
            this.bRaise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bRaise.Name = "bRaise";
            this.bRaise.Size = new System.Drawing.Size(165, 76);
            this.bRaise.TabIndex = 4;
            this.bRaise.Text = "Raise";
            this.bRaise.UseVisualStyleBackColor = true;
            this.bRaise.Click += new System.EventHandler(this.bRaise_Click);
            // 
            // pbTimer
            // 
            this.pbTimer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbTimer.BackColor = System.Drawing.SystemColors.Control;
            this.pbTimer.Location = new System.Drawing.Point(447, 777);
            this.pbTimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTimer.Maximum = 1000;
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new System.Drawing.Size(889, 28);
            this.pbTimer.TabIndex = 5;
            this.pbTimer.Value = 1000;
            // 
            // tbChips
            // 
            this.tbChips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbChips.Location = new System.Drawing.Point(1007, 681);
            this.tbChips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbChips.Name = "tbChips";
            this.tbChips.Size = new System.Drawing.Size(216, 26);
            this.tbChips.TabIndex = 6;
            this.tbChips.Text = "Chips : 0";
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAdd.Location = new System.Drawing.Point(16, 858);
            this.bAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(100, 31);
            this.bAdd.TabIndex = 7;
            this.bAdd.Text = "AddChips";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAdd.Location = new System.Drawing.Point(124, 862);
            this.tbAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(165, 22);
            this.tbAdd.TabIndex = 8;
            // 
            // tbBotChips5
            // 
            this.tbBotChips5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotChips5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips5.Location = new System.Drawing.Point(1349, 681);
            this.tbBotChips5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBotChips5.Name = "tbBotChips5";
            this.tbBotChips5.Size = new System.Drawing.Size(201, 26);
            this.tbBotChips5.TabIndex = 9;
            this.tbBotChips5.Text = "Chips : 0";
            // 
            // tbBotChips4
            // 
            this.tbBotChips4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotChips4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips4.Location = new System.Drawing.Point(1293, 100);
            this.tbBotChips4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBotChips4.Name = "tbBotChips4";
            this.tbBotChips4.Size = new System.Drawing.Size(163, 26);
            this.tbBotChips4.TabIndex = 10;
            this.tbBotChips4.Text = "Chips : 0";
            // 
            // tbBotChips3
            // 
            this.tbBotChips3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBotChips3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips3.Location = new System.Drawing.Point(1007, 100);
            this.tbBotChips3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBotChips3.Name = "tbBotChips3";
            this.tbBotChips3.Size = new System.Drawing.Size(165, 26);
            this.tbBotChips3.TabIndex = 11;
            this.tbBotChips3.Text = "Chips : 0";
            // 
            // tbBotChips2
            // 
            this.tbBotChips2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips2.Location = new System.Drawing.Point(368, 100);
            this.tbBotChips2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBotChips2.Name = "tbBotChips2";
            this.tbBotChips2.Size = new System.Drawing.Size(176, 26);
            this.tbBotChips2.TabIndex = 12;
            this.tbBotChips2.Text = "Chips : 0";
            this.tbBotChips2.TextChanged += new System.EventHandler(this.tbBotChips2_TextChanged);
            // 
            // tbBotChips1
            // 
            this.tbBotChips1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBotChips1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips1.Location = new System.Drawing.Point(241, 681);
            this.tbBotChips1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBotChips1.Name = "tbBotChips1";
            this.tbBotChips1.Size = new System.Drawing.Size(188, 26);
            this.tbBotChips1.TabIndex = 13;
            this.tbBotChips1.Text = "Chips : 0";
            // 
            // tbPot
            // 
            this.pot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pot.Location = new System.Drawing.Point(808, 261);
            this.pot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pot.Name = "pot";
            this.pot.Size = new System.Drawing.Size(165, 26);
            this.pot.TabIndex = 14;
            this.pot.Text = "0";
            // 
            // bOptions
            // 
            this.bOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOptions.Location = new System.Drawing.Point(16, 15);
            this.bOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(100, 44);
            this.bOptions.TabIndex = 15;
            this.bOptions.Text = "BB/SB";
            this.bOptions.UseVisualStyleBackColor = true;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // bBB
            // 
            this.bBB.Location = new System.Drawing.Point(16, 313);
            this.bBB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bBB.Name = "bBB";
            this.bBB.Size = new System.Drawing.Size(100, 28);
            this.bBB.TabIndex = 16;
            this.bBB.Text = "Big Blind";
            this.bBB.UseVisualStyleBackColor = true;
            this.bBB.Click += new System.EventHandler(this.bBB_Click);
            // 
            // tbSB
            // 
            this.tbSB.Location = new System.Drawing.Point(16, 281);
            this.tbSB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSB.Name = "tbSB";
            this.tbSB.Size = new System.Drawing.Size(99, 22);
            this.tbSB.TabIndex = 17;
            this.tbSB.Text = "250";
            // 
            // bSB
            // 
            this.bSB.Location = new System.Drawing.Point(16, 245);
            this.bSB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSB.Name = "bSB";
            this.bSB.Size = new System.Drawing.Size(100, 28);
            this.bSB.TabIndex = 18;
            this.bSB.Text = "Small Blind";
            this.bSB.UseVisualStyleBackColor = true;
            this.bSB.Click += new System.EventHandler(this.bSB_Click);
            // 
            // tbBB
            // 
            this.tbBB.Location = new System.Drawing.Point(16, 348);
            this.tbBB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBB.Name = "tbBB";
            this.tbBB.Size = new System.Drawing.Size(99, 22);
            this.tbBB.TabIndex = 19;
            this.tbBB.Text = "500";
            // 
            // fifthBotStatus
            // 
            this.fifthBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fifthBotStatus.Location = new System.Drawing.Point(1349, 713);
            this.fifthBotStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fifthBotStatus.Name = "fifthBotStatus";
            this.fifthBotStatus.Size = new System.Drawing.Size(203, 39);
            this.fifthBotStatus.TabIndex = 26;
            // 
            // fourthBotStatus
            // 
            this.fourthBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fourthBotStatus.Location = new System.Drawing.Point(1293, 132);
            this.fourthBotStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fourthBotStatus.Name = "fourthBotStatus";
            this.fourthBotStatus.Size = new System.Drawing.Size(164, 39);
            this.fourthBotStatus.TabIndex = 27;
            // 
            // thirdBotStatus
            // 
            this.thirdBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thirdBotStatus.Location = new System.Drawing.Point(1007, 132);
            this.thirdBotStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thirdBotStatus.Name = "thirdBotStatus";
            this.thirdBotStatus.Size = new System.Drawing.Size(167, 39);
            this.thirdBotStatus.TabIndex = 28;
            // 
            // firstBotStatus
            // 
            this.firstBotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstBotStatus.Location = new System.Drawing.Point(241, 713);
            this.firstBotStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstBotStatus.Name = "firstBotStatus";
            this.firstBotStatus.Size = new System.Drawing.Size(189, 39);
            this.firstBotStatus.TabIndex = 29;
            // 
            // playerStatus
            // 
            this.playerStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerStatus.Location = new System.Drawing.Point(1007, 713);
            this.playerStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerStatus.Name = "playerStatus";
            this.playerStatus.Size = new System.Drawing.Size(217, 39);
            this.playerStatus.TabIndex = 30;
            // 
            // secondBotStatus
            // 
            this.secondBotStatus.Location = new System.Drawing.Point(368, 132);
            this.secondBotStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondBotStatus.Name = "secondBotStatus";
            this.secondBotStatus.Size = new System.Drawing.Size(177, 39);
            this.secondBotStatus.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(872, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pot";
            // 
            // tbRaise
            // 
            this.tbRaise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbRaise.Location = new System.Drawing.Point(1287, 865);
            this.tbRaise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(143, 22);
            this.tbRaise.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Poker.Properties.Resources.poker_table___Copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1800, 897);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondBotStatus);
            this.Controls.Add(this.playerStatus);
            this.Controls.Add(this.firstBotStatus);
            this.Controls.Add(this.thirdBotStatus);
            this.Controls.Add(this.fourthBotStatus);
            this.Controls.Add(this.fifthBotStatus);
            this.Controls.Add(this.tbBB);
            this.Controls.Add(this.bSB);
            this.Controls.Add(this.tbSB);
            this.Controls.Add(this.bBB);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.pot);
            this.Controls.Add(this.tbBotChips1);
            this.Controls.Add(this.tbBotChips2);
            this.Controls.Add(this.tbBotChips3);
            this.Controls.Add(this.tbBotChips4);
            this.Controls.Add(this.tbBotChips5);
            this.Controls.Add(this.tbAdd);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbChips);
            this.Controls.Add(this.pbTimer);
            this.Controls.Add(this.bRaise);
            this.Controls.Add(this.bCall);
            this.Controls.Add(this.bCheck);
            this.Controls.Add(this.bFold);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "GLS Texas Poker";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Layout_Change);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bFold;
        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.Button bCall;
        private System.Windows.Forms.Button bRaise;
        private System.Windows.Forms.ProgressBar pbTimer;
        private System.Windows.Forms.TextBox tbChips;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.TextBox tbBotChips5;
        private System.Windows.Forms.TextBox tbBotChips4;
        private System.Windows.Forms.TextBox tbBotChips3;
        private System.Windows.Forms.TextBox tbBotChips2;
        private System.Windows.Forms.TextBox tbBotChips1;
        private System.Windows.Forms.TextBox pot;
        private System.Windows.Forms.Button bOptions;
        private System.Windows.Forms.Button bBB;
        private System.Windows.Forms.TextBox tbSB;
        private System.Windows.Forms.Button bSB;
        private System.Windows.Forms.TextBox tbBB;
        private System.Windows.Forms.Label fifthBotStatus;
        private System.Windows.Forms.Label fourthBotStatus;
        private System.Windows.Forms.Label thirdBotStatus;
        private System.Windows.Forms.Label firstBotStatus;
        private System.Windows.Forms.Label playerStatus;
        private System.Windows.Forms.Label secondBotStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRaise;



    }
}

