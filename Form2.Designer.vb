<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Documentation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtDocu = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.btnSwitch = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(16, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(123, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Tarsa's Documentation*:"
        '
        'txtDocu
        '
        Me.txtDocu.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocu.Location = New System.Drawing.Point(18, 37)
        Me.txtDocu.Multiline = True
        Me.txtDocu.Name = "txtDocu"
        Me.txtDocu.ReadOnly = True
        Me.txtDocu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDocu.Size = New System.Drawing.Size(582, 396)
        Me.txtDocu.TabIndex = 1
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(9, 445)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(269, 13)
        Me.lblContact.TabIndex = 2
        Me.lblContact.Text = "*For any corrections, contact me at discord: tarsa#8462"
        '
        'btnSwitch
        '
        Me.btnSwitch.Location = New System.Drawing.Point(455, 4)
        Me.btnSwitch.Name = "btnSwitch"
        Me.btnSwitch.Size = New System.Drawing.Size(144, 27)
        Me.btnSwitch.TabIndex = 4
        Me.btnSwitch.Text = "Switch to Personal Copy"
        Me.btnSwitch.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(355, 438)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(129, 27)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save to Personal Copy"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnRestore
        '
        Me.btnRestore.Enabled = False
        Me.btnRestore.Location = New System.Drawing.Point(490, 439)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(109, 27)
        Me.btnRestore.TabIndex = 6
        Me.btnRestore.Text = "Restore Last Saved"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'Documentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 470)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSwitch)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.txtDocu)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "Documentation"
        Me.Text = ".set File Documentation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents txtDocu As TextBox
    Friend WithEvents lblContact As Label
    Friend WithEvents btnSwitch As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnRestore As Button
End Class
