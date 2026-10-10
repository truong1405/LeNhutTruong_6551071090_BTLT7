namespace TriThucBooks;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        
        lblMaTL = new Label();
        txtMaTL = new TextBox();
        lblTenTL = new Label();
        txtTenTL = new TextBox();
        lblMoTa = new Label();
        txtMoTa = new TextBox();
        lblNgayTaoHeader = new Label();
        lblNgayTao = new Label();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        txtTimKiem = new TextBox();
        btnTimKiem = new Button();
        dgvTheLoai = new DataGridView();
        colMaTL = new DataGridViewTextBoxColumn();
        colTenTheLoai = new DataGridViewTextBoxColumn();
        colMoTa = new DataGridViewTextBoxColumn();
        colSoLuongSach = new DataGridViewTextBoxColumn();
        colNgayTao = new DataGridViewTextBoxColumn();

        ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
        SuspendLayout();

        // 
        // lblMaTL
        // 
        lblMaTL.AutoSize = true;
        lblMaTL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblMaTL.Location = new Point(25, 25);
        lblMaTL.Name = "lblMaTL";
        lblMaTL.Size = new Size(81, 17);
        lblMaTL.TabIndex = 0;
        lblMaTL.Text = "Mã thể loại";

        // 
        // txtMaTL
        // 
        txtMaTL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtMaTL.Location = new Point(125, 22);
        txtMaTL.Name = "txtMaTL";
        txtMaTL.ReadOnly = true;
        txtMaTL.Size = new Size(260, 25);
        txtMaTL.TabIndex = 1;
        txtMaTL.Text = "ReadOnly";

        // 
        // lblTenTL
        // 
        lblTenTL.AutoSize = true;
        lblTenTL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblTenTL.Location = new Point(25, 65);
        lblTenTL.Name = "lblTenTL";
        lblTenTL.Size = new Size(82, 17);
        lblTenTL.TabIndex = 2;
        lblTenTL.Text = "Tên thể loại";

        // 
        // txtTenTL
        // 
        txtTenTL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtTenTL.Location = new Point(125, 62);
        txtTenTL.Name = "txtTenTL";
        txtTenTL.Size = new Size(260, 25);
        txtTenTL.TabIndex = 3;

        // 
        // lblMoTa
        // 
        lblMoTa.AutoSize = true;
        lblMoTa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblMoTa.Location = new Point(25, 105);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new Size(43, 17);
        lblMoTa.TabIndex = 4;
        lblMoTa.Text = "Mô tả";

        // 
        // txtMoTa
        // 
        txtMoTa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtMoTa.Location = new Point(125, 102);
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.ScrollBars = ScrollBars.Vertical;
        txtMoTa.Size = new Size(260, 75);
        txtMoTa.TabIndex = 5;

        // 
        // lblNgayTaoHeader
        // 
        lblNgayTaoHeader.AutoSize = true;
        lblNgayTaoHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        lblNgayTaoHeader.Location = new Point(25, 188);
        lblNgayTaoHeader.Name = "lblNgayTaoHeader";
        lblNgayTaoHeader.Size = new Size(65, 17);
        lblNgayTaoHeader.TabIndex = 6;
        lblNgayTaoHeader.Text = "Ngày tạo:";

        // 
        // lblNgayTao
        // 
        lblNgayTao.AutoSize = true;
        lblNgayTao.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
        lblNgayTao.ForeColor = Color.DimGray;
        lblNgayTao.Location = new Point(125, 188);
        lblNgayTao.Name = "lblNgayTao";
        lblNgayTao.Size = new Size(67, 17);
        lblNgayTao.TabIndex = 7;
        lblNgayTao.Text = "Chưa chọn";

        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnThem.Location = new Point(540, 20);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(95, 36);
        btnThem.TabIndex = 8;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnSua.Location = new Point(645, 20);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(95, 36);
        btnSua.TabIndex = 9;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnXoa.Location = new Point(750, 20);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(95, 36);
        btnXoa.TabIndex = 10;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnLamMoi.Location = new Point(855, 20);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(95, 36);
        btnLamMoi.TabIndex = 11;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // txtTimKiem
        // 
        txtTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtTimKiem.Location = new Point(25, 225);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
        txtTimKiem.Size = new Size(360, 25);
        txtTimKiem.TabIndex = 12;
        txtTimKiem.KeyDown += txtTimKiem_KeyDown;

        // 
        // btnTimKiem
        // 
        btnTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        btnTimKiem.Location = new Point(395, 221);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new Size(125, 33);
        btnTimKiem.TabIndex = 13;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;

        // 
        // dgvTheLoai
        // 
        dgvTheLoai.AllowUserToAddRows = false;
        dgvTheLoai.AllowUserToDeleteRows = false;
        dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvTheLoai.BackgroundColor = Color.White;
        dgvTheLoai.BorderStyle = BorderStyle.Fixed3D;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvTheLoai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvTheLoai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTheLoai.Columns.AddRange(new DataGridViewColumn[] {
            colMaTL,
            colTenTheLoai,
            colMoTa,
            colSoLuongSach,
            colNgayTao
        });
        dgvTheLoai.Location = new Point(25, 265);
        dgvTheLoai.MultiSelect = false;
        dgvTheLoai.Name = "dgvTheLoai";
        dgvTheLoai.ReadOnly = true;
        dgvTheLoai.RowHeadersWidth = 35;
        dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTheLoai.Size = new Size(925, 240);
        dgvTheLoai.TabIndex = 14;
        dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
        dgvTheLoai.CellClick += dgvTheLoai_CellClick;

        // 
        // colMaTL
        // 
        colMaTL.DataPropertyName = "MaTl";
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
        colMaTL.DefaultCellStyle = dataGridViewCellStyle2;
        colMaTL.HeaderText = "Mã TL";
        colMaTL.Name = "colMaTL";
        colMaTL.ReadOnly = true;
        colMaTL.Width = 80;

        // 
        // colTenTheLoai
        // 
        colTenTheLoai.DataPropertyName = "TenTheLoai";
        colTenTheLoai.HeaderText = "Tên thể loại";
        colTenTheLoai.Name = "colTenTheLoai";
        colTenTheLoai.ReadOnly = true;
        colTenTheLoai.Width = 150;

        // 
        // colMoTa
        // 
        colMoTa.DataPropertyName = "MoTa";
        colMoTa.HeaderText = "Mô tả";
        colMoTa.Name = "colMoTa";
        colMoTa.ReadOnly = true;
        colMoTa.Width = 320;

        // 
        // colSoLuongSach
        // 
        colSoLuongSach.DataPropertyName = "SoLuongSach";
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
        colSoLuongSach.DefaultCellStyle = dataGridViewCellStyle3;
        colSoLuongSach.HeaderText = "Số lượng sách";
        colSoLuongSach.Name = "colSoLuongSach";
        colSoLuongSach.ReadOnly = true;
        colSoLuongSach.Width = 120;

        // 
        // colNgayTao
        // 
        colNgayTao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colNgayTao.DataPropertyName = "NgayTao";
        dataGridViewCellStyle4.Format = "yyyy/MM/dd HH:mm:ss";
        colNgayTao.DefaultCellStyle = dataGridViewCellStyle4;
        colNgayTao.HeaderText = "Ngày tạo";
        colNgayTao.Name = "colNgayTao";
        colNgayTao.ReadOnly = true;

        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(975, 525);
        Controls.Add(dgvTheLoai);
        Controls.Add(btnTimKiem);
        Controls.Add(txtTimKiem);
        Controls.Add(btnLamMoi);
        Controls.Add(btnXoa);
        Controls.Add(btnSua);
        Controls.Add(btnThem);
        Controls.Add(lblNgayTao);
        Controls.Add(lblNgayTaoHeader);
        Controls.Add(txtMoTa);
        Controls.Add(lblMoTa);
        Controls.Add(txtTenTL);
        Controls.Add(lblTenTL);
        Controls.Add(txtMaTL);
        Controls.Add(lblMaTL);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblMaTL;
    private TextBox txtMaTL;
    private Label lblTenTL;
    private TextBox txtTenTL;
    private Label lblMoTa;
    private TextBox txtMoTa;
    private Label lblNgayTaoHeader;
    private Label lblNgayTao;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private TextBox txtTimKiem;
    private Button btnTimKiem;
    private DataGridView dgvTheLoai;
    private DataGridViewTextBoxColumn colMaTL;
    private DataGridViewTextBoxColumn colTenTheLoai;
    private DataGridViewTextBoxColumn colMoTa;
    private DataGridViewTextBoxColumn colSoLuongSach;
    private DataGridViewTextBoxColumn colNgayTao;
}
