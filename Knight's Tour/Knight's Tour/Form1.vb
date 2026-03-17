Public Class KnightsTour
    Dim n As Integer = 6, steps, prevRow, prevCol As Integer
    Dim cells(n, n) As Button
    Dim board(n, n) As Integer

    Private Sub KnightsTour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To n ^ 2 - 1
            Dim r As Integer = i \ n, c As Integer = i Mod n
            If i < 10 Then
                cells(r, c) = DirectCast(Controls.Find("cell0" & i, False).First, Button)
            Else
                cells(r, c) = DirectCast(Controls.Find("cell" & i, False).First, Button)
            End If
            cells(r, c).Enabled = False
            cells(r, c).Text = ""
            board(r, c) = 0
        Next
        steps = 0
        prevRow = -1
        prevCol = -1
        startBtn.Enabled = True
        restartBtn.Enabled = False
    End Sub

    Private Function IsValidMove(prevRow As Integer, prevCol As Integer, currRow As Integer, currCol As Integer)
        If prevRow = -1 And prevCol = -1 Then
            Return True
        End If
        Return (Math.Abs(currRow - prevRow) = 1 And Math.Abs(currCol - prevCol) = 2) Or (Math.Abs(currRow - prevRow) = 2 And Math.Abs(currCol - prevCol) = 1)
    End Function

    Private Function NoValidMoves(n As Integer, board(,) As Integer, row As Integer, col As Integer)
        Dim dy() As Integer = {-2, -1, 1, 2, 2, 1, -1, -2}
        Dim dx() As Integer = {1, 2, 2, 1, -1, -2, -2, -1}
        For i = 0 To 7
            If row + dy(i) >= 0 And row + dy(i) <= n - 1 And col + dx(i) >= 0 And col + dx(i) <= n - 1 Then
                If board(row + dy(i), col + dx(i)) = 0 Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub GameOver()
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Enabled = False
            Next
        Next
        restartBtn.Enabled = True
    End Sub

    Private Sub button_Click(sender As Object, e As EventArgs) Handles cell35.Click, cell34.Click, cell33.Click, cell32.Click, cell31.Click, cell30.Click, cell29.Click, cell28.Click, cell27.Click, cell26.Click, cell25.Click, cell24.Click, cell23.Click, cell22.Click, cell21.Click, cell20.Click, cell19.Click, cell18.Click, cell17.Click, cell16.Click, cell15.Click, cell14.Click, cell13.Click, cell12.Click, cell11.Click, cell10.Click, cell09.Click, cell08.Click, cell07.Click, cell06.Click, cell05.Click, cell04.Click, cell03.Click, cell02.Click, cell01.Click, cell00.Click
        Dim cellName As String = CType(sender, Button).Name
        Dim cellNum As Integer = CType(cellName.Substring(4), Integer)
        Dim row As Integer = cellNum \ n, col As Integer = cellNum Mod n
        If IsValidMove(prevRow, prevCol, row, col) Then
            steps += 1
            cells(row, col).Text = steps.ToString()
            cells(row, col).Enabled = False
            board(row, col) = steps
            prevRow = row
            prevCol = col
            If steps = n ^ 2 Then
                GameOver()
                MessageBox.Show("Solved!")
            ElseIf NoValidMoves(n, board, row, col) Then
                GameOver()
                MessageBox.Show("Game Over!")
            End If
        Else
            MessageBox.Show("Invalid move")
        End If
    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles startBtn.Click
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Enabled = True
            Next
        Next
        startBtn.Enabled = False
    End Sub

    Private Sub restartBtn_Click(sender As Object, e As EventArgs) Handles restartBtn.Click
        For i = 0 To n - 1
            For j = 0 To n - 1
                cells(i, j).Text = ""
                board(i, j) = 0
            Next
        Next
        steps = 0
        prevRow = -1
        prevCol = -1
        startBtn.Enabled = True
        restartBtn.Enabled = False
    End Sub
End Class
