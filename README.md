# ServiceManager
ServiceManager is a simple Windows desktop application built using WPF and C# that allows users to view, start, and stop Windows services. The application displays a list of services with their name, display name, current status, and startup type, and provides buttons to manage the selected service.

## Features
- **View Services**: Lists all Windows services with details such as service name, display name, current status (Running, Stopped, etc.), and startup type (Automatic, Manual, etc.).
- **Start Service**: Allows starting a selected service that is currently stopped.
- **Stop Service**: Allows stopping a selected service that is currently running.

## Getting Started

### Prerequisites
- **Visual Studio**: Ensure you have Visual Studio installed on your system.
- **.NET Framework**: This application targets the .NET Framework. Make sure the .NET Framework is installed on your machine.

### Running the Application
1. Clone the repository: git clone https://github.com/RubavathyImmanuvel/ServiceManager.git
2. Open the solution file (`ServiceManager.sln`) in Visual Studio.
3. Build the solution to restore the necessary packages.
4. Run the application. You should see a window displaying the list of Windows services on your machine.

### Usage
- **Viewing Services**: Upon launching the application, all Windows services are listed in a data grid.
- **Starting a Service**: Select a service from the list that is currently stopped and click the "Start" button.
- **Stopping a Service**: Select a service from the list that is currently running and click the "Stop" button.

## Contributions
Contributions are welcome! If you find a bug or have a feature request, please open an issue. Feel free to fork the repository and submit a pull request.
