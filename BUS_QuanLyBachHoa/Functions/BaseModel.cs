using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_QuanLyBachHoa
{
    /// <summary>
    /// Kết quả trả về sau khi thực hiện 1 câu lệnh trên SQL
    /// </summary>

    public class ResultExec
    {
        public int resultNumber = -1;
        public string resultText;
    }

    public abstract class BaseModel<T> : ConnectSql
    {
        //Datagridview hiển thị danh sách
        protected DataGridView dtGrid = null;

        //Hiện thi thông báo.
        protected Label lblMessage = null;

        //Sự kiện click vào row datagridview. Dùng để hiện thị thông tin row đang được click
        //lên các textbox.
        public delegate void EventCellClick(DataGridViewRow row);

        public EventCellClick cellclick = null;

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        public abstract void GetAllData();

        /// <summary>
        /// Lấy tất cả dữ liệu và sắp xếp kết quả trả về
        /// </summary>
        /// <param name="orderBy">Sắp xếp theo</param>
        public abstract void GetAllData(string orderBy);

        /// <summary>
        /// Thêm 1 row mới vào datagridview
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InsertRow(T entity);

        /// <summary>
        /// Sửa 1 row trên datagridview
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void UpdateRow(T entity);

        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete();

        //Lấy dữ liệu trong csdl bằng lệnh query và trả về mảng dữ liệu chuỗi
        protected string[] GetRow(string query)
        {
            OpenConnection();

            lblMessage.Text = "...Đang thực thi...";
            string[] data = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        data[i] = reader[i].ToString();

                    lblMessage.Text = "";
                }

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
            }

            connection.Close();

            return data;
        }

        //Thực hiện lệnh query lấy dữ liệu và trả về bảng dữ liệu DataTable
        protected DataTable ExecQuery(string query)
        {
            OpenConnection();

            lblMessage.Text = "...Đang thực thi...";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, connection);

                da.Fill(table);
                da.Dispose();

                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
            }

            connection.Close();

            return table;
        }

        //Thực hiện lệnh query với kiểu lệnh CommandType và trả về kết quả chạy gồm số dòng đã chạy và chuỗi thông báo kết quả
        protected ResultExec Execute(string query, CommandType type, params SqlParameter[] param)
        {
            OpenConnection();

            ResultExec rs = new ResultExec();
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection)
                {
                    CommandType = type
                };

                if (type == CommandType.StoredProcedure)
                    cmd.Parameters.AddRange(param);

                rs.resultNumber = cmd.ExecuteNonQuery();

                rs.resultText = "";

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                rs.resultText = "Lỗi: " + ex.Message;
            }

            connection.Close();

            return rs;
        }

        protected void InsertRow(string[] arr)
        {
            DataTable table = (DataTable)dtGrid.DataSource;

            DataRow row = table.NewRow();

            for (int i = 0; i < arr.Length; i++)
                row[i] = arr[i];

            table.Rows.Add(row);

            dtGrid.ClearSelection();
            dtGrid.CurrentCell = dtGrid.Rows[dtGrid.Rows.Count - 1].Cells[0];

            cellclick(dtGrid.Rows[dtGrid.Rows.Count - 1]);
        }

        protected void ExecInsert(string query, T entity, CommandType type = CommandType.Text, params SqlParameter[] param)
        {
            lblMessage.Text = "...Đang thực thi...";
            ResultExec rs = Execute(query, type, param);

            if (rs.resultNumber > 0)
            {
                InsertRow(entity);
                rs.resultText = "Thêm thành công";
            }

            lblMessage.Text = rs.resultText;
        }

        //Thực hiện lệnh query và trả về kết quả chạy gồm số đã thêm và chuỗi thông báo kết quả
        private ResultExec ExecuteReturnValue(string query, params SqlParameter[] param)
        {
            OpenConnection();

            ResultExec rs = new ResultExec();
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddRange(param);
                rs.resultNumber = int.Parse(cmd.ExecuteScalar().ToString());

                rs.resultText = "";

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                rs.resultText = "Lỗi: " + ex.Message;
            }

            connection.Close();

            return rs;
        }

        //Thực hiện thêm dữ liệu cho vào csdl và trả về kết quả thêm
        protected int ExecInsert(string query, params SqlParameter[] param)
        {
            lblMessage.Text = "...Đang thực thi...";
            ResultExec rs = ExecuteReturnValue(query, param);

            if (rs.resultNumber > 0)
            {
                lblMessage.Text = "Thêm thành công";

                return rs.resultNumber;
            }

            lblMessage.Text = rs.resultText;
            return -1;
        }

        //Cập nhật dữ liệu cho hàng hiện tại của datagridview bằng mảng chuỗi dữ liệu
        protected void UpdateRow(string[] arr)
        {
            DataGridViewRow currentRow = dtGrid.CurrentRow;

            if (currentRow != null)
            {
                for (int i = 0; i < arr.Length; i++)
                    currentRow.Cells[i].Value = arr[i];
            }
        }

        //Cập nhật dữ liệu trong csdl và datagridview bằng query
        protected void ExecUpdate(string query, T entity, CommandType type = CommandType.Text, params SqlParameter[] param)
        {
            lblMessage.Text = "...Đang thực thi...";
            ResultExec rs = Execute(query, type, param);

            if (rs.resultNumber > 0)
            {
                UpdateRow(entity);

                lblMessage.Text = "Cập nhật thành công";
            }
            else
                lblMessage.Text = rs.resultText;
        }

        //Kiểm tra và hỏi người dùng có thật sự muốn xóa không
        protected string BeforeDelete(int index = 0)
        {
            if (dtGrid.CurrentRow == null)
            {
                lblMessage.Text = "Vui lòng chọn 1 dòng để xóa";
                return null;
            }

            string key = dtGrid.CurrentRow.Cells[index].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa dòng " + key + "?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return key;

            return null;
        }

        //Xóa hàng hiện tại của datagridview
        private void DeleteCurrentRowInGridview()
        {
            if (dtGrid.CurrentRow != null)
                dtGrid.Rows.Remove(dtGrid.CurrentRow);
        }

        //Xóa dữ liệu trong csdl và trong datagridview bằng query 
        protected void ExecDelete(string query, CommandType type = CommandType.Text, params SqlParameter[] param)
        {
            lblMessage.Text = "...Đang thực thi...";
            ResultExec rs = Execute(query, type, param);

            if (rs.resultNumber > 0)
            {
                DeleteCurrentRowInGridview();

                //Hiển thị kết quả sau khi xóa bằng label message
                lblMessage.Text = "Xóa thành công";

                //Thực hiện hàm delegate cellclick do người dùng gán
                cellclick(dtGrid.CurrentRow);
            }
            else
                lblMessage.Text = rs.resultText;
        }

        //Thêm các điều khiển cho datagridview và label message
        public void SetControl(DataGridView dtGrid, Label lblMessage)
        {
            this.dtGrid = dtGrid;
            this.lblMessage = lblMessage;
            SetEventToDataGridView();
        }

        //Thêm sự kiện cellclick và keyup cho datagridview
        private void SetEventToDataGridView()
        {
            if (dtGrid != null)
            {
                dtGrid.CellClick += new DataGridViewCellEventHandler(DtGrid_CellClick);
                dtGrid.KeyUp += new KeyEventHandler(DtGrid_KeyUp);
            }
        }

        //Sự kiện bắt phím lên xuống của datagridview
        void DtGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                cellclick(dtGrid.CurrentRow);
        }


        //Gán hàm e cho hàm delegate cellclick
        public void ShowDetail(EventCellClick e)
        {
            cellclick = new EventCellClick(e);
        }

        //Sự kiện bắt khi được 1 ô được nhấn của datagridview
        void DtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellclick(dtGrid.CurrentRow);
        }

        //public List<DataItem> GetList(string query)
        //{
        //    OpenConnection();
        //    List<DataItem> list = new List<DataItem>();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(query, connection);

        //        SqlDataReader read = cmd.ExecuteReader();

        //        while (read.Read())
        //        {
        //            DataItem item = new DataItem
        //            {
        //                Value = read.GetValue(0).ToString(),
        //                Name = read.GetValue(1).ToString()
        //            };

        //            list.Add(item);
        //        }

        //        cmd.Dispose();
        //        read.Close();
        //    }
        //    catch
        //    { }

        //    connection.Close();
        //    return list;
        //}
    }
}

