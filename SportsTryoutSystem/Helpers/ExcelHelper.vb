Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Globalization

''' <summary>
''' Minimal, dependency-free writer that produces a valid Office Open XML
''' (.xlsx) workbook. Rows are supplied as arrays of cell values; strings are
''' written inline (no shared-string table) and numeric types are written as
''' real numbers so Excel treats them as values, not text.
''' </summary>
Public Module ExcelHelper

    ''' <summary>Convenience export for a DataTable: optional title/subtitle, a bold header row, then the rows.</summary>
    Public Sub ExportDataTable(filePath As String, sheetName As String, dt As DataTable,
                               Optional title As String = Nothing, Optional subtitle As String = Nothing)
        Dim rows As New List(Of Object())
        Dim bold As New HashSet(Of Integer)()

        If Not String.IsNullOrEmpty(title) Then
            rows.Add(New Object() {title})
            bold.Add(rows.Count)
        End If
        If Not String.IsNullOrEmpty(subtitle) Then
            rows.Add(New Object() {subtitle})
        End If
        If Not String.IsNullOrEmpty(title) OrElse Not String.IsNullOrEmpty(subtitle) Then
            rows.Add(New Object() {""})
        End If

        Dim headers As New List(Of Object)
        For Each col As DataColumn In dt.Columns
            headers.Add(col.ColumnName)
        Next
        rows.Add(headers.ToArray())
        bold.Add(rows.Count)

        For Each dr As DataRow In dt.Rows
            rows.Add(dr.ItemArray)
        Next

        Dim widths As Integer() = Nothing
        If dt.Columns.Count > 0 Then
            widths = New Integer(dt.Columns.Count - 1) {}
            For i As Integer = 0 To dt.Columns.Count - 1
                widths(i) = Math.Max(12, Math.Min(42, dt.Columns(i).ColumnName.Length + 6))
            Next
        End If

        WriteWorkbook(filePath, sheetName, rows, bold, widths)
    End Sub

    ''' <summary>
    ''' Writes a workbook with a single sheet. <paramref name="rows"/> holds one
    ''' Object() per row; 1-based row numbers in <paramref name="boldRows"/> are
    ''' rendered in bold.
    ''' </summary>
    Public Sub WriteWorkbook(filePath As String, sheetName As String, rows As List(Of Object()),
                             Optional boldRows As HashSet(Of Integer) = Nothing, Optional columnWidths As Integer() = Nothing)
        If rows Is Nothing OrElse rows.Count = 0 Then
            rows = New List(Of Object())()
            rows.Add(New Object() {""})
        End If

        Dim safeSheet As String = SanitizeSheetName(sheetName)

        Dim sheetXml As String = BuildSheet(rows, boldRows, columnWidths)

        Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
            Using zip As New ZipArchive(fs, ZipArchiveMode.Create)
                AddEntry(zip, "[Content_Types].xml", ContentTypesXml())
                AddEntry(zip, "_rels/.rels", RootRelsXml())
                AddEntry(zip, "xl/workbook.xml", WorkbookXml(safeSheet))
                AddEntry(zip, "xl/_rels/workbook.xml.rels", WorkbookRelsXml())
                AddEntry(zip, "xl/styles.xml", StylesXml())
                AddEntry(zip, "xl/worksheets/sheet1.xml", sheetXml)
            End Using
        End Using
    End Sub

    Private Sub AddEntry(zip As ZipArchive, name As String, content As String)
        Dim entry As ZipArchiveEntry = zip.CreateEntry(name, CompressionLevel.Optimal)
        Using stream As Stream = entry.Open()
            Using writer As New StreamWriter(stream, New UTF8Encoding(False))
                writer.Write(content)
            End Using
        End Using
    End Sub

    Private Function BuildSheet(rows As List(Of Object()), boldRows As HashSet(Of Integer), widths As Integer()) As String
        Dim sb As New StringBuilder()
        sb.Append("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>")
        sb.Append("<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">")

        If widths IsNot Nothing AndAlso widths.Length > 0 Then
            sb.Append("<cols>")
            For i As Integer = 0 To widths.Length - 1
                sb.Append("<col min=""" & (i + 1).ToString() & """ max=""" & (i + 1).ToString() &
                          """ width=""" & widths(i).ToString(CultureInfo.InvariantCulture) & """ customWidth=""1""/>")
            Next
            sb.Append("</cols>")
        End If

        sb.Append("<sheetData>")
        For r As Integer = 0 To rows.Count - 1
            Dim rowNum As Integer = r + 1
            Dim isBold As Boolean = boldRows IsNot Nothing AndAlso boldRows.Contains(rowNum)
            sb.Append("<row r=""").Append(rowNum.ToString()).Append("""")
            Dim cells As Object() = rows(r)
            If cells Is Nothing OrElse cells.Length = 0 Then
                sb.Append("/>")
                Continue For
            End If
            sb.Append(">")
            For c As Integer = 0 To cells.Length - 1
                sb.Append(CellXml(c, rowNum, cells(c), isBold))
            Next
            sb.Append("</row>")
        Next
        sb.Append("</sheetData></worksheet>")
        Return sb.ToString()
    End Function

    Private Function CellXml(colIndex As Integer, rowNumber As Integer, value As Object, bold As Boolean) As String
        Dim ref As String = ColumnLetter(colIndex) & rowNumber.ToString()
        Dim style As String = If(bold, " s=""1""", "")

        If value Is Nothing OrElse IsDBNull(value) Then
            Return "<c r=""" & ref & """" & style & "/>"
        End If

        Dim t As Type = value.GetType()
        If t Is GetType(Integer) OrElse t Is GetType(Long) OrElse t Is GetType(Short) OrElse
           t Is GetType(Double) OrElse t Is GetType(Single) OrElse t Is GetType(Decimal) Then
            Dim text As String = Convert.ToString(value, CultureInfo.InvariantCulture)
            If text = "" Then Return "<c r=""" & ref & """" & style & "/>"
            Return "<c r=""" & ref & """" & style & "><v>" & text & "</v></c>"
        End If

        Return "<c r=""" & ref & """" & style & " t=""inlineStr""><is><t xml:space=""preserve"">" & XmlEscape(value.ToString()) & "</t></is></c>"
    End Function

    Private Function ColumnLetter(colIndex As Integer) As String
        Dim index As Integer = colIndex + 1
        Dim result As String = ""
        While index > 0
            Dim remainder As Integer = (index - 1) Mod 26
            result = ChrW(AscW("A"c) + remainder) & result
            index = (index - 1) \ 26
        End While
        Return result
    End Function

    Private Function XmlEscape(value As String) As String
        If value Is Nothing Then Return ""
        Return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;").Replace("'", "&apos;")
    End Function

    Private Function SanitizeSheetName(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "Sheet1"
        Dim invalid As Char() = New Char() {"\"c, "/"c, "?"c, "*"c, "["c, "]"c, ":"c}
        Dim clean As String = name
        For Each ch In invalid
            clean = clean.Replace(ch, " "c)
        Next
        clean = clean.Trim()
        If clean.Length = 0 Then clean = "Sheet1"
        If clean.Length > 31 Then clean = clean.Substring(0, 31)
        Return clean
    End Function

    Private Function ContentTypesXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">" &
               "<Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>" &
               "<Default Extension=""xml"" ContentType=""application/xml""/>" &
               "<Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>" &
               "<Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>" &
               "<Override PartName=""/xl/styles.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml""/>" &
               "</Types>"
    End Function

    Private Function RootRelsXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">" &
               "<Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>" &
               "</Relationships>"
    End Function

    Private Function WorkbookXml(sheetName As String) As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" " &
               "xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"">" &
               "<sheets><sheet name=""" & XmlEscape(sheetName) & """ sheetId=""1"" r:id=""rId1""/></sheets>" &
               "</workbook>"
    End Function

    Private Function WorkbookRelsXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">" &
               "<Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>" &
               "<Relationship Id=""rId2"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"" Target=""styles.xml""/>" &
               "</Relationships>"
    End Function

    Private Function StylesXml() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>" &
               "<styleSheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">" &
               "<fonts count=""2"">" &
               "<font><sz val=""11""/><name val=""Calibri""/></font>" &
               "<font><b/><sz val=""11""/><name val=""Calibri""/></font>" &
               "</fonts>" &
               "<fills count=""2"">" &
               "<fill><patternFill patternType=""none""/></fill>" &
               "<fill><patternFill patternType=""gray125""/></fill>" &
               "</fills>" &
               "<borders count=""1""><border/></borders>" &
               "<cellStyleXfs count=""1""><xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0""/></cellStyleXfs>" &
               "<cellXfs count=""2"">" &
               "<xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0"" xfId=""0""/>" &
               "<xf numFmtId=""0"" fontId=""1"" fillId=""0"" borderId=""0"" xfId=""0"" applyFont=""1""/>" &
               "</cellXfs>" &
               "</styleSheet>"
    End Function

End Module
