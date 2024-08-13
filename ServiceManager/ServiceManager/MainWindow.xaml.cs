using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceManager
{
    public class ServiceModel
    {
        public string ServiceName { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public string StartType { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            List<ServiceModel> services = ServiceController.GetServices()
                .Select(s => new ServiceModel
                {
                    ServiceName = s.ServiceName,
                    DisplayName = s.DisplayName,
                    Status = s.Status.ToString(),
                    StartType = GetServiceStartType(s.ServiceName)
                }).ToList();

            ServicesDataGrid.ItemsSource = services;
        }

        private string GetServiceStartType(string serviceName)
        {
            using (var service = new ServiceController(serviceName))
            {
                string startType = string.Empty;
                try
                {
                    // Use ManagementObject to retrieve start type
                    using (var managementObject = new System.Management.ManagementObject($"Win32_Service.Name='{serviceName}'"))
                    {
                        managementObject.Get();
                        startType = managementObject["StartMode"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving start type: {ex.Message}");
                }
                return startType;
            }
        }

        private void StartServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is ServiceModel selectedService)
            {
                try
                {
                    using (ServiceController sc = new ServiceController(selectedService.ServiceName))
                    {
                        if (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            sc.Start();
                            sc.WaitForStatus(ServiceControllerStatus.Running);
                            LoadServices();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting service: {ex.Message}");
                }
            }
        }

        private void StopServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is ServiceModel selectedService)
            {
                try
                {
                    using (ServiceController sc = new ServiceController(selectedService.ServiceName))
                    {
                        if (sc.Status == ServiceControllerStatus.Running)
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped);
                            LoadServices();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error stopping service: {ex.Message}");
                }
            }
        }

    }
}