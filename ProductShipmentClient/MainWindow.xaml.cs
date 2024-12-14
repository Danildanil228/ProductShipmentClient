using Newtonsoft.Json;
using ProductShipmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ProductShipmentWPFClient
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7228/api/") // Убедитесь, что этот адрес соответствует вашему API
            };
        }

        private async void GetProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ProductIdTextBox.Text, out int productId))
            {
                var product = await GetProductAsync(productId);
                if (product != null)
                {
                    DataGrid.ItemsSource = new List<Product> { product };
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Product ID.");
            }
        }

        private async void GetTotalCostButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue)
            {
                var date = DatePicker.SelectedDate.Value;
                var totalCost = await GetTotalCostByDateAsync(date);
                if (totalCost.HasValue)
                {
                    DataGrid.ItemsSource = new List<object> { new { TotalCost = totalCost } };
                }
                else
                {
                    MessageBox.Show("No shipments found for this date.");
                }
            }
            else
            {
                MessageBox.Show("Please select a date.");
            }
        }

        private async void GetShipmentReportButton_Click(object sender, RoutedEventArgs e)
        {
            var productName = ProductNameTextBox.Text;
            if (!string.IsNullOrEmpty(productName))
            {
                var shipmentReports = await GetShipmentReportAsync(productName);
                if (shipmentReports != null && shipmentReports.Count > 0)
                {
                    DataGrid.ItemsSource = shipmentReports;
                }
                else
                {
                    MessageBox.Show("No shipment reports found for this product.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a product name.");
            }
        }

        private async Task<Product> GetProductAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"products/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(content); 
            }
            return null;
        }

        private async Task<decimal?> GetTotalCostByDateAsync(DateTime date)
        {
            var response = await _httpClient.GetAsync($"shipments/totalcost/{date.ToString("yyyy-MM-dd")}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(content);
                return result.totalCost;
            }
            return null;
        }

        private async Task<List<ShipmentReport>> GetShipmentReportAsync(string productName)
        {
            var response = await _httpClient.GetAsync($"shipments/shipmentreport/{productName}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ShipmentReport>>(content);
            }
            return null;
        }
    }
}