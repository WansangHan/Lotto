namespace Lotto
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Execute = new System.Windows.Forms.Button();
            this.box1 = new System.Windows.Forms.ListBox();
            this.box2 = new System.Windows.Forms.ListBox();
            this.box3 = new System.Windows.Forms.ListBox();
            this.box4 = new System.Windows.Forms.ListBox();
            this.box5 = new System.Windows.Forms.ListBox();
            this.Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(287, 153);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(75, 23);
            this.Execute.TabIndex = 0;
            this.Execute.Text = "번호 뽑기";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // box1
            // 
            this.box1.FormattingEnabled = true;
            this.box1.ItemHeight = 12;
            this.box1.Location = new System.Drawing.Point(12, 59);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(120, 88);
            this.box1.TabIndex = 1;
            // 
            // box2
            // 
            this.box2.FormattingEnabled = true;
            this.box2.ItemHeight = 12;
            this.box2.Location = new System.Drawing.Point(138, 59);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(120, 88);
            this.box2.TabIndex = 2;
            // 
            // box3
            // 
            this.box3.FormattingEnabled = true;
            this.box3.ItemHeight = 12;
            this.box3.Location = new System.Drawing.Point(264, 59);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(120, 88);
            this.box3.TabIndex = 3;
            // 
            // box4
            // 
            this.box4.FormattingEnabled = true;
            this.box4.ItemHeight = 12;
            this.box4.Location = new System.Drawing.Point(390, 59);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(120, 88);
            this.box4.TabIndex = 4;
            // 
            // box5
            // 
            this.box5.FormattingEnabled = true;
            this.box5.ItemHeight = 12;
            this.box5.Location = new System.Drawing.Point(516, 59);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(120, 88);
            this.box5.TabIndex = 5;
            // 
            // Text
            // 
            this.Text.Font = new System.Drawing.Font("궁서체", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text.Location = new System.Drawing.Point(12, 9);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(624, 37);
            this.Text.TabIndex = 6;
            this.Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Text.DoubleClick += new System.EventHandler(this.Text_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 184);
            this.Controls.Add(this.Text);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.Execute);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.ListBox box1;
        private System.Windows.Forms.ListBox box2;
        private System.Windows.Forms.ListBox box3;
        private System.Windows.Forms.ListBox box4;
        private System.Windows.Forms.ListBox box5;
        private System.Windows.Forms.Label Text;
    }
}

