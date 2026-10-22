<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentRegistrationDialog
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
        Me.lblStudentNo = New System.Windows.Forms.Label()
        Me.txtStudentNumber = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.lblLast = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblSport = New System.Windows.Forms.Label()
        Me.cmbSport = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()

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
        Me.pnlDialogHeader.Size = New System.Drawing.Size(650, 72)
        Me.pnlDialogHeader.TabIndex = 0
        '
        'headerStripe
        '
        Me.headerStripe.BackColor = System.Drawing.Color.FromArgb(212, 160, 23)
        Me.headerStripe.Dock = System.Windows.Forms.DockStyle.Top
        Me.headerStripe.Location = New System.Drawing.Point(0, 0)
        Me.headerStripe.Name = "headerStripe"
        Me.headerStripe.Size = New System.Drawing.Size(650, 4)
        Me.headerStripe.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(185, 210, 240)
        Me.lblSub.Location = New System.Drawing.Point(24, 42)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.Size = New System.Drawing.Size(465, 15)
        Me.lblSub.TabIndex = 2
        Me.lblSub.Text = "Enter student details, contact info, college degree program, and select preferred sport discipline."
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
        Me.lblTitle.Text = "📝  Register Student-Athlete"
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlFooter.Controls.Add(Me.sepFooter)
        Me.pnlFooter.Controls.Add(Me.lblFeedback)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnSave)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 460)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(650, 64)
        Me.pnlFooter.TabIndex = 2
        '
        'sepFooter
        '
        Me.sepFooter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.sepFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.sepFooter.Location = New System.Drawing.Point(0, 0)
        Me.sepFooter.Name = "sepFooter"
        Me.sepFooter.Size = New System.Drawing.Size(650, 1)
        Me.sepFooter.TabIndex = 0
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoEllipsis = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFeedback.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblFeedback.Location = New System.Drawing.Point(20, 20)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(340, 24)
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
        Me.btnCancel.Location = New System.Drawing.Point(370, 12)
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
        Me.btnSave.Location = New System.Drawing.Point(480, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 40)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "✚  Register Student"
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
        Me.pnlBody.Size = New System.Drawing.Size(650, 388)
        Me.pnlBody.TabIndex = 1
        '
        'cardContent
        '
        Me.cardContent.BackColor = System.Drawing.Color.White
        Me.cardContent.Controls.Add(Me.stripeCard)
        Me.cardContent.Controls.Add(Me.lblStudentNo)
        Me.cardContent.Controls.Add(Me.txtStudentNumber)
        Me.cardContent.Controls.Add(Me.lblGender)
        Me.cardContent.Controls.Add(Me.cmbGender)
        Me.cardContent.Controls.Add(Me.lblFirst)
        Me.cardContent.Controls.Add(Me.txtFirstName)
        Me.cardContent.Controls.Add(Me.lblMiddle)
        Me.cardContent.Controls.Add(Me.txtMiddleName)
        Me.cardContent.Controls.Add(Me.lblLast)
        Me.cardContent.Controls.Add(Me.txtLastName)
        Me.cardContent.Controls.Add(Me.lblCourse)
        Me.cardContent.Controls.Add(Me.cmbCourse)
        Me.cardContent.Controls.Add(Me.lblYear)
        Me.cardContent.Controls.Add(Me.cmbYear)
        Me.cardContent.Controls.Add(Me.lblContact)
        Me.cardContent.Controls.Add(Me.txtContact)
        Me.cardContent.Controls.Add(Me.lblEmail)
        Me.cardContent.Controls.Add(Me.txtEmail)
        Me.cardContent.Controls.Add(Me.lblSport)
        Me.cardContent.Controls.Add(Me.cmbSport)
        Me.cardContent.Controls.Add(Me.lblStatus)
        Me.cardContent.Controls.Add(Me.cmbStatus)
        Me.cardContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardContent.Location = New System.Drawing.Point(18, 14)
        Me.cardContent.Name = "cardContent"
        Me.cardContent.Size = New System.Drawing.Size(614, 360)
        Me.cardContent.TabIndex = 0
        '
        'stripeCard
        '
        Me.stripeCard.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.stripeCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.stripeCard.Location = New System.Drawing.Point(0, 0)
        Me.stripeCard.Name = "stripeCard"
        Me.stripeCard.Size = New System.Drawing.Size(614, 3)
        Me.stripeCard.TabIndex = 0
        '
        'lblStudentNo
        '
        Me.lblStudentNo.AutoSize = True
        Me.lblStudentNo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentNo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStudentNo.Location = New System.Drawing.Point(22, 14)
        Me.lblStudentNo.Name = "lblStudentNo"
        Me.lblStudentNo.Size = New System.Drawing.Size(147, 15)
        Me.lblStudentNo.TabIndex = 1
        Me.lblStudentNo.Text = "STUDENT ID / NUMBER *"
        '
        'txtStudentNumber
        '
        Me.txtStudentNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtStudentNumber.Location = New System.Drawing.Point(22, 34)
        Me.txtStudentNumber.Name = "txtStudentNumber"
        Me.txtStudentNumber.Size = New System.Drawing.Size(320, 25)
        Me.txtStudentNumber.TabIndex = 2
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblGender.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblGender.Location = New System.Drawing.Point(362, 14)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(60, 15)
        Me.lblGender.TabIndex = 3
        Me.lblGender.Text = "GENDER *"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(362, 34)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(230, 25)
        Me.cmbGender.TabIndex = 4
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFirst.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFirst.Location = New System.Drawing.Point(22, 70)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(83, 15)
        Me.lblFirst.TabIndex = 5
        Me.lblFirst.Text = "FIRST NAME *"
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtFirstName.Location = New System.Drawing.Point(22, 90)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(175, 25)
        Me.txtFirstName.TabIndex = 6
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblMiddle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblMiddle.Location = New System.Drawing.Point(215, 70)
        Me.lblMiddle.Name = "lblMiddle"
        Me.lblMiddle.Size = New System.Drawing.Size(88, 15)
        Me.lblMiddle.TabIndex = 7
        Me.lblMiddle.Text = "MIDDLE NAME"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMiddleName.Location = New System.Drawing.Point(215, 90)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(175, 25)
        Me.txtMiddleName.TabIndex = 8
        '
        'lblLast
        '
        Me.lblLast.AutoSize = True
        Me.lblLast.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblLast.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblLast.Location = New System.Drawing.Point(408, 70)
        Me.lblLast.Name = "lblLast"
        Me.lblLast.Size = New System.Drawing.Size(79, 15)
        Me.lblLast.TabIndex = 9
        Me.lblLast.Text = "LAST NAME *"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtLastName.Location = New System.Drawing.Point(408, 90)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(184, 25)
        Me.txtLastName.TabIndex = 10
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblCourse.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCourse.Location = New System.Drawing.Point(22, 126)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(185, 15)
        Me.lblCourse.TabIndex = 11
        Me.lblCourse.Text = "COLLEGE DEGREE PROGRAM *"
        '
        'cmbCourse
        '
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.DropDownWidth = 460
        Me.cmbCourse.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(22, 146)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(390, 24)
        Me.cmbCourse.TabIndex = 12
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblYear.Location = New System.Drawing.Point(426, 126)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(76, 15)
        Me.lblYear.TabIndex = 13
        Me.lblYear.Text = "YEAR LEVEL *"
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"1st Year", "2nd Year", "3rd Year", "4th Year"})
        Me.cmbYear.Location = New System.Drawing.Point(426, 146)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(166, 24)
        Me.cmbYear.TabIndex = 14
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblContact.Location = New System.Drawing.Point(22, 182)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(109, 15)
        Me.lblContact.TabIndex = 15
        Me.lblContact.Text = "CONTACT NUMBER"
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtContact.Location = New System.Drawing.Point(22, 202)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(270, 25)
        Me.txtContact.TabIndex = 16
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblEmail.Location = New System.Drawing.Point(312, 182)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(95, 15)
        Me.lblEmail.TabIndex = 17
        Me.lblEmail.Text = "EMAIL ADDRESS"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtEmail.Location = New System.Drawing.Point(312, 202)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(280, 25)
        Me.txtEmail.TabIndex = 18
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSport.Location = New System.Drawing.Point(22, 238)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(186, 15)
        Me.lblSport.TabIndex = 19
        Me.lblSport.Text = "PREFERRED SPORT DISCIPLINE *"
        '
        'cmbSport
        '
        Me.cmbSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSport.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSport.FormattingEnabled = True
        Me.cmbSport.Location = New System.Drawing.Point(22, 258)
        Me.cmbSport.Name = "cmbSport"
        Me.cmbSport.Size = New System.Drawing.Size(320, 25)
        Me.cmbSport.TabIndex = 20
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatus.Location = New System.Drawing.Point(362, 238)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(121, 15)
        Me.lblStatus.TabIndex = 21
        Me.lblStatus.Text = "SELECTION STATUS *"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Pending", "Selected", "Not Selected", "For Further Evaluation"})
        Me.cmbStatus.Location = New System.Drawing.Point(362, 258)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(230, 25)
        Me.cmbStatus.TabIndex = 22
        '
        'frmStudentRegistrationDialog
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(650, 524)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlDialogHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStudentRegistrationDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Student Registration"
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
    Friend WithEvents lblStudentNo As System.Windows.Forms.Label
    Friend WithEvents txtStudentNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirst As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents lblLast As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblCourse As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblSport As System.Windows.Forms.Label
    Friend WithEvents cmbSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents sepFooter As System.Windows.Forms.Panel
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
