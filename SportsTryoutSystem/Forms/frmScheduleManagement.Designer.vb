<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScheduleManagement
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
        Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlScheduleCard = New System.Windows.Forms.Panel()
        Me.cardAccent = New System.Windows.Forms.Panel()
        Me.lblSectionTitle = New System.Windows.Forms.Label()
        Me.lblSectionSub = New System.Windows.Forms.Label()
        Me.lblModeBadge = New System.Windows.Forms.Label()
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
        Me.divCard = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblActionHint = New System.Windows.Forms.Label()
        Me.pnlGridCard = New System.Windows.Forms.Panel()
        Me.gridAccent = New System.Windows.Forms.Panel()
        Me.lblGridTitle = New System.Windows.Forms.Label()
        Me.lblGridSub = New System.Windows.Forms.Label()
        Me.lblCountBadge = New System.Windows.Forms.Label()
        Me.lblFilterSport = New System.Windows.Forms.Label()
        Me.cmbFilterSport = New System.Windows.Forms.ComboBox()
        Me.lblFilterStatus = New System.Windows.Forms.Label()
        Me.cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnResetFilter = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.pnlScheduleCard.SuspendLayout()
        Me.pnlGridCard.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlScheduleCard
        '
        Me.pnlScheduleCard.BackColor = System.Drawing.Color.White
        Me.pnlScheduleCard.Controls.Add(Me.cardAccent)
        Me.pnlScheduleCard.Controls.Add(Me.lblSectionTitle)
        Me.pnlScheduleCard.Controls.Add(Me.lblSectionSub)
        Me.pnlScheduleCard.Controls.Add(Me.lblModeBadge)
        Me.pnlScheduleCard.Controls.Add(Me.lblSport)
        Me.pnlScheduleCard.Controls.Add(Me.cmbSport)
        Me.pnlScheduleCard.Controls.Add(Me.lblDate)
        Me.pnlScheduleCard.Controls.Add(Me.dtpDate)
        Me.pnlScheduleCard.Controls.Add(Me.lblTime)
        Me.pnlScheduleCard.Controls.Add(Me.dtpTime)
        Me.pnlScheduleCard.Controls.Add(Me.lblStatus)
        Me.pnlScheduleCard.Controls.Add(Me.cmbStatus)
        Me.pnlScheduleCard.Controls.Add(Me.lblVenue)
        Me.pnlScheduleCard.Controls.Add(Me.txtVenue)
        Me.pnlScheduleCard.Controls.Add(Me.lblNotes)
        Me.pnlScheduleCard.Controls.Add(Me.txtNotes)
        Me.pnlScheduleCard.Controls.Add(Me.divCard)
        Me.pnlScheduleCard.Controls.Add(Me.btnAdd)
        Me.pnlScheduleCard.Controls.Add(Me.btnUpdate)
        Me.pnlScheduleCard.Controls.Add(Me.btnDelete)
        Me.pnlScheduleCard.Controls.Add(Me.btnClear)
        Me.pnlScheduleCard.Controls.Add(Me.lblActionHint)
        Me.pnlScheduleCard.Location = New System.Drawing.Point(24, 72)
        Me.pnlScheduleCard.Name = "pnlScheduleCard"
        Me.pnlScheduleCard.Size = New System.Drawing.Size(1072, 270)
        Me.pnlScheduleCard.TabIndex = 1
        '
        'cardAccent
        '
        Me.cardAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.cardAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardAccent.Location = New System.Drawing.Point(0, 0)
        Me.cardAccent.Name = "cardAccent"
        Me.cardAccent.Size = New System.Drawing.Size(1072, 3)
        Me.cardAccent.TabIndex = 0
        '
        'lblSectionTitle
        '
        Me.lblSectionTitle.AutoSize = True
        Me.lblSectionTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblSectionTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblSectionTitle.Name = "lblSectionTitle"
        Me.lblSectionTitle.Size = New System.Drawing.Size(262, 21)
        Me.lblSectionTitle.TabIndex = 1
        Me.lblSectionTitle.Text = "TRYOUT SESSION CONFIGURATION"
        '
        'lblSectionSub
        '
        Me.lblSectionSub.AutoSize = True
        Me.lblSectionSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSectionSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSectionSub.Location = New System.Drawing.Point(22, 38)
        Me.lblSectionSub.Name = "lblSectionSub"
        Me.lblSectionSub.Size = New System.Drawing.Size(350, 15)
        Me.lblSectionSub.TabIndex = 2
        Me.lblSectionSub.Text = "Schedule and configure tryout sessions, venues, and status tracking"
        '
        'lblModeBadge
        '
        Me.lblModeBadge.BackColor = System.Drawing.Color.FromArgb(220, 252, 231)
        Me.lblModeBadge.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblModeBadge.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52)
        Me.lblModeBadge.Location = New System.Drawing.Point(880, 14)
        Me.lblModeBadge.Name = "lblModeBadge"
        Me.lblModeBadge.Size = New System.Drawing.Size(170, 24)
        Me.lblModeBadge.TabIndex = 3
        Me.lblModeBadge.Text = "✚ NEW SESSION MODE"
        Me.lblModeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSport
        '
        Me.lblSport.AutoSize = True
        Me.lblSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSport.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSport.Location = New System.Drawing.Point(20, 64)
        Me.lblSport.Name = "lblSport"
        Me.lblSport.Size = New System.Drawing.Size(43, 15)
        Me.lblSport.TabIndex = 4
        Me.lblSport.Text = "SPORT"
        '
        'cmbSport
        '
        Me.cmbSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSport.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbSport.FormattingEnabled = True
        Me.cmbSport.Location = New System.Drawing.Point(20, 86)
        Me.cmbSport.Name = "cmbSport"
        Me.cmbSport.Size = New System.Drawing.Size(240, 25)
        Me.cmbSport.TabIndex = 5
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDate.Location = New System.Drawing.Point(280, 64)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(81, 15)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "TRYOUT DATE"
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(280, 86)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(240, 25)
        Me.dtpDate.TabIndex = 7
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTime.Location = New System.Drawing.Point(540, 64)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(78, 15)
        Me.lblTime.TabIndex = 8
        Me.lblTime.Text = "START TIME"
        '
        'dtpTime
        '
        Me.dtpTime.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(540, 86)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(240, 25)
        Me.dtpTime.TabIndex = 9
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblStatus.Location = New System.Drawing.Point(800, 64)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(49, 15)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.Text = "STATUS"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Upcoming", "Completed", "Cancelled"})
        Me.cmbStatus.Location = New System.Drawing.Point(800, 86)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(240, 25)
        Me.cmbStatus.TabIndex = 11
        '
        'lblVenue
        '
        Me.lblVenue.AutoSize = True
        Me.lblVenue.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblVenue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblVenue.Location = New System.Drawing.Point(20, 126)
        Me.lblVenue.Name = "lblVenue"
        Me.lblVenue.Size = New System.Drawing.Size(107, 15)
        Me.lblVenue.TabIndex = 12
        Me.lblVenue.Text = "VENUE / LOCATION"
        '
        'txtVenue
        '
        Me.txtVenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenue.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtVenue.Location = New System.Drawing.Point(20, 148)
        Me.txtVenue.Name = "txtVenue"
        Me.txtVenue.Size = New System.Drawing.Size(500, 25)
        Me.txtVenue.TabIndex = 13
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNotes.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNotes.Location = New System.Drawing.Point(540, 126)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(183, 15)
        Me.lblNotes.TabIndex = 14
        Me.lblNotes.Text = "SPECIAL NOTES / INSTRUCTIONS"
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNotes.Location = New System.Drawing.Point(540, 148)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(500, 25)
        Me.txtNotes.TabIndex = 15
        '
        'divCard
        '
        Me.divCard.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.divCard.Location = New System.Drawing.Point(20, 194)
        Me.divCard.Name = "divCard"
        Me.divCard.Size = New System.Drawing.Size(1030, 1)
        Me.divCard.TabIndex = 16
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(20, 208)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(175, 42)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = "✚  Add Schedule"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(37, 80, 140)
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(205, 208)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(160, 42)
        Me.btnUpdate.TabIndex = 18
        Me.btnUpdate.Text = "✎  Update Schedule"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(375, 208)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(150, 42)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "✕  Delete Schedule"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClear.Location = New System.Drawing.Point(535, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(130, 42)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Text = "↺  Reset Fields"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblActionHint
        '
        Me.lblActionHint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblActionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblActionHint.Location = New System.Drawing.Point(680, 218)
        Me.lblActionHint.Name = "lblActionHint"
        Me.lblActionHint.Size = New System.Drawing.Size(370, 24)
        Me.lblActionHint.TabIndex = 21
        Me.lblActionHint.Text = "💡 Tip: Click any row in the schedule table below to inspect, edit, or delete."
        Me.lblActionHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlGridCard
        '
        Me.pnlGridCard.BackColor = System.Drawing.Color.White
        Me.pnlGridCard.Controls.Add(Me.gridAccent)
        Me.pnlGridCard.Controls.Add(Me.lblGridTitle)
        Me.pnlGridCard.Controls.Add(Me.lblGridSub)
        Me.pnlGridCard.Controls.Add(Me.lblCountBadge)
        Me.pnlGridCard.Controls.Add(Me.lblFilterSport)
        Me.pnlGridCard.Controls.Add(Me.cmbFilterSport)
        Me.pnlGridCard.Controls.Add(Me.lblFilterStatus)
        Me.pnlGridCard.Controls.Add(Me.cmbFilterStatus)
        Me.pnlGridCard.Controls.Add(Me.lblSearch)
        Me.pnlGridCard.Controls.Add(Me.txtSearch)
        Me.pnlGridCard.Controls.Add(Me.btnResetFilter)
        Me.pnlGridCard.Controls.Add(Me.dgv)
        Me.pnlGridCard.Location = New System.Drawing.Point(24, 358)
        Me.pnlGridCard.Name = "pnlGridCard"
        Me.pnlGridCard.Size = New System.Drawing.Size(1072, 360)
        Me.pnlGridCard.TabIndex = 2
        '
        'gridAccent
        '
        Me.gridAccent.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.gridAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAccent.Location = New System.Drawing.Point(0, 0)
        Me.gridAccent.Name = "gridAccent"
        Me.gridAccent.Size = New System.Drawing.Size(1072, 3)
        Me.gridAccent.TabIndex = 0
        '
        'lblGridTitle
        '
        Me.lblGridTitle.AutoSize = True
        Me.lblGridTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblGridTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblGridTitle.Name = "lblGridTitle"
        Me.lblGridTitle.Size = New System.Drawing.Size(243, 21)
        Me.lblGridTitle.TabIndex = 1
        Me.lblGridTitle.Text = "SCHEDULED TRYOUT TIMETABLE"
        '
        'lblGridSub
        '
        Me.lblGridSub.AutoSize = True
        Me.lblGridSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblGridSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblGridSub.Location = New System.Drawing.Point(22, 38)
        Me.lblGridSub.Name = "lblGridSub"
        Me.lblGridSub.Size = New System.Drawing.Size(325, 15)
        Me.lblGridSub.TabIndex = 2
        Me.lblGridSub.Text = "Overview of active sessions, venues, and athletic evaluations"
        '
        'lblCountBadge
        '
        Me.lblCountBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        Me.lblCountBadge.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblCountBadge.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
        Me.lblCountBadge.Location = New System.Drawing.Point(880, 14)
        Me.lblCountBadge.Name = "lblCountBadge"
        Me.lblCountBadge.Size = New System.Drawing.Size(170, 24)
        Me.lblCountBadge.TabIndex = 3
        Me.lblCountBadge.Text = "0 Sessions Listed"
        Me.lblCountBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFilterSport
        '
        Me.lblFilterSport.AutoSize = True
        Me.lblFilterSport.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFilterSport.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFilterSport.Location = New System.Drawing.Point(20, 68)
        Me.lblFilterSport.Name = "lblFilterSport"
        Me.lblFilterSport.Size = New System.Drawing.Size(39, 15)
        Me.lblFilterSport.TabIndex = 4
        Me.lblFilterSport.Text = "Sport:"
        '
        'cmbFilterSport
        '
        Me.cmbFilterSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterSport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterSport.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterSport.FormattingEnabled = True
        Me.cmbFilterSport.Location = New System.Drawing.Point(65, 64)
        Me.cmbFilterSport.Name = "cmbFilterSport"
        Me.cmbFilterSport.Size = New System.Drawing.Size(180, 24)
        Me.cmbFilterSport.TabIndex = 5
        '
        'lblFilterStatus
        '
        Me.lblFilterStatus.AutoSize = True
        Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFilterStatus.Location = New System.Drawing.Point(260, 68)
        Me.lblFilterStatus.Name = "lblFilterStatus"
        Me.lblFilterStatus.Size = New System.Drawing.Size(43, 15)
        Me.lblFilterStatus.TabIndex = 6
        Me.lblFilterStatus.Text = "Status:"
        '
        'cmbFilterStatus
        '
        Me.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbFilterStatus.FormattingEnabled = True
        Me.cmbFilterStatus.Items.AddRange(New Object() {"All", "Upcoming", "Completed", "Cancelled"})
        Me.cmbFilterStatus.Location = New System.Drawing.Point(310, 64)
        Me.cmbFilterStatus.Name = "cmbFilterStatus"
        Me.cmbFilterStatus.Size = New System.Drawing.Size(140, 24)
        Me.cmbFilterStatus.TabIndex = 7
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSearch.Location = New System.Drawing.Point(465, 68)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(124, 15)
        Me.lblSearch.TabIndex = 8
        Me.lblSearch.Text = "🔍 Search Venue/Notes:"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearch.Location = New System.Drawing.Point(595, 64)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(220, 24)
        Me.txtSearch.TabIndex = 9
        '
        'btnResetFilter
        '
        Me.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetFilter.FlatAppearance.BorderSize = 0
        Me.btnResetFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.btnResetFilter.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnResetFilter.Location = New System.Drawing.Point(825, 63)
        Me.btnResetFilter.Name = "btnResetFilter"
        Me.btnResetFilter.Size = New System.Drawing.Size(115, 27)
        Me.btnResetFilter.TabIndex = 10
        Me.btnResetFilter.Text = "↺ Clear Filters"
        Me.btnResetFilter.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(253, 224, 71)
        dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 40
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        dataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = dataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgv.Location = New System.Drawing.Point(20, 102)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3
        Me.dgv.RowTemplate.Height = 38
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(1030, 240)
        Me.dgv.TabIndex = 11
        '
        'frmScheduleManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1120, 740)
        Me.Controls.Add(Me.pnlGridCard)
        Me.Controls.Add(Me.pnlScheduleCard)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmScheduleManagement"
        Me.Text = "Tryout Schedule Management"
        Me.pnlScheduleCard.ResumeLayout(False)
        Me.pnlScheduleCard.PerformLayout()
        Me.pnlGridCard.ResumeLayout(False)
        Me.pnlGridCard.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlScheduleCard As System.Windows.Forms.Panel
    Friend WithEvents cardAccent As System.Windows.Forms.Panel
    Friend WithEvents lblSectionTitle As System.Windows.Forms.Label
    Friend WithEvents lblSectionSub As System.Windows.Forms.Label
    Friend WithEvents lblModeBadge As System.Windows.Forms.Label
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
    Friend WithEvents divCard As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblActionHint As System.Windows.Forms.Label
    Friend WithEvents pnlGridCard As System.Windows.Forms.Panel
    Friend WithEvents gridAccent As System.Windows.Forms.Panel
    Friend WithEvents lblGridTitle As System.Windows.Forms.Label
    Friend WithEvents lblGridSub As System.Windows.Forms.Label
    Friend WithEvents lblCountBadge As System.Windows.Forms.Label
    Friend WithEvents lblFilterSport As System.Windows.Forms.Label
    Friend WithEvents cmbFilterSport As System.Windows.Forms.ComboBox
    Friend WithEvents lblFilterStatus As System.Windows.Forms.Label
    Friend WithEvents cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnResetFilter As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
End Class
