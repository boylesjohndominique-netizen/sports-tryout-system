Imports System.Drawing.Drawing2D


    ''' <summary>
    ''' High-performance double-buffered panel to eliminate all GDI+ flickering.
    ''' </summary>
    Public Class DoubleBufferedPanel
        Inherits Panel

        Public Sub New()
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                        ControlStyles.UserPaint Or
                        ControlStyles.OptimizedDoubleBuffer Or
                        ControlStyles.ResizeRedraw, True)
            Me.UpdateStyles()
        End Sub
    End Class

    ''' <summary>
    ''' Anti-flicker double-buffered TableLayoutPanel.
    ''' </summary>
    Public Class DoubleBufferedTableLayoutPanel
        Inherits TableLayoutPanel

        Public Sub New()
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                        ControlStyles.UserPaint Or
                        ControlStyles.OptimizedDoubleBuffer Or
                        ControlStyles.ResizeRedraw, True)
            Me.UpdateStyles()
        End Sub
    End Class

    ''' <summary>
    ''' Smooth gradient banner with subtle decorative concentric circles.
    ''' </summary>
    Public Class GradientPanel
        Inherits Panel

        Public Sub New()
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                        ControlStyles.UserPaint Or
                        ControlStyles.OptimizedDoubleBuffer Or
                        ControlStyles.ResizeRedraw, True)
            Me.UpdateStyles()
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            If Me.Width <= 0 OrElse Me.Height <= 0 Then Return
            Using brush As New LinearGradientBrush(Me.ClientRectangle, UIHelper.ColorPrimaryDark, UIHelper.ColorPrimaryLight, 15.0F)
                e.Graphics.FillRectangle(brush, Me.ClientRectangle)
            End Using
            ' Subtle decorative circles
            Using b As New SolidBrush(Color.FromArgb(12, Color.White))
                e.Graphics.FillEllipse(b, Me.Width - 180, -60, 240, 240)
                e.Graphics.FillEllipse(b, Me.Width - 320, 30, 140, 140)
                e.Graphics.FillEllipse(b, -40, -40, 160, 160)
            End Using
        End Sub
    End Class

    ''' <summary>
    ''' Container row for one sport bar in the registrations chart.
    ''' </summary>
    Public Class SportBarRow
        Public Container As Panel
        Public LblName As Label
        Public PnlTrack As Panel
        Public PnlFill As Panel
        Public LblCount As Label
        Public SportName As String
        Public Count As Integer
    End Class

