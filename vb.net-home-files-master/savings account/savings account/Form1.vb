Option Explicit On
Option Strict On

Public Class frmSavings

    Dim Deposit As Double
    Dim Interest As Double
    Dim Months As Double
    Dim Final As Double

    Private Sub frmSavings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Quick message for you.", "Hey You!")
        MessageBox.Show("Corona virus in embu kujeni mwone", "Citizen news feed",
                        MessageBoxButtons.YesNoCancel)

    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim IntRate As Double
        'read values from text boxes
        Deposit = Val(txtDeposit.Text)
        Interest = Val(txtInterest.Text)
        IntRate = Interest / 1200
        Months = Val(txtMonths.Text)
        'compute final value and put in text box
        If Interest = 0 Then
            'zero interest case
            Final = Deposit * Months
        Else
            Final = Deposit * ((1 + IntRate) ^ Months - 1) / IntRate
        End If

        txtFinal.Text = Format(Final, "0.00")


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtDeposit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeposit.KeyPress
        'only allow numbers, a single decimal point, backspace or enter
        Select Case e.KeyChar
            Case CChar("0") To CChar("9"), ControlChars.Back
                'acceptable keystrokes
                e.Handled = False
            Case ControlChars.Cr
                'enter key - move to next box
                txtInterest.Focus()
                e.Handled = False
            Case CChar(".")
                'check for existence of decimal point
                If InStr(txtDeposit.Text, ".") = 0 Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtInterest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterest.KeyPress
        'only allow numbers, a single decimal point, backspace or enter
        Select Case e.KeyChar
            Case CChar("0") To CChar("9"), ControlChars.Back
                'acceptable keystrokes
                e.Handled = False
            Case ControlChars.Cr
                'enter key - move to next box
                txtMonths.Focus()
                e.Handled = False
            Case CChar(".")
                'check for existence of decimal point
                If InStr(txtInterest.Text, ".") = 0 Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMonths_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonths.KeyPress

        'only allow numbers, backspace or enter
        Select Case e.KeyChar
            Case CChar("0") To CChar("9"), ControlChars.Back
                'acceptable keystrokes
                e.Handled = False
            Case ControlChars.Cr
                'enter key - move to calculate button
                btnCalculate.Focus()
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtDeposit.TextChanged

    End Sub

End Class
