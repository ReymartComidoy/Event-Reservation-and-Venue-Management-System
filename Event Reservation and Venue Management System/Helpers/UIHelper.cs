using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Helpers
{
    public static class UIHelper
    {
        /// <summary>
        /// Applies consistent formatting and layout styling to DataGridView instances.
        /// </summary>
        public static void FormatGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AutoGenerateColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.RowTemplate.Height = 35;
            dgv.ColumnHeadersHeight = 35;
        }

        /// <summary>
        /// Filters a DataGridView's DataTable source dynamically based on search keyword and category.
        /// </summary>
        public static void ApplyTableFilter(
            DataGridView dgv,
            string keyword,
            string placeholder,
            string categoryColumn = null,
            string categoryValue = null,
            string defaultCategoryText = "All")
        {
            if (dgv?.DataSource is DataTable dt)
            {
                string searchKeyword = keyword?.Replace("'", "''").Trim() ?? "";
                if (searchKeyword == placeholder) searchKeyword = "";

                string filterExpression = "";

                // 1. Build text search filter across string columns
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    var searchableCols = dt.Columns.Cast<DataColumn>()
                        .Where(c => c.DataType == typeof(string))
                        .Select(c => $"[{c.ColumnName}] LIKE '%{searchKeyword}%'");

                    if (searchableCols.Any())
                    {
                        filterExpression = $"({string.Join(" OR ", searchableCols)})";
                    }
                }

                // 2. Build category filter if selected
                if (!string.IsNullOrEmpty(categoryColumn) &&
                    !string.IsNullOrEmpty(categoryValue) &&
                    !categoryValue.StartsWith(defaultCategoryText, StringComparison.OrdinalIgnoreCase) &&
                    dt.Columns.Contains(categoryColumn))
                {
                    if (filterExpression.Length > 0) filterExpression += " AND ";
                    filterExpression += $"[{categoryColumn}] = '{categoryValue.Replace("'", "''")}'";
                }

                dt.DefaultView.RowFilter = filterExpression;
            }
        }

        /// <summary>
        /// Paints rounded status pills inside specified DataGridView cells.
        /// </summary>
        public static void DrawStatusPill(DataGridViewCellPaintingEventArgs e, Color activeColor, Color defaultColor = default)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null)
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value.ToString();
                if (defaultColor == default) defaultColor = Color.FromArgb(108, 117, 125);

                // Determine badge background color based on common active statuses
                Color pillColor = (status.Equals("Active", StringComparison.OrdinalIgnoreCase) ||
                                   status.Equals("Upcoming", StringComparison.OrdinalIgnoreCase) ||
                                   status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase) ||
                                   status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                                   ? activeColor
                                   : defaultColor;

                Rectangle rect = new Rectangle(
                    e.CellBounds.X + 8,
                    e.CellBounds.Y + 6,
                    e.CellBounds.Width - 16,
                    e.CellBounds.Height - 12
                );

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString(status, e.CellStyle.Font, textBrush, rect, sf);
                    }
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// Resets common input controls inside a container panel or form.
        /// </summary>
        public static void ClearInputFields(Control parentControl)
        {
            if (parentControl == null) return;

            foreach (Control ctrl in parentControl.Controls)
            {
                if (ctrl is TextBox txt) txt.Clear();
                else if (ctrl is ComboBox cmb && cmb.Items.Count > 0) cmb.SelectedIndex = 0;
                else if (ctrl is DateTimePicker dtp) dtp.Value = DateTime.Now;
                else if (ctrl.HasChildren) ClearInputFields(ctrl);
            }
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
