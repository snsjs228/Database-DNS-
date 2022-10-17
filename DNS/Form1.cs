using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNS
{
    public partial class Main : Form
    {
        Database database = new Database();
        public Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//окно открывается по центру
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';//пароль шифруется звездочкой
            textBox_password.MaxLength = 50;
            textBox_login.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var password = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable(); //создали 2 объетка для рбаоты

          
            string querystring = $"select id,login, password from register where login ='{loginUser}' and password ='{password}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());//создали переменную для запроса в ССМС и объект команды запроса  

            adapter.SelectCommand = command;
            adapter.Fill(table);//вносим данные

            if (table.Rows.Count == 1)//проверка, чтобы строка равнялась 1
            {
                MessageBox.Show("Вы успешно вошли!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGrid dtg = new DataGrid();
                dtg.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта нет!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
