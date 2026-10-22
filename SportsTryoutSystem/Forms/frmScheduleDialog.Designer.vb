<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScheduleDialog
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
        Me.lblSport = New System.Windows.Forms.Label()
        Me.cmbSport = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.lblVenue = New System.Windows.Forms.Label()
        Me.txtVenue = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()

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
        Me.pnlDialogHeader.Size = New System.Drawing.Size(600, 72)
        Me.pnlDialogHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(600, 4)
        Me.headerStripe.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblSub.Location = New System.Drawing.Point(24, 42)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(425, 15)
        Me.lblSub.TabIndex = 2
        Me.lblSub.Text = "Configure tryout session date, time, venue location, status, and sport discipline."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 13.5!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(22, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(262, 25)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "📅  Create Tryout Schedule"
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlFooter.Controls.Add(Me.sepFooter)
        Me.pnlFooter.Controls.Add(Me.lblFeedback)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnSave)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 456)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(600, 64)
        Me.pnlFooter.TabIndex = 2
        '
        'sepFooter
        '
        Me.sepFooter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.sepFooter.Location = New System.Drawing.Point(0, 0)
        Me.sepFooter.Name = "sepFooter"
        Me.sepFooter.Size = New System.Drawing.Size(600, 1)
        Me.sepFooter.TabIndex = 0
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoEllipsis = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFeedback.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblFeedback.Location = New System.Drawing.Point(20, 20)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(295, 24)
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
        Me.btnCancel.Location = New System.Drawing.Point(325, 12)
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
        Me.btnSave.Location = New System.Drawing.Point(435, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 40)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "✚  Create Schedule"
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
        Me.pnlBody.Size = New System.Drawing.Size(600, 384)
        Me.pnlBody.TabIndex = 1
        '
        'cardContent
        '
        Me.cardContent.BackColor = System.Drawing.Color.White
        Me.cardContent.Controls.Add(Me.stripeCard)
        Me.cardContent.Controls.Add(Me.lblSport)
        Me.cardContent.Controls.Add(Me.cmbSport)
        Me.cardContent.Controls.Add(Me.lblDate)
        Me.cardContent.Controls.Add(Me.dtpDate)
        Me.cardContent.Controls.Add(Me.lblTime)
        Me.cardContent.Controls.Add(Me.dtpTime)
        Me.cardContent.Controls.Add(Me.lblStatus)
        Me.cardContent.Controls.Add(Me.cmbStatus)
        Me.cardContent.Controls.Add(Me.lblVenue)
        Me.cardContent.Controls.Add(Me.txtVenue)
        Me.cardContent.Controls.Add(Me.lblNotes)
        Me.cardContent.Controls.Add(Me.txtNotes)
        Me.cardContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardContent.Location = New System.Drawing.Point(18, 14)
        Me.cardContent.Name = "cardContent"
        Me.cardContent.Size = New System.Drawing.Size(564, 356)
        Me.cardContent.TabIndex = 0
        '
        'stripeCard
        '
        Me.stripeCard.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeCard.Location = New System.Drawing.Point(0, 0)
        Me.stripeCard.Name = "stripeCard"
        Me.stripeCard.Size = New System.Drawing.Size(564, 3)
        Me.stripeCard.TabIndex = 0
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSport.Location = New System.Drawing.Point(22, 14)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(120, 15)
        Me.lblSport.TabIndex = 1
        Me.lblSport.Text = "SPORT DISCIPLINE *"
        '
        'cmbSport
        '
        Me.cmbSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSport.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSport.FormattingEnabled = True
        Me.cmbSport.Location = New System.Drawing.Point(22, 34)
        Me.cmbSport.Name = "cmbSport"
        Me.cmbSport.Size = New System.Drawing.Size(520, 25)
        Me.cmbSport.TabIndex = 2
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDate.Location = New System.Drawing.Point(22, 70)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(91, 15)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "TRYOUT DATE *"
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(22, 90)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(250, 25)
        Me.dtpDate.TabIndex = 4
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTime.Location = New System.Drawing.Point(292, 70)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(95, 15)
        Me.lblTime.TabIndex = 5
        Me.lblTime.Text = "SESSION TIME *"
        '
        'dtpTime
        '
        Me.dtpTime.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(292, 90)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(250, 25)
        Me.dtpTime.TabIndex = 6
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatus.Location = New System.Drawing.Point(22, 126)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(107, 15)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "SESSION STATUS *"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Upcoming", "Completed", "Cancelled"})
        Me.cmbStatus.Location = New System.Drawing.Point(22, 146)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(250, 25)
        Me.cmbStatus.TabIndex = 8
        '
        'lblVenue
        '
        Me.lblVenue.AutoSize = True
        Me.lblVenue.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblVenue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblVenue.Location = New System.Drawing.Point(22, 182)
        Me.lblVenue.Name = "lblVenue"
        Me.lblVenue.Size = New System.Drawing.Size(117, 15)
        Me.lblVenue.TabIndex = 9
        Me.lblVenue.Text = "VENUE / LOCATION *"
        '
        'txtVenue
        '
        Me.txtVenue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtVenue.Location = New System.Drawing.Point(22, 202)
        Me.txtVenue.Name = "txtVenue"
        Me.txtVenue.Size = New System.Drawing.Size(520, 25)
        Me.txtVenue.TabIndex = 10
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNotes.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNotes.Location = New System.Drawing.Point(22, 238)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(239, 15)
        Me.lblNotes.TabIndex = 11
        Me.lblNotes.Text = "SPECIAL NOTES / INSTRUCTIONS (OPTIONAL)"
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNotes.Location = New System.Drawing.Point(22, 258)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(520, 80)
        Me.txtNotes.TabIndex = 12
        '
        'frmScheduleDialog
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(600, 520)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlDialogHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScheduleDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tryout Schedule"
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
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents cardContent As System.Windows.Forms.Panel
    Friend WithEvents stripeCard As System.Windows.Forms.Panel
    Friend WithEvents lblSport As System.Windows.Forms.Label
    Friend WithEvents cmbSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblVenue As System.Windows.Forms.Label
    Friend WithEvents txtVenue As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents sepFooter As System.Windows.Forms.Panel
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
