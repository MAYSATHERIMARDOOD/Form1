using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
 
namespace OkulKantinApp
{
    public partial class Form1 : Form
    {
        // Veritabanı bağlantı bilgisi
        private const string ConnectionString = "Server=localhost;Database=OkulKantin2;User ID=root;Password=Nuna12345678;Charset=utf8;";

        public Form1()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışacak metot
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUsers();
                LoadProducts();
                MessageBox.Show("Kullanıcılar ve ürünler başarıyla yüklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yükleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        // Kullanıcıları veritabanından yükleyen metot
        private void LoadUsers()
        {
            cmbUsers.Items.Clear();
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT CONCAT(İsim, ' ', Soyisim) AS FullName FROM Kullanıcılar";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbUsers.Items.Add(reader["FullName"].ToString());
                        }
                    }
                }

                if (cmbUsers.Items.Count == 0)
                {
                    MessageBox.Show("Veritabanında kullanıcı bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        // Ürünleri veritabanından yükleyen metot
        private void LoadProducts()
        {
            cmbProducts.Items.Clear();
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ÜrünAdı FROM Ürünler";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbProducts.Items.Add(reader["ÜrünAdı"].ToString());
                        }
                    }
                }

                if (cmbProducts.Items.Count == 0)
                {
                    MessageBox.Show("Veritabanında ürün bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        // Satış yapma işlemini başlatan metot
        private void btnSale_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null || cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Lütfen ürün ve kullanıcı seçin.");
                return;
            }

            string selectedUser = cmbUsers.SelectedItem.ToString();
            string selectedProduct = cmbProducts.SelectedItem.ToString();

            lstTransactions.Items.Add($"Satış: {selectedUser} -> {selectedProduct}");
            MessageBox.Show($"{selectedUser}, {selectedProduct} ürününü satın aldı!");
        }
    }
}
