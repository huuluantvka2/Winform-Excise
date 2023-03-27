using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExerciseWinform
{
    public partial class Signin : Form
    {
        SqlConnection cnn;
        public Signin()
        {
            InitializeComponent();
            string connetionString;
            connetionString = @"Data Source=210.2.99.122,1444;Initial Catalog=LuanTest;User ID=sa;Password=Xx12345689xX";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }

        private void Signin_Load(object sender, System.EventArgs e)
        {
            this.Name = "Login";
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
        private void Login()
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT TOP 1 FullName FROM Employees WHERE Email='{txtUserName.Text}' AND Password='{txtPassword.Text}';", this.cnn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if(reader.HasRows)
                    {
                        Home h = new Home();
                        reader.Read();
                        h.lbHello.Text = "Hello " + reader["FullName"].ToString();
                        this.Hide();
                        h.Show();
                    }
                    else MessageBox.Show("Username or password incorrect");
                }
            }
        }
        private void Reset()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            Reset();
        }
    }
}
