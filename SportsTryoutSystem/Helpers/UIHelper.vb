''' <summary>
''' Central design system for the Sports Tryout Management System.
''' Defines the color palette (Blue / Gold / White), typography, and reusable
''' control factory methods so every form shares one polished, consistent look.
''' </summary>
Public Module UIHelper

    ' ── Primary Blues ──────────────────────────────────────────────
    Public ReadOnly ColorPrimary As Color = Color.FromArgb(22, 55, 100)          ' Deep royal blue
    Public ReadOnly ColorPrimaryDark As Color = Color.FromArgb(14, 38, 72)       ' Midnight blue (sidebar)
    Public ReadOnly ColorPrimaryLight As Color = Color.FromArgb(37, 80, 140)     ' Lighter blue (hover states)
    Public ReadOnly ColorAccent As Color = Color.FromArgb(59, 130, 195)          ' Sky blue (links, secondary buttons)

    ' ── Gold / Yellow ─────────────────────────────────────────────
    Public ReadOnly ColorGold As Color = Color.FromArgb(234, 179, 8)             ' Warm gold
    Public ReadOnly ColorGoldLight As Color = Color.FromArgb(253, 224, 71)       ' Bright yellow highlight
    Public ReadOnly ColorGoldDark As Color = Color.FromArgb(180, 130, 0)         ' Burnished gold

    ' ── Surfaces & Neutrals ───────────────────────────────────────
    Public ReadOnly ColorBackground As Color = Color.FromArgb(245, 247, 250)     ' Cool off-white
    Public ReadOnly ColorSurface As Color = Color.White                          ' Card / panel surface
    Public ReadOnly ColorBorder As Color = Color.FromArgb(218, 225, 234)         ' Subtle border
    Public ReadOnly ColorTextPrimary As Color = Color.FromArgb(30, 41, 59)       ' Headings, strong text
    Public ReadOnly ColorTextSecondary As Color = Color.FromArgb(100, 116, 139)  ' Captions, hints
    Public ReadOnly ColorTextMuted As Color = Color.FromArgb(148, 163, 184)      ' Placeholder / disabled

    ' ── Status Colors ─────────────────────────────────────────────
    Public ReadOnly ColorSuccess As Color = Color.FromArgb(22, 163, 74)          ' Emerald green
    Public ReadOnly ColorDanger As Color = Color.FromArgb(220, 38, 38)           ' Crimson red
    Public ReadOnly ColorWarning As Color = Color.FromArgb(234, 179, 8)          ' Gold (shared)

    ' ── Typography ────────────────────────────────────────────────
    Public ReadOnly FontRegular As New Font("Segoe UI", 9.5!, FontStyle.Regular)
    Public ReadOnly FontBold As New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
    Public ReadOnly FontHeader As New Font("Segoe UI Semibold", 16!, FontStyle.Bold)
    Public ReadOnly FontSubHeader As New Font("Segoe UI Semibold", 11.5!, FontStyle.Bold)
    Public ReadOnly FontCaption As New Font("Segoe UI", 8.5!, FontStyle.Regular)
    Public ReadOnly FontLarge As New Font("Segoe UI Light", 28!, FontStyle.Regular)

    ' ═══════════════════════════════════════════════════════════════
    '  CONTROL FACTORIES
    ' ═══════════════════════════════════════════════════════════════

    Public Function MakeLabel(text As String, x As Integer, y As Integer, Optional w As Integer = 150, Optional bold As Boolean = False) As Label
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Location = New Point(x, y)
        lbl.Size = New Size(w, 22)
        lbl.Font = If(bold, FontBold, FontRegular)
        lbl.ForeColor = ColorTextPrimary
        Return lbl
    End Function

    Public Function MakeTextBox(x As Integer, y As Integer, Optional w As Integer = 200, Optional isPassword As Boolean = False, Optional multiline As Boolean = False) As TextBox
        Dim txt As New TextBox()
        txt.Location = New Point(x, y)
        txt.Size = New Size(w, If(multiline, 80, 28))
        txt.Font = FontRegular
        txt.BorderStyle = BorderStyle.FixedSingle
        txt.BackColor = Color.White
        txt.ForeColor = ColorTextPrimary
        If isPassword Then txt.PasswordChar = CChar("●")
        If multiline Then
            txt.Multiline = True
            txt.ScrollBars = ScrollBars.Vertical
        End If
        Return txt
    End Function

    Public Function MakeButton(text As String, x As Integer, y As Integer, Optional w As Integer = 130, Optional kind As String = "primary") As Button
        Dim btn As New Button()
        btn.Text = text
        btn.Location = New Point(x, y)
        btn.Size = New Size(w, 38)
        btn.Font = FontBold
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Cursor = Cursors.Hand

        Select Case kind
            Case "danger"
                btn.BackColor = ColorDanger
                btn.ForeColor = Color.White
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28)
            Case "success"
                btn.BackColor = ColorSuccess
                btn.ForeColor = Color.White
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61)
            Case "warning"
                btn.BackColor = ColorGold
                btn.ForeColor = ColorPrimaryDark
                btn.FlatAppearance.MouseOverBackColor = ColorGoldDark
            Case "secondary"
                btn.BackColor = Color.FromArgb(226, 232, 240)
                btn.ForeColor = ColorTextPrimary
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(203, 213, 225)
            Case "gold"
                btn.BackColor = ColorGold
                btn.ForeColor = ColorPrimaryDark
                btn.FlatAppearance.MouseOverBackColor = ColorGoldDark
            Case Else ' "primary"
                btn.BackColor = ColorPrimary
                btn.ForeColor = Color.White
                btn.FlatAppearance.MouseOverBackColor = ColorPrimaryLight
        End Select

        Return btn
    End Function

    Public Function MakeComboBox(x As Integer, y As Integer, Optional w As Integer = 200) As ComboBox
        Dim cmb As New ComboBox()
        cmb.Location = New Point(x, y)
        cmb.Size = New Size(w, 28)
        cmb.Font = FontRegular
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.FlatStyle = FlatStyle.Flat
        cmb.BackColor = Color.White
        cmb.ForeColor = ColorTextPrimary
        Return cmb
    End Function

    Public Function MakeDataGridView(x As Integer, y As Integer, w As Integer, h As Integer) As DataGridView
        Dim dgv As New DataGridView()
        dgv.Location = New Point(x, y)
        dgv.Size = New Size(w, h)
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.RowHeadersVisible = False
        dgv.BackgroundColor = Color.White
        dgv.GridColor = ColorBorder
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.Font = FontRegular

        ' Column headers: deep blue with gold accent bottom
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimary
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorGoldLight
        dgv.ColumnHeadersDefaultCellStyle.Font = FontBold
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPrimary
        dgv.ColumnHeadersDefaultCellStyle.Padding = New Padding(8, 0, 0, 0)
        dgv.ColumnHeadersHeight = 38
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgv.EnableHeadersVisualStyles = False

        ' Row styles
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.ForeColor = ColorTextPrimary
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)   ' Pale blue selection
        dgv.DefaultCellStyle.SelectionForeColor = ColorPrimary
        dgv.DefaultCellStyle.Padding = New Padding(6, 0, 0, 0)
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
        dgv.RowTemplate.Height = 32
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        Return dgv
    End Function

    Public Function MakePanelHeader(title As String, parentWidth As Integer) As Panel
        Dim pnl As New Panel()
        pnl.Dock = DockStyle.Top
        pnl.Height = 60
        pnl.BackColor = Color.White

        ' Gold accent stripe at the very top
        Dim stripe As New Panel()
        stripe.Dock = DockStyle.Top
        stripe.Height = 4
        stripe.BackColor = ColorGold

        Dim lbl As New Label()
        lbl.Text = title
        lbl.Font = FontHeader
        lbl.ForeColor = ColorPrimary
        lbl.AutoSize = True
        lbl.Location = New Point(24, 16)

        ' Bottom border
        Dim bottomLine As New Panel()
        bottomLine.Dock = DockStyle.Bottom
        bottomLine.Height = 1
        bottomLine.BackColor = ColorBorder

        pnl.Controls.Add(stripe)
        pnl.Controls.Add(bottomLine)
        pnl.Controls.Add(lbl)
        Return pnl
    End Function

    ' ═══════════════════════════════════════════════════════════════
    '  DIALOG HELPERS
    ' ═══════════════════════════════════════════════════════════════

    Public Sub ShowError(message As String, Optional title As String = "Error")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub ShowInfo(message As String, Optional title As String = "Information")
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function Confirm(message As String, Optional title As String = "Please Confirm") As Boolean
        Return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

End Module
