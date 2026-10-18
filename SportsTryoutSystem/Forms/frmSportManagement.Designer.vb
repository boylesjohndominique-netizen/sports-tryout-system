<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSportManagement
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

        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.formAccent = New System.Windows.Forms.Panel()
        Me.lblFormHeader = New System.Windows.Forms.Label()
        Me.lblFormSub = New System.Windows.Forms.Label()
        Me.lblSportIdBadge = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtSportName = New System.Windows.Forms.TextBox()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()

        Me.pnlGridCard = New System.Windows.Forms.Panel()
        Me.gridAccent = New System.Windows.Forms.Panel()
        Me.lblGridTitle = New System.Windows.Forms.Label()
        Me.lblGridCounter = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearchSport = New System.Windows.Forms.TextBox()
        Me.dgv = New System.Windows.Forms.DataGridView()

        Me.pnlCoaches = New System.Windows.Forms.Panel()
        Me.coachAccent = New System.Windows.Forms.Panel()
        Me.lblCoachTitle = New System.Windows.Forms.Label()
        Me.lblCoachHint = New System.Windows.Forms.Label()
        Me.pnlSelectedSportInfo = New System.Windows.Forms.Panel()
        Me.lblSelectedSportPrompt = New System.Windows.Forms.Label()
        Me.btnSelectAllCoaches = New System.Windows.Forms.Button()
        Me.btnClearAllCoaches = New System.Windows.Forms.Button()
        Me.lblCoachCount = New System.Windows.Forms.Label()
        Me.clbCoaches = New System.Windows.Forms.CheckedListBox()
        Me.btnSaveCoaches = New System.Windows.Forms.Button()

        Me.pnlForm.SuspendLayout()
        Me.pnlGridCard.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCoaches.SuspendLayout()
        Me.pnlSelectedSportInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlForm (Sport Details & Actions Card)
        '
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Controls.Add(Me.formAccent)
        Me.pnlForm.Controls.Add(Me.lblFormHeader)
        Me.pnlForm.Controls.Add(Me.lblFormSub)
        Me.pnlForm.Controls.Add(Me.lblSportIdBadge)
        Me.pnlForm.Controls.Add(Me.lblName)
        Me.pnlForm.Controls.Add(Me.txtSportName)
        Me.pnlForm.Controls.Add(Me.chkIsActive)
        Me.pnlForm.Controls.Add(Me.lblDesc)
        Me.pnlForm.Controls.Add(Me.txtDescription)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)
        Me.pnlForm.Location = New System.Drawing.Point(25, 75)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Size = New System.Drawing.Size(680, 245)
        Me.pnlForm.TabIndex = 1
        '
        'formAccent
        '
        Me.formAccent.BackColor = System.Drawing.Color.FromArgb(234, 179, 8)
        Me.formAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.formAccent.Location = New System.Drawing.Point(0, 0)
        Me.formAccent.Name = "formAccent"
        Me.formAccent.Size = New System.Drawing.Size(680, 4)
        Me.formAccent.TabIndex = 0
        '
        'lblFormHeader
        '
        Me.lblFormHeader.AutoSize = True
        Me.lblFormHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblFormHeader.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblFormHeader.Location = New System.Drawing.Point(20, 14)
        Me.lblFormHeader.Name = "lblFormHeader"
        Me.lblFormHeader.Size = New System.Drawing.Size(225, 21)
        Me.lblFormHeader.TabIndex = 1
        Me.lblFormHeader.Text = "⚡ Sport Details & Configuration"
        '
        'lblFormSub
        '
        Me.lblFormSub.AutoSize = True
        Me.lblFormSub.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblFormSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFormSub.Location = New System.Drawing.Point(22, 38)
        Me.lblFormSub.Name = "lblFormSub"
        Me.lblFormSub.Size = New System.Drawing.Size(325, 15)
        Me.lblFormSub.TabIndex = 2
        Me.lblFormSub.Text = "Register new sport disciplines or modify active status and notes."
        '
        'lblSportIdBadge
        '
        Me.lblSportIdBadge.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblSportIdBadge.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSportIdBadge.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblSportIdBadge.Location = New System.Drawing.Point(520, 14)
        Me.lblSportIdBadge.Name = "lblSportIdBadge"
        Me.lblSportIdBadge.Size = New System.Drawing.Size(140, 24)
        Me.lblSportIdBadge.TabIndex = 3
        Me.lblSportIdBadge.Text = "Mode: New Sport"
        Me.lblSportIdBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblName.Location = New System.Drawing.Point(20, 68)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(89, 15)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "SPORT NAME *"
        '
        'txtSportName
        '
        Me.txtSportName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSportName.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtSportName.Location = New System.Drawing.Point(20, 88)
        Me.txtSportName.Name = "txtSportName"
        Me.txtSportName.Size = New System.Drawing.Size(430, 26)
        Me.txtSportName.TabIndex = 5
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.chkIsActive.Location = New System.Drawing.Point(470, 89)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(145, 23)
        Me.chkIsActive.TabIndex = 6
        Me.chkIsActive.Text = "Active for Tryouts"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblDesc.Location = New System.Drawing.Point(20, 126)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(133, 15)
        Me.lblDesc.TabIndex = 7
        Me.lblDesc.Text = "DESCRIPTION / NOTES"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDescription.Location = New System.Drawing.Point(20, 146)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(640, 25)
        Me.txtDescription.TabIndex = 8
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(20, 188)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(150, 40)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "✚  Add Sport"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(180, 188)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(150, 40)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "✎  Update Sport"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(340, 188)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(150, 40)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "✕  Delete Sport"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClear.Location = New System.Drawing.Point(500, 188)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(140, 40)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "↺  Reset Fields"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'pnlGridCard (Sports Directory Card)
        '
        Me.pnlGridCard.BackColor = System.Drawing.Color.White
        Me.pnlGridCard.Controls.Add(Me.gridAccent)
        Me.pnlGridCard.Controls.Add(Me.lblGridTitle)
        Me.pnlGridCard.Controls.Add(Me.lblGridCounter)
        Me.pnlGridCard.Controls.Add(Me.lblSearch)
        Me.pnlGridCard.Controls.Add(Me.txtSearchSport)
        Me.pnlGridCard.Controls.Add(Me.dgv)
        Me.pnlGridCard.Location = New System.Drawing.Point(25, 335)
        Me.pnlGridCard.Name = "pnlGridCard"
        Me.pnlGridCard.Size = New System.Drawing.Size(680, 320)
        Me.pnlGridCard.TabIndex = 2
        '
        'gridAccent
        '
        Me.gridAccent.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.gridAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.gridAccent.Location = New System.Drawing.Point(0, 0)
        Me.gridAccent.Name = "gridAccent"
        Me.gridAccent.Size = New System.Drawing.Size(680, 4)
        Me.gridAccent.TabIndex = 0
        '
        'lblGridTitle
        '
        Me.lblGridTitle.AutoSize = True
        Me.lblGridTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblGridTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblGridTitle.Name = "lblGridTitle"
        Me.lblGridTitle.Size = New System.Drawing.Size(225, 21)
        Me.lblGridTitle.TabIndex = 1
        Me.lblGridTitle.Text = "🏆 Registered Sports Directory"
        '
        'lblGridCounter
        '
        Me.lblGridCounter.AutoSize = True
        Me.lblGridCounter.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.lblGridCounter.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblGridCounter.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblGridCounter.Location = New System.Drawing.Point(255, 17)
        Me.lblGridCounter.Name = "lblGridCounter"
        Me.lblGridCounter.Size = New System.Drawing.Size(86, 15)
        Me.lblGridCounter.TabIndex = 2
        Me.lblGridCounter.Text = "Total: 0 Sports"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSearch.Location = New System.Drawing.Point(375, 17)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(58, 15)
        Me.lblSearch.TabIndex = 3
        Me.lblSearch.Text = "🔍 Search:"
        '
        'txtSearchSport
        '
        Me.txtSearchSport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchSport.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtSearchSport.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.txtSearchSport.Location = New System.Drawing.Point(440, 14)
        Me.txtSearchSport.Name = "txtSearchSport"
        Me.txtSearchSport.Size = New System.Drawing.Size(220, 24)
        Me.txtSearchSport.TabIndex = 3
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
        dataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254)
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = dataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.dgv.Location = New System.Drawing.Point(20, 50)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 36
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(640, 250)
        Me.dgv.TabIndex = 4
        '
        'pnlCoaches (Coach Assignment Card)
        '
        Me.pnlCoaches.BackColor = System.Drawing.Color.White
        Me.pnlCoaches.Controls.Add(Me.coachAccent)
        Me.pnlCoaches.Controls.Add(Me.lblCoachTitle)
        Me.pnlCoaches.Controls.Add(Me.lblCoachHint)
        Me.pnlCoaches.Controls.Add(Me.pnlSelectedSportInfo)
        Me.pnlCoaches.Controls.Add(Me.btnSelectAllCoaches)
        Me.pnlCoaches.Controls.Add(Me.btnClearAllCoaches)
        Me.pnlCoaches.Controls.Add(Me.lblCoachCount)
        Me.pnlCoaches.Controls.Add(Me.clbCoaches)
        Me.pnlCoaches.Controls.Add(Me.btnSaveCoaches)
        Me.pnlCoaches.Location = New System.Drawing.Point(725, 75)
        Me.pnlCoaches.Name = "pnlCoaches"
        Me.pnlCoaches.Size = New System.Drawing.Size(430, 580)
        Me.pnlCoaches.TabIndex = 3
        '
        'coachAccent
        '
        Me.coachAccent.BackColor = System.Drawing.Color.FromArgb(59, 130, 246)
        Me.coachAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.coachAccent.Location = New System.Drawing.Point(0, 0)
        Me.coachAccent.Name = "coachAccent"
        Me.coachAccent.Size = New System.Drawing.Size(430, 4)
        Me.coachAccent.TabIndex = 0
        '
        'lblCoachTitle
        '
        Me.lblCoachTitle.AutoSize = True
        Me.lblCoachTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.5!, System.Drawing.FontStyle.Bold)
        Me.lblCoachTitle.ForeColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.lblCoachTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblCoachTitle.Name = "lblCoachTitle"
        Me.lblCoachTitle.Size = New System.Drawing.Size(262, 21)
        Me.lblCoachTitle.TabIndex = 1
        Me.lblCoachTitle.Text = "👥 Coach & Evaluator Assignment"
        '
        'lblCoachHint
        '
        Me.lblCoachHint.AutoSize = True
        Me.lblCoachHint.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCoachHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCoachHint.Location = New System.Drawing.Point(22, 38)
        Me.lblCoachHint.Name = "lblCoachHint"
        Me.lblCoachHint.Size = New System.Drawing.Size(296, 15)
        Me.lblCoachHint.TabIndex = 2
        Me.lblCoachHint.Text = "Assign certified coaches to evaluate tryouts for this sport."
        '
        'pnlSelectedSportInfo
        '
        Me.pnlSelectedSportInfo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlSelectedSportInfo.Controls.Add(Me.lblSelectedSportPrompt)
        Me.pnlSelectedSportInfo.Location = New System.Drawing.Point(20, 60)
        Me.pnlSelectedSportInfo.Name = "pnlSelectedSportInfo"
        Me.pnlSelectedSportInfo.Size = New System.Drawing.Size(390, 36)
        Me.pnlSelectedSportInfo.TabIndex = 3
        '
        'lblSelectedSportPrompt
        '
        Me.lblSelectedSportPrompt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSelectedSportPrompt.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelectedSportPrompt.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblSelectedSportPrompt.Location = New System.Drawing.Point(0, 0)
        Me.lblSelectedSportPrompt.Name = "lblSelectedSportPrompt"
        Me.lblSelectedSportPrompt.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblSelectedSportPrompt.Size = New System.Drawing.Size(390, 36)
        Me.lblSelectedSportPrompt.TabIndex = 0
        Me.lblSelectedSportPrompt.Text = "ℹ️ Select a sport from the directory to assign coaches."
        Me.lblSelectedSportPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSelectAllCoaches
        '
        Me.btnSelectAllCoaches.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnSelectAllCoaches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelectAllCoaches.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnSelectAllCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAllCoaches.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.btnSelectAllCoaches.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnSelectAllCoaches.Location = New System.Drawing.Point(20, 104)
        Me.btnSelectAllCoaches.Name = "btnSelectAllCoaches"
        Me.btnSelectAllCoaches.Size = New System.Drawing.Size(95, 28)
        Me.btnSelectAllCoaches.TabIndex = 4
        Me.btnSelectAllCoaches.Text = "✓ Select All"
        Me.btnSelectAllCoaches.UseVisualStyleBackColor = False
        '
        'btnClearAllCoaches
        '
        Me.btnClearAllCoaches.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnClearAllCoaches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAllCoaches.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnClearAllCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAllCoaches.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.btnClearAllCoaches.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.btnClearAllCoaches.Location = New System.Drawing.Point(122, 104)
        Me.btnClearAllCoaches.Name = "btnClearAllCoaches"
        Me.btnClearAllCoaches.Size = New System.Drawing.Size(95, 28)
        Me.btnClearAllCoaches.TabIndex = 5
        Me.btnClearAllCoaches.Text = "✕ Clear All"
        Me.btnClearAllCoaches.UseVisualStyleBackColor = False
        '
        'lblCoachCount
        '
        Me.lblCoachCount.AutoSize = True
        Me.lblCoachCount.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblCoachCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCoachCount.Location = New System.Drawing.Point(320, 111)
        Me.lblCoachCount.Name = "lblCoachCount"
        Me.lblCoachCount.Size = New System.Drawing.Size(90, 15)
        Me.lblCoachCount.TabIndex = 6
        Me.lblCoachCount.Text = "0 Coaches Avail"
        Me.lblCoachCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'clbCoaches
        '
        Me.clbCoaches.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.clbCoaches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbCoaches.CheckOnClick = True
        Me.clbCoaches.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.clbCoaches.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.clbCoaches.FormattingEnabled = True
        Me.clbCoaches.Location = New System.Drawing.Point(20, 140)
        Me.clbCoaches.Name = "clbCoaches"
        Me.clbCoaches.Size = New System.Drawing.Size(390, 370)
        Me.clbCoaches.TabIndex = 7
        '
        'btnSaveCoaches
        '
        Me.btnSaveCoaches.BackColor = System.Drawing.Color.FromArgb(22, 55, 100)
        Me.btnSaveCoaches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveCoaches.FlatAppearance.BorderSize = 0
        Me.btnSaveCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveCoaches.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveCoaches.ForeColor = System.Drawing.Color.White
        Me.btnSaveCoaches.Location = New System.Drawing.Point(20, 522)
        Me.btnSaveCoaches.Name = "btnSaveCoaches"
        Me.btnSaveCoaches.Size = New System.Drawing.Size(390, 44)
        Me.btnSaveCoaches.TabIndex = 8
        Me.btnSaveCoaches.Text = "💾  Save Coach Assignments"
        Me.btnSaveCoaches.UseVisualStyleBackColor = False
        '
        'frmSportManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(1180, 680)
        Me.Controls.Add(Me.pnlCoaches)
        Me.Controls.Add(Me.pnlGridCard)
        Me.Controls.Add(Me.pnlForm)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSportManagement"
        Me.Text = "Sport Management"
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlGridCard.ResumeLayout(False)
        Me.pnlGridCard.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCoaches.ResumeLayout(False)
        Me.pnlCoaches.PerformLayout()
        Me.pnlSelectedSportInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents formAccent As System.Windows.Forms.Panel
    Friend WithEvents lblFormHeader As System.Windows.Forms.Label
    Friend WithEvents lblFormSub As System.Windows.Forms.Label
    Friend WithEvents lblSportIdBadge As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtSportName As System.Windows.Forms.TextBox
    Friend WithEvents chkIsActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

    Friend WithEvents pnlGridCard As System.Windows.Forms.Panel
    Friend WithEvents gridAccent As System.Windows.Forms.Panel
    Friend WithEvents lblGridTitle As System.Windows.Forms.Label
    Friend WithEvents lblGridCounter As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearchSport As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView

    Friend WithEvents pnlCoaches As System.Windows.Forms.Panel
    Friend WithEvents coachAccent As System.Windows.Forms.Panel
    Friend WithEvents lblCoachTitle As System.Windows.Forms.Label
    Friend WithEvents lblCoachHint As System.Windows.Forms.Label
    Friend WithEvents pnlSelectedSportInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSelectedSportPrompt As System.Windows.Forms.Label
    Friend WithEvents btnSelectAllCoaches As System.Windows.Forms.Button
    Friend WithEvents btnClearAllCoaches As System.Windows.Forms.Button
    Friend WithEvents lblCoachCount As System.Windows.Forms.Label
    Friend WithEvents clbCoaches As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSaveCoaches As System.Windows.Forms.Button

End Class
