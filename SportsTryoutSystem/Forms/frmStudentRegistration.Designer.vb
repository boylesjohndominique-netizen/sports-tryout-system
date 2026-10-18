<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentRegistration
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
        Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlRegCard = New System.Windows.Forms.Panel()
        Me.cardAccent = New System.Windows.Forms.Panel()
        Me.lblSection1 = New System.Windows.Forms.Label()
        Me.lblRegSub = New System.Windows.Forms.Label()
        Me.lblRegBadge = New System.Windows.Forms.Label()
        Me.lblStudentNo = New System.Windows.Forms.Label()
        Me.txtStudentNumber = New System.Windows.Forms.TextBox()
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
        Me.lblGender = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.lblSport = New System.Windows.Forms.Label()
        Me.cmbSport = New System.Windows.Forms.ComboBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.div1 = New System.Windows.Forms.Panel()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblNoteHint = New System.Windows.Forms.Label()

        Me.pnlStatusCard = New System.Windows.Forms.Panel()
        Me.statusAccent = New System.Windows.Forms.Panel()
        Me.lblSection2 = New System.Windows.Forms.Label()
        Me.lblStatusSub = New System.Windows.Forms.Label()
        Me.lblSearchId = New System.Windows.Forms.Label()
        Me.txtSearchStudentNumber = New System.Windows.Forms.TextBox()
        Me.btnCheckStatus = New System.Windows.Forms.Button()
        Me.dgvStatus = New System.Windows.Forms.DataGridView()

        Me.pnlRegCard.SuspendLayout()
        Me.pnlStatusCard.SuspendLayout()
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRegCard (Top: Athlete Registration Card)
        '
        Me.pnlRegCard.BackColor = System.Drawing.Color.White
        Me.pnlRegCard.Controls.Add(Me.cardAccent)
        Me.pnlRegCard.Controls.Add(Me.lblSection1)
        Me.pnlRegCard.Controls.Add(Me.lblRegSub)
        Me.pnlRegCard.Controls.Add(Me.lblRegBadge)
        Me.pnlRegCard.Controls.Add(Me.lblStudentNo)
        Me.pnlRegCard.Controls.Add(Me.txtStudentNumber)
        Me.pnlRegCard.Controls.Add(Me.lblFirst)
        Me.pnlRegCard.Controls.Add(Me.txtFirstName)
        Me.pnlRegCard.Controls.Add(Me.lblMiddle)
        Me.pnlRegCard.Controls.Add(Me.txtMiddleName)
        Me.pnlRegCard.Controls.Add(Me.lblLast)
        Me.pnlRegCard.Controls.Add(Me.txtLastName)
        Me.pnlRegCard.Controls.Add(Me.lblCourse)
        Me.pnlRegCard.Controls.Add(Me.cmbCourse)
        Me.pnlRegCard.Controls.Add(Me.lblYear)
        Me.pnlRegCard.Controls.Add(Me.cmbYear)
        Me.pnlRegCard.Controls.Add(Me.lblGender)
        Me.pnlRegCard.Controls.Add(Me.cmbGender)
        Me.pnlRegCard.Controls.Add(Me.lblSport)
        Me.pnlRegCard.Controls.Add(Me.cmbSport)
        Me.pnlRegCard.Controls.Add(Me.lblContact)
        Me.pnlRegCard.Controls.Add(Me.txtContact)
        Me.pnlRegCard.Controls.Add(Me.lblEmail)
        Me.pnlRegCard.Controls.Add(Me.txtEmail)
        Me.pnlRegCard.Controls.Add(Me.div1)
        Me.pnlRegCard.Controls.Add(Me.btnRegister)
        Me.pnlRegCard.Controls.Add(Me.btnClear)
        Me.pnlRegCard.Controls.Add(Me.lblNoteHint)
        Me.pnlRegCard.Location = New System.Drawing.Point(24, 72)
        Me.pnlRegCard.Name = "pnlRegCard"
        Me.pnlRegCard.Size = New System.Drawing.Size(1150, 320)
        Me.pnlRegCard.TabIndex = 0
        '
        'cardAccent
        '
        Me.cardAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.cardAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAccent.Location = New System.Drawing.Point(0, 0)
        Me.cardAccent.Name = "cardAccent"
        Me.cardAccent.Size = New System.Drawing.Size(1150, 4)
        Me.cardAccent.TabIndex = 0
        '
        'lblSection1
        '
        Me.lblSection1.AutoSize = True
        Me.lblSection1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSection1.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSection1.Location = New System.Drawing.Point(20, 14)
        Me.lblSection1.Name = "lblSection1"
        Me.lblSection1.Size = New System.Drawing.Size(262, 21)
        Me.lblSection1.TabIndex = 1
        Me.lblSection1.Text = "📝  New Athlete Tryout Registration"
        '
        'lblRegSub
        '
        Me.lblRegSub.AutoSize = True
        Me.lblRegSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblRegSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblRegSub.Location = New System.Drawing.Point(22, 38)
        Me.lblRegSub.Name = "lblRegSub"
        Me.lblRegSub.Size = New System.Drawing.Size(435, 15)
        Me.lblRegSub.TabIndex = 2
        Me.lblRegSub.Text = "Complete the tryout registration form below. All required fields are marked with an asterisk (*)."
        '
        'lblRegBadge
        '
        Me.lblRegBadge.BackColor = System.Drawing.Color.FromArgb(204, 251, 241)
        Me.lblRegBadge.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblRegBadge.ForeColor = System.Drawing.Color.FromArgb(15, 118, 110)
        Me.lblRegBadge.Location = New System.Drawing.Point(950, 14)
        Me.lblRegBadge.Name = "lblRegBadge"
        Me.lblRegBadge.Size = New System.Drawing.Size(180, 24)
        Me.lblRegBadge.TabIndex = 3
        Me.lblRegBadge.Text = "● Open Tryout Season"
        Me.lblRegBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStudentNo
        '
        Me.lblStudentNo.AutoSize = True
        Me.lblStudentNo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentNo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblStudentNo.Location = New System.Drawing.Point(20, 62)
        Me.lblStudentNo.Name = "lblStudentNo"
        Me.lblStudentNo.Size = New System.Drawing.Size(126, 15)
        Me.lblStudentNo.TabIndex = 4
        Me.lblStudentNo.Text = "STUDENT ID NUMBER *"
        '
        'txtStudentNumber
        '
        Me.txtStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStudentNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtStudentNumber.Location = New System.Drawing.Point(20, 82)
        Me.txtStudentNumber.Name = "txtStudentNumber"
        Me.txtStudentNumber.Size = New System.Drawing.Size(260, 25)
        Me.txtStudentNumber.TabIndex = 5
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFirst.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblFirst.Location = New System.Drawing.Point(300, 62)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(83, 15)
        Me.lblFirst.TabIndex = 6
        Me.lblFirst.Text = "FIRST NAME *"
        '
        'txtFirstName
        '
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtFirstName.Location = New System.Drawing.Point(300, 82)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(260, 25)
        Me.txtFirstName.TabIndex = 7
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblMiddle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblMiddle.Location = New System.Drawing.Point(580, 62)
        Me.lblMiddle.Name = "lblMiddle"
        Me.lblMiddle.Size = New System.Drawing.Size(87, 15)
        Me.lblMiddle.TabIndex = 8
        Me.lblMiddle.Text = "MIDDLE NAME"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMiddleName.Location = New System.Drawing.Point(580, 82)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(260, 25)
        Me.txtMiddleName.TabIndex = 9
        '
        'lblLast
        '
        Me.lblLast.AutoSize = True
        Me.lblLast.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblLast.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblLast.Location = New System.Drawing.Point(860, 62)
        Me.lblLast.Name = "lblLast"
        Me.lblLast.Size = New System.Drawing.Size(80, 15)
        Me.lblLast.TabIndex = 10
        Me.lblLast.Text = "LAST NAME *"
        '
        'txtLastName
        '
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtLastName.Location = New System.Drawing.Point(860, 82)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(260, 25)
        Me.txtLastName.TabIndex = 11
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblCourse.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblCourse.Location = New System.Drawing.Point(20, 122)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(60, 15)
        Me.lblCourse.TabIndex = 12
        Me.lblCourse.Text = "COURSE *"
        '
        'cmbCourse
        '
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCourse.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Items.AddRange(New Object() {"BSIT", "BSCRIM", "BsPOLSCI", "BSOA", "BSED", "CAS"})
        Me.cmbCourse.Location = New System.Drawing.Point(20, 142)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(260, 25)
        Me.cmbCourse.TabIndex = 13
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblYear.Location = New System.Drawing.Point(300, 122)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(78, 15)
        Me.lblYear.TabIndex = 14
        Me.lblYear.Text = "YEAR LEVEL *"
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbYear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"1st Year", "2nd Year", "3rd Year", "4th Year"})
        Me.cmbYear.Location = New System.Drawing.Point(300, 142)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(260, 25)
        Me.cmbYear.TabIndex = 15
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblGender.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblGender.Location = New System.Drawing.Point(580, 122)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(61, 15)
        Me.lblGender.TabIndex = 16
        Me.lblGender.Text = "GENDER *"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(580, 142)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(260, 25)
        Me.cmbGender.TabIndex = 17
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblSport.Location = New System.Drawing.Point(860, 122)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(117, 15)
        Me.lblSport.TabIndex = 18
        Me.lblSport.Text = "PREFERRED SPORT *"
        '
        'cmbSport
        '
        Me.cmbSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSport.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSport.FormattingEnabled = True
        Me.cmbSport.Location = New System.Drawing.Point(860, 142)
        Me.cmbSport.Name = "cmbSport"
        Me.cmbSport.Size = New System.Drawing.Size(260, 25)
        Me.cmbSport.TabIndex = 19
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblContact.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblContact.Location = New System.Drawing.Point(20, 182)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(111, 15)
        Me.lblContact.TabIndex = 20
        Me.lblContact.Text = "CONTACT NUMBER"
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtContact.Location = New System.Drawing.Point(20, 202)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(540, 25)
        Me.txtContact.TabIndex = 21
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblEmail.Location = New System.Drawing.Point(580, 182)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(95, 15)
        Me.lblEmail.TabIndex = 22
        Me.lblEmail.Text = "EMAIL ADDRESS"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtEmail.Location = New System.Drawing.Point(580, 202)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(540, 25)
        Me.txtEmail.TabIndex = 23
        '
        'div1
        '
        Me.div1.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.div1.Location = New System.Drawing.Point(20, 246)
        Me.div1.Name = "div1"
        Me.div1.Size = New System.Drawing.Size(1110, 1)
        Me.div1.TabIndex = 24
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegister.FlatAppearance.BorderSize = 0
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRegister.ForeColor = System.Drawing.Color.FromArgb(14, 38, 72)
        Me.btnRegister.Location = New System.Drawing.Point(20, 258)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(220, 42)
        Me.btnRegister.TabIndex = 25
        Me.btnRegister.Text = "✚  Register Applicant"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClear.Location = New System.Drawing.Point(252, 258)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(140, 42)
        Me.btnClear.TabIndex = 26
        Me.btnClear.Text = "↺  Clear Form"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblNoteHint
        '
        Me.lblNoteHint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.lblNoteHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNoteHint.Location = New System.Drawing.Point(408, 266)
        Me.lblNoteHint.Name = "lblNoteHint"
        Me.lblNoteHint.Size = New System.Drawing.Size(700, 26)
        Me.lblNoteHint.TabIndex = 27
        Me.lblNoteHint.Text = "💡 Duplicate registrations for the same sport are prevented. Applicant will immediately appear in Records."
        Me.lblNoteHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlStatusCard (Bottom: Status Tracker & Records Card)
        '
        Me.pnlStatusCard.BackColor = System.Drawing.Color.White
        Me.pnlStatusCard.Controls.Add(Me.statusAccent)
        Me.pnlStatusCard.Controls.Add(Me.lblSection2)
        Me.pnlStatusCard.Controls.Add(Me.lblStatusSub)
        Me.pnlStatusCard.Controls.Add(Me.lblSearchId)
        Me.pnlStatusCard.Controls.Add(Me.txtSearchStudentNumber)
        Me.pnlStatusCard.Controls.Add(Me.btnCheckStatus)
        Me.pnlStatusCard.Controls.Add(Me.dgvStatus)
        Me.pnlStatusCard.Location = New System.Drawing.Point(24, 408)
        Me.pnlStatusCard.Name = "pnlStatusCard"
        Me.pnlStatusCard.Size = New System.Drawing.Size(1150, 310)
        Me.pnlStatusCard.TabIndex = 1
        '
        'statusAccent
        '
        Me.statusAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.statusAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.statusAccent.Location = New System.Drawing.Point(0, 0)
        Me.statusAccent.Name = "statusAccent"
        Me.statusAccent.Size = New System.Drawing.Size(1150, 4)
        Me.statusAccent.TabIndex = 0
        '
        'lblSection2
        '
        Me.lblSection2.AutoSize = True
        Me.lblSection2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSection2.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSection2.Location = New System.Drawing.Point(20, 14)
        Me.lblSection2.Name = "lblSection2"
        Me.lblSection2.Size = New System.Drawing.Size(256, 21)
        Me.lblSection2.TabIndex = 1
        Me.lblSection2.Text = "🔍  Registration Status Verification"
        '
        'lblStatusSub
        '
        Me.lblStatusSub.AutoSize = True
        Me.lblStatusSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblStatusSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatusSub.Location = New System.Drawing.Point(22, 38)
        Me.lblStatusSub.Name = "lblStatusSub"
        Me.lblStatusSub.Size = New System.Drawing.Size(465, 15)
        Me.lblStatusSub.TabIndex = 2
        Me.lblStatusSub.Text = "Search by Student ID to verify registered sports, tryout schedule dates, and current status."
        '
        'lblSearchId
        '
        Me.lblSearchId.AutoSize = True
        Me.lblSearchId.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearchId.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblSearchId.Location = New System.Drawing.Point(680, 20)
        Me.lblSearchId.Name = "lblSearchId"
        Me.lblSearchId.Size = New System.Drawing.Size(66, 15)
        Me.lblSearchId.TabIndex = 3
        Me.lblSearchId.Text = "Student ID:"
        '
        'txtSearchStudentNumber
        '
        Me.txtSearchStudentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchStudentNumber.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearchStudentNumber.Location = New System.Drawing.Point(755, 17)
        Me.txtSearchStudentNumber.Name = "txtSearchStudentNumber"
        Me.txtSearchStudentNumber.Size = New System.Drawing.Size(200, 24)
        Me.txtSearchStudentNumber.TabIndex = 4
        '
        'btnCheckStatus
        '
        Me.btnCheckStatus.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnCheckStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckStatus.FlatAppearance.BorderSize = 0
        Me.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCheckStatus.ForeColor = System.Drawing.Color.White
        Me.btnCheckStatus.Location = New System.Drawing.Point(965, 15)
        Me.btnCheckStatus.Name = "btnCheckStatus"
        Me.btnCheckStatus.Size = New System.Drawing.Size(165, 30)
        Me.btnCheckStatus.TabIndex = 5
        Me.btnCheckStatus.Text = "🔎  Verify Status"
        Me.btnCheckStatus.UseVisualStyleBackColor = False
        '
        'dgvStatus
        '
        Me.dgvStatus.AllowUserToAddRows = False
        Me.dgvStatus.AllowUserToDeleteRows = False
        Me.dgvStatus.AllowUserToResizeRows = False
        Me.dgvStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStatus.BackgroundColor = System.Drawing.Color.White
        Me.dgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        Me.dgvStatus.ColumnHeadersHeight = 36
        Me.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStatus.DefaultCellStyle = dataGridViewCellStyle2
        Me.dgvStatus.EnableHeadersVisualStyles = False
        Me.dgvStatus.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgvStatus.Location = New System.Drawing.Point(20, 60)
        Me.dgvStatus.MultiSelect = False
        Me.dgvStatus.Name = "dgvStatus"
        Me.dgvStatus.ReadOnly = True
        Me.dgvStatus.RowHeadersVisible = False
        Me.dgvStatus.RowTemplate.Height = 32
        Me.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStatus.Size = New System.Drawing.Size(1110, 230)
        Me.dgvStatus.TabIndex = 6
        '
        'frmStudentRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1200, 740)
        Me.Controls.Add(Me.pnlStatusCard)
        Me.Controls.Add(Me.pnlRegCard)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmStudentRegistration"
        Me.Text = "Student-Athlete Tryout Registration"
        Me.pnlRegCard.ResumeLayout(False)
        Me.pnlRegCard.PerformLayout()
        Me.pnlStatusCard.ResumeLayout(False)
        Me.pnlStatusCard.PerformLayout()
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlRegCard As System.Windows.Forms.Panel
    Friend WithEvents cardAccent As System.Windows.Forms.Panel
    Friend WithEvents lblSection1 As System.Windows.Forms.Label
    Friend WithEvents lblRegSub As System.Windows.Forms.Label
    Friend WithEvents lblRegBadge As System.Windows.Forms.Label
    Friend WithEvents lblStudentNo As System.Windows.Forms.Label
    Friend WithEvents txtStudentNumber As System.Windows.Forms.TextBox
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
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblSport As System.Windows.Forms.Label
    Friend WithEvents cmbSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents div1 As System.Windows.Forms.Panel
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblNoteHint As System.Windows.Forms.Label
    Friend WithEvents pnlStatusCard As System.Windows.Forms.Panel
    Friend WithEvents statusAccent As System.Windows.Forms.Panel
    Friend WithEvents lblSection2 As System.Windows.Forms.Label
    Friend WithEvents lblStatusSub As System.Windows.Forms.Label
    Friend WithEvents lblSearchId As System.Windows.Forms.Label
    Friend WithEvents txtSearchStudentNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckStatus As System.Windows.Forms.Button
    Friend WithEvents dgvStatus As System.Windows.Forms.DataGridView
End Class
