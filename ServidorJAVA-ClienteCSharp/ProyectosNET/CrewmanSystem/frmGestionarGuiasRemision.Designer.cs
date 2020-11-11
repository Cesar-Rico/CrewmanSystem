﻿namespace CrewmanSystem
{
	partial class frmGestionarGuiasRemision
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ID_PEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FECHA_EMISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MOTIVO_TRASLADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FECHA_REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FECHA_TRASLADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(198)))), ((int)(((byte)(57)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeight = 30;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_PEDIDO,
            this.FECHA_EMISION,
            this.MOTIVO_TRASLADO,
            this.FECHA_REGISTRO,
            this.FECHA_TRASLADO});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(198)))), ((int)(((byte)(57)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.RowHeadersWidth = 51;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(198)))), ((int)(((byte)(57)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(998, 450);
			this.dataGridView1.TabIndex = 3;
			// 
			// ID
			// 
			this.ID.DataPropertyName = "id";
			this.ID.HeaderText = "Id";
			this.ID.MinimumWidth = 6;
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 50;
			// 
			// ID_PEDIDO
			// 
			this.ID_PEDIDO.DataPropertyName = "pedido";
			this.ID_PEDIDO.HeaderText = "Id Pedido";
			this.ID_PEDIDO.MinimumWidth = 6;
			this.ID_PEDIDO.Name = "ID_PEDIDO";
			this.ID_PEDIDO.ReadOnly = true;
			this.ID_PEDIDO.Width = 106;
			// 
			// FECHA_EMISION
			// 
			this.FECHA_EMISION.DataPropertyName = "fechaRegistro";
			this.FECHA_EMISION.HeaderText = "Fecha Emisión";
			this.FECHA_EMISION.MinimumWidth = 6;
			this.FECHA_EMISION.Name = "FECHA_EMISION";
			this.FECHA_EMISION.ReadOnly = true;
			this.FECHA_EMISION.Width = 148;
			// 
			// MOTIVO_TRASLADO
			// 
			this.MOTIVO_TRASLADO.DataPropertyName = "motivoTraslado";
			this.MOTIVO_TRASLADO.HeaderText = "Motivo Traslado";
			this.MOTIVO_TRASLADO.MinimumWidth = 6;
			this.MOTIVO_TRASLADO.Name = "MOTIVO_TRASLADO";
			this.MOTIVO_TRASLADO.ReadOnly = true;
			this.MOTIVO_TRASLADO.Width = 156;
			// 
			// FECHA_REGISTRO
			// 
			this.FECHA_REGISTRO.DataPropertyName = "fechaRegistro";
			this.FECHA_REGISTRO.HeaderText = "Fecha Registro";
			this.FECHA_REGISTRO.MinimumWidth = 6;
			this.FECHA_REGISTRO.Name = "FECHA_REGISTRO";
			this.FECHA_REGISTRO.ReadOnly = true;
			this.FECHA_REGISTRO.Width = 151;
			// 
			// FECHA_TRASLADO
			// 
			this.FECHA_TRASLADO.DataPropertyName = "fechaTraslado";
			this.FECHA_TRASLADO.HeaderText = "Fecha Traslado";
			this.FECHA_TRASLADO.MinimumWidth = 6;
			this.FECHA_TRASLADO.Name = "FECHA_TRASLADO";
			this.FECHA_TRASLADO.ReadOnly = true;
			this.FECHA_TRASLADO.Width = 153;
			// 
			// frmGestionarGuiasRemision
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 450);
			this.Controls.Add(this.dataGridView1);
			this.Name = "frmGestionarGuiasRemision";
			this.Text = "frmGestionarGuiasRemision";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_PEDIDO;
		private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_EMISION;
		private System.Windows.Forms.DataGridViewTextBoxColumn MOTIVO_TRASLADO;
		private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_REGISTRO;
		private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_TRASLADO;
	}
}