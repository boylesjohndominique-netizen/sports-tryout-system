<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSportDialog
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlDialogHeader = New System.Windows.Forms.Panel()
        Me.headerStripe = New System.Windows.Forms.Panel()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.sepFooter = New System.Windows.Forms.Panel()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.cardContent = New System.Windows.Forms.Panel()
        Me.stripeCard = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtSportName = New System.Windows.Forms.TextBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.sepCoaches = New System.Windows.Forms.Panel()
        Me.lblCoachSection = New System.Windows.Forms.Label()
        Me.btnSelectAllCoaches = New System.Windows.Forms.Button()
        Me.btnClearAllCoaches = New System.Windows.Forms.Button()
        Me.clbCoaches = New System.Windows.Forms.CheckedListBox()

        Me.pnlDialogHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.cardContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDialogHeader
        '
        Me.pnlDialogHeader.BackColor = System.Drawing.Color.FromArgb(10, 30, 58)
        Me.pnlDialogHeader.Controls.Add(Me.headerStripe)
        Me.pnlDialogHeader.Controls.Add(Me.lblSub)
        Me.pnlDialogHeader.Controls.Add(Me.lblTitle)
        Me.pnlDialogHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDialogHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlDialogHeader.Name = "pnlDialogHeader"
        Me.pnlDialogHeader.Size = New System.Drawing.Size(620, 72)
        Me.pnlDialogHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(620, 4)
        Me.headerStripe.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblSub.Location = New System.Drawing.Point(24, 42)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(395, 15)
        Me.lblSub.TabIndex = 2
        Me.lblSub.Text = "Configure sport details, active tryout availability, and assign certified coaches."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(22, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(267, 25)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "🏆  Create New Sport Discipline"
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlFooter.Controls.Add(Me.sepFooter)
        Me.pnlFooter.Controls.Add(Me.lblFeedback)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnSave)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 586)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(620, 64)
        Me.pnlFooter.TabIndex = 2
        '
        'sepFooter
        '
        Me.sepFooter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.sepFooter.Location = New System.Drawing.Point(0, 0)
        Me.sepFooter.Name = "sepFooter"
        Me.sepFooter.Size = New System.Drawing.Size(620, 1)
        Me.sepFooter.TabIndex = 0
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoEllipsis = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFeedback.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblFeedback.Location = New System.Drawing.Point(20, 20)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(315, 24)
        Me.lblFeedback.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.btnCancel.Location = New System.Drawing.Point(345, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(455, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 40)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "✚  Create Sport"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlBody.Controls.Add(Me.cardContent)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 72)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(18, 14, 18, 14)
        Me.pnlBody.Size = New System.Drawing.Size(620, 514)
        Me.pnlBody.TabIndex = 1
        '
        'cardContent
        '
        Me.cardContent.BackColor = System.Drawing.Color.White
        Me.cardContent.Controls.Add(Me.stripeCard)
        Me.cardContent.Controls.Add(Me.lblName)
        Me.cardContent.Controls.Add(Me.txtSportName)
        Me.cardContent.Controls.Add(Me.chkIsActive)
        Me.cardContent.Controls.Add(Me.lblDesc)
        Me.cardContent.Controls.Add(Me.txtDescription)
        Me.cardContent.Controls.Add(Me.sepCoaches)
        Me.cardContent.Controls.Add(Me.lblCoachSection)
        Me.cardContent.Controls.Add(Me.btnSelectAllCoaches)
        Me.cardContent.Controls.Add(Me.btnClearAllCoaches)
        Me.cardContent.Controls.Add(Me.clbCoaches)
        Me.cardContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardContent.Location = New System.Drawing.Point(18, 14)
        Me.cardContent.Name = "cardContent"
        Me.cardContent.Size = New System.Drawing.Size(584, 486)
        Me.cardContent.TabIndex = 0
        '
        'stripeCard
        '
        Me.stripeCard.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeCard.Location = New System.Drawing.Point(0, 0)
        Me.stripeCard.Name = "stripeCard"
        Me.stripeCard.Size = New System.Drawing.Size(584, 3)
        Me.stripeCard.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblName.Location = New System.Drawing.Point(20, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(89, 15)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "SPORT NAME *"
        '
        'txtSportName
        '
        Me.txtSportName.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtSportName.Location = New System.Drawing.Point(20, 36)
        Me.txtSportName.Name = "txtSportName"
        Me.txtSportName.Size = New System.Drawing.Size(370, 26)
        Me.txtSportName.TabIndex = 2
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.chkIsActive.Location = New System.Drawing.Point(410, 38)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(145, 21)
        Me.chkIsActive.TabIndex = 3
        Me.chkIsActive.Text = "Active for Tryouts"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDesc.Location = New System.Drawing.Point(20, 74)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(199, 15)
        Me.lblDesc.TabIndex = 4
        Me.lblDesc.Text = "DESCRIPTION / NOTES && CRITERIA"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDescription.Location = New System.Drawing.Point(20, 94)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(544, 56)
        Me.txtDescription.TabIndex = 5
        '
        'sepCoaches
        '
        Me.sepCoaches.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepCoaches.Location = New System.Drawing.Point(20, 164)
        Me.sepCoaches.Name = "sepCoaches"
        Me.sepCoaches.Size = New System.Drawing.Size(544, 1)
        Me.sepCoaches.TabIndex = 6
        '
        'lblCoachSection
        '
        Me.lblCoachSection.AutoSize = True
        Me.lblCoachSection.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblCoachSection.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCoachSection.Location = New System.Drawing.Point(20, 178)
        Me.lblCoachSection.Name = "lblCoachSection"
        Me.lblCoachSection.Size = New System.Drawing.Size(252, 15)
        Me.lblCoachSection.TabIndex = 7
        Me.lblCoachSection.Text = "👥  ASSIGNED COACHES && EVALUATORS"
        '
        'btnSelectAllCoaches
        '
        Me.btnSelectAllCoaches.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnSelectAllCoaches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelectAllCoaches.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnSelectAllCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAllCoaches.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelectAllCoaches.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnSelectAllCoaches.Location = New System.Drawing.Point(370, 174)
        Me.btnSelectAllCoaches.Name = "btnSelectAllCoaches"
        Me.btnSelectAllCoaches.Size = New System.Drawing.Size(90, 26)
        Me.btnSelectAllCoaches.TabIndex = 8
        Me.btnSelectAllCoaches.Text = "✓ Select All"
        Me.btnSelectAllCoaches.UseVisualStyleBackColor = False
        '
        'btnClearAllCoaches
        '
        Me.btnClearAllCoaches.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnClearAllCoaches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAllCoaches.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnClearAllCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAllCoaches.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearAllCoaches.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnClearAllCoaches.Location = New System.Drawing.Point(468, 174)
        Me.btnClearAllCoaches.Name = "btnClearAllCoaches"
        Me.btnClearAllCoaches.Size = New System.Drawing.Size(96, 26)
        Me.btnClearAllCoaches.TabIndex = 9
        Me.btnClearAllCoaches.Text = "✕ Clear All"
        Me.btnClearAllCoaches.UseVisualStyleBackColor = False
        '
        'clbCoaches
        '
        Me.clbCoaches.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.clbCoaches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbCoaches.CheckOnClick = True
        Me.clbCoaches.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.clbCoaches.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.clbCoaches.FormattingEnabled = True
        Me.clbCoaches.IntegralHeight = False
        Me.clbCoaches.Location = New System.Drawing.Point(20, 208)
        Me.clbCoaches.Name = "clbCoaches"
        Me.clbCoaches.Size = New System.Drawing.Size(544, 255)
        Me.clbCoaches.TabIndex = 10
        '
        'frmSportDialog
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(620, 650)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlDialogHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSportDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sport Discipline"
        Me.pnlDialogHeader.ResumeLayout(False)
        Me.pnlDialogHeader.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.cardContent.ResumeLayout(False)
        Me.cardContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDialogHeader As System.Windows.Forms.Panel
    Friend WithEvents headerStripe As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSub As System.Windows.Forms.Label
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents sepFooter As System.Windows.Forms.Panel
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardContent As System.Windows.Forms.Panel
    Friend WithEvents stripeCard As System.Windows.Forms.Panel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtSportName As System.Windows.Forms.TextBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents sepCoaches As System.Windows.Forms.Panel
    Friend WithEvents lblCoachSection As System.Windows.Forms.Label
    Friend WithEvents btnSelectAllCoaches As System.Windows.Forms.Button
    Friend WithEvents btnClearAllCoaches As System.Windows.Forms.Button
    Friend WithEvents clbCoaches As System.Windows.Forms.CheckedListBox

End Class
